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
    [Authorize]
    public class SharkController : Controller
    {
        // GET: Shark
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SharkService(userId);
            var model = service.GetSharks();
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SharkCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSharkService();

            if (service.CreateShark(model))
            {
                TempData["SaveResult"] = "Your Shark Was Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Shark could not be created.");

            return View(model);

        }

        private SharkService CreateSharkService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SharkService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSharkService();
            var model = svc.GetSharkById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSharkService();
            var detail = service.GetSharkById(id);

            var model = new SharkEdit
            {
                SharkName = detail.SharkName,
                Species = detail.Species,
                Length = detail.Length,
                Weight = detail.Weight,
                Sex = detail.Sex,
                Age = detail.Age,
            };
            return View(model);

        }
    }

}