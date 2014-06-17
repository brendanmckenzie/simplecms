using SimpleCms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace SimpleCms
{
    public static class Startup
    {
        public static void Initialise()
        {
            // run through the pages and build the route table from that
            // RouteTable
            using (var context = ApplicationDbContext.Create())
            {
                foreach (var page in context.Pages)
                {
                    RouteTable.Routes.MapRoute(page.Id.ToString(), page.GetUrlPath(), new { controller = page.Controller, action = page.Action, id = page.Id });
                }
            }
        }

        private static string GetUrlPath(this Page page)
        {
            var parent = page.Parent;
            if (parent == null)
            {
                return page.UrlKey;
            }
            else
            {
                var ret = page.UrlKey;
                while (parent != null)
                {
                    ret = parent.UrlKey + "/" + ret;
                    parent = parent.Parent;
                }
                return ret;
            }
        }
    }
}