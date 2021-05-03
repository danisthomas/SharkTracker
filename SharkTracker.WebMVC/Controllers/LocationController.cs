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
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index(LocationListItem name,string search)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            var model = service.GetLocations();

            if (search != null)
            {

                return View(model.Where(x => x.TaggingLocation.StartsWith(search) || search == null).ToList());
            }
            else
                return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateLocationService();

            if (service.CreateLocation(model))
            {
                TempData["SaveResult"] = "Your Tagging location was Created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Your Tagging Location could not be created.");

            return View(model);
        }

        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationsById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLocationService();
            var detail = service.GetLocationsById(id);

            var model = new LocationEdit
            {
                LocationId = detail.LocationId,
                TaggingLocation = detail.TaggingLocation
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.LocationId != id)
            {
                ModelState.AddModelError("", "Id MisMatch");
                return View(model);
            }
            var service = CreateLocationService();
            if (service.UpdateLocation(model))
            {
                TempData["SaveResult"] = "Your Tagging Location was Update.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Your Tagging Location could not be updated.");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationsById(id);

            return View(model);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost (int id)
        {
            var service = CreateLocationService();
            service.DeleteLocation(id);

            TempData["SaveResult"] = "Your Tagging location was deleted.";
            return RedirectToAction("Index");
        }

    }
}
