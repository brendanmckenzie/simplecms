using SimpleCms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SimpleCms
{
    public static class Helper
    {
        public static dynamic GetDocument(Guid id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var node = context.Nodes.SingleOrDefault(n => n.Id == id);

                return JsonConvert.DeserializeObject(node.DocumentData);
            }
        }
    }
}