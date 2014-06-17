using System;
using System.Web.Mvc;

namespace SimpleCms
{
    public class RedirectController : Controller
    {
        public ActionResult External(string url)
        {
            return Redirect(url);
        }
    }
}

