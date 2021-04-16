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
    public class SharkTagController : Controller
    {
        // GET: SharkTag
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SharkTagService(userId);
            var model = service.GetSharkTags();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SharkTagCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateSharkTagService();

            if (service.CreateSharkTag(model))
            {
                TempData["SaveResult"] = "Your Shark Tagging Event was Created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Shark Tagging Event could not be created.");

            return View(model);

        }

        private SharkTagService CreateSharkTagService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SharkTagService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSharkTagService();
            var model = svc.GetSharkTagById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSharkTagService();
            var detail = service.GetSharkTagById(id);

            var model = new SharkTagEdit
            {
                SharkTagId = detail.SharkTagId,
                StartDate = detail.StartDate,
                EndDate = detail.EndDate,
                SharkId = detail.SharkId,
                TagId = detail.TagId,
                LocationId = detail.LocationId
            };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SharkTagEdit model)
        {
            if (ModelState.IsValid) return View(model);
            if(model.SharkTagId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateSharkTagService();
            if (service.UpdateSharkTag(model))
            {
                TempData["SaveResult"] = "Your Shark Tagging Event was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Shark Tagging Event could not be updated.");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateSharkTagService();
            var model = svc.GetSharkTagById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeletePost(int id)
        {
            var service = CreateSharkTagService();
            service.DeleteSharkTag(id);

            TempData["SaveResult"] = "Your Shark Tagging Event was deleted.";
            return RedirectToAction("Index");
        }
    }
}