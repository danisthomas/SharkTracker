using Korzh.EasyQuery.Linq;
using Microsoft.AspNet.Identity;
using SharkTracker.Data;
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
        public ActionResult Index(SharkListItem name,string search)
        {
                
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new SharkService(userId);
                var model = service.GetSharks();
            if (search!=null)
            {
               
                return View(model.Where(x => x.SharkName.StartsWith(search) || search == null).ToList());
            }
            else
            return View(model);
            
        }

        //[HttpPost]

        //public ActionResult  Index(SharkListItem list , string input)
        //{
        //    if (!string.IsNullOrEmpty(input))
        //    {


        //        var userId = Guid.Parse(User.Identity.GetUserId());
        //        var service = new SharkService(userId);
        //        var model = service.GetSharksByName(input).FullTextSearchQuery(input);
        //        return View(model);
        //    }
        //    else
        //        return View(list);
        //}
        

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
                TempData["SaveResult"] = "Your Shark was Created.";
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
                SharkId = detail.SharkId,
                SharkName = detail.SharkName,
                Species = detail.Species,
                Length = detail.Length,
                Weight = detail.Weight,
                Sex = detail.Sex,
                Age = detail.Age,
            };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SharkEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.SharkId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateSharkService();
            if (service.UpdateShark(model))
            {
                TempData["SaveResult"] = "Your Shark was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Shark could not be updated.");


            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateSharkService();
            var model = svc.GetSharkById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSharkService();
            service.DeleteShark(id);

            TempData["SaveResult"] = "Your shark was deleted.";
            return RedirectToAction("Index");
        }


    }

}