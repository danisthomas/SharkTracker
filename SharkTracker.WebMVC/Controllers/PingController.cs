using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using SharkTracker.Data;
using SharkTracker.Models;
using SharkTracker.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SharkTracker.WebMVC.Controllers
{
    public class PingController : Controller
    {
        // GET: Ping
        public ActionResult Index(PingListItem name, string search)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PingService(userId);
            var model = service.GetPings();
            if (search != null)
            {

                return View(model.Where(x => x.PingLocation.StartsWith(search, StringComparison.OrdinalIgnoreCase) || search == null).ToList());
            }
            else
                return View(model);
        }

        

        //Get
        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SharkTagService(userId);
           List<SharkTag> sharkTags = service.GetSharkTagsList().ToList();
            
            var query = from s in sharkTags
                        select new SelectListItem()
                        {
                           
                            Value = s.SharkTagId.ToString(),
                            Text = s.TagId.ToString()
                        };
            ViewBag.SharkTagId = query;
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

        public ActionResult Details(int id)
        {
            var svc = CreatePingService();
            var model = svc.GetPingById(id);

            return View(model);
        }

        //[Route("Ping/Location")]
        //public ViewResult PingLocationDetail(string location)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var svc = CreatePingService();
        //        var model = svc.GetPingByPingLocation(location);

        //        var locations = from l in ctx.Ping select l;
        //        if (!string.IsNullOrWhiteSpace(location))
        //        {
        //            locations = locations.Where(l => l.PingLocation.Contains(location));
        //        }
        //        return View("PingLocationDetail");
        //    }

        //}

        public ActionResult Edit(int id)
        {
            var service = CreatePingService();
            var detail = service.GetPingById(id);

            var userId = Guid.Parse(User.Identity.GetUserId());
            var sservice = new SharkTagService(userId);

            List<SharkTag> SharkTags = sservice.GetSharkTagsList().ToList();

            ViewBag.SharkTagId = SharkTags.Select(s => new SelectListItem()
            {
                Value = s.SharkTagId.ToString(),
                Text = s.TagId.ToString(),
                Selected = detail.SharkTagId == s.SharkTagId
            });

            var model = new PingEdit
            {
                PingId=detail.PingId,
                PingDate = detail.PingDate,
                PingLocation = detail.PingLocation,
                SharkTagId = detail.SharkTagId,
                
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