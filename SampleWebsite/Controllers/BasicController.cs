using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleWebsite.Controllers
{
    public class BasicController : Controller
    {
        // GET: Basic
        public ActionResult Page(Guid id)
        {
            var page = SimpleCms.Helper.GetPage(id);

            return View(page);
        }
    }
}