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
            var document = SimpleCms.Helper.GetDocument(id);

            return View(document);
        }
    }
}