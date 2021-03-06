﻿using SimpleCms.Models;
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
        #region Public Methods

        public static void Initialise()
        {
            using (var context = ApplicationDbContext.Create())
            {
                foreach (var node in context.Nodes)
                {
                    object defaults = null;
                    string[] namespaces = new string[0];

                    switch (node.Type)
                    {
                        case NodeType.Redirect:
                            defaults = new { controller = "Redirect", action = "External", destination = node.Redirect };
                            namespaces = new string[] { "SimpleCms.Controllers" };
                            break;
                        case NodeType.Mvc:
                            defaults = new { controller = node.Controller, action = node.Action, id = node.Id };
                            break;
                        case NodeType.External:
                            continue;
                    }
                    RouteTable.Routes.MapRoute(node.Id.ToString(), node.GetUrlPath(), defaults, null, namespaces);
                }
            }
        }

        #endregion

        #region Private Methods

        static string GetUrlPath(this Node page)
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

        #endregion
    }
}