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
            var model = new SharkListItem[0];
            return View(model);
        }
    }
}