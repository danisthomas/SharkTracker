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
    public class TagController : Controller
    {
        // GET: Tag
        public ActionResult Index(TagListItem name, string search,string option)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TagService(userId);
            var model = service.GetTags();
            if (option == "Manufacturer")

            {

                return View(model.Where(t => t.TagManufacturer.StartsWith(search, StringComparison.OrdinalIgnoreCase) || search == null).ToList());
            }
            else if(option == "Model")
            {
                return View(model.Where(t => t.TagModel.StartsWith(search, StringComparison.OrdinalIgnoreCase) || search == null).ToList());
            }
            else if(option == "SerialNumber")
            {
                return View(model.Where(t => t.TagSerialNumber.StartsWith(search, StringComparison.OrdinalIgnoreCase) || search == null).ToList());
            }
                return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TagCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateTagService();

            if (service.CreateTag(model))
            {
                TempData["SaveResult"] = "Your Tag was Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Tag could not be created.");

            return View(model);
        }

        private TagService CreateTagService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TagService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTagService();
            var model = svc.GetTagById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTagService();
            var detail = service.GetTagById(id);

            var model = new TagEdit
            {
                TagId = detail.TagId,
                TagManufacturer = detail.TagManufacturer,
                TagModel = detail.TagModel,
                TagSerialNumber = detail.TagSerialNumber
                
            };
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TagEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.TagId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateTagService();
            if (service.UpdateTag(model))
            {
                TempData["SaveResult"] = "Your Tag was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Tag could not be updated.");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateTagService();
            var model = svc.GetTagById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTagService();
            service.DeleteTag(id);

            TempData["SaveResult"] = "Your Tag was deleted.";
            return RedirectToAction("Index");
        }
    }
}