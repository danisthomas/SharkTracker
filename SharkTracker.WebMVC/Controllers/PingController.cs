using Microsoft.AspNet.Identity;
using SharkTracker.Models;
using SharkTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharkTracker.WebMVC.Controllers
{
    public class PingController : Controller
    {
        // GET: Ping
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PingService(userId);
            var model = service.GetPings();
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PingCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreatePingService();

            if (service.CreatePing(model))
            {
                TempData["SaveResult"] = "Your Ping was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Ping would not be created.");

            return View(model);
        }

        private PingService CreatePingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PingService(userId);

            return service;
        }

        public ActionResult Detail(int id)
        {
            var svc = CreatePingService();
            var model = svc.GetPingById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePingService();
            var detail = service.GetPingById(id);

            var model = new PingEdit
            {
                PingDateTime = detail.PingDateTime,
                PingLocation = detail.PingLocation,
                SharkId = detail.SharkId,
                TagNumber = detail.TagNumber
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PingEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.PingId!= id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreatePingService();

            if (service.UpdatePing(model))
            {
                TempData["SaveResult"] = "Your Ping was updated.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Your Ping would not be updated.");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreatePingService();
            var model = svc.GetPingById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePingService();

            service.DeletePing(id);

            TempData["SaveResult"] = "Your Ping was delted.";
            return RedirectToAction("Index");
        }
    }
}