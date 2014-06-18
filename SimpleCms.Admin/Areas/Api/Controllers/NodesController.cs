using SimpleCms.Admin.Areas.Api.Models;
using SimpleCms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleCms.Admin.Areas.Api.Controllers
{
    public class NodesController : ApiController
    {
        [HttpGet]
        public IEnumerable<NodePartial> Get()
        {
            using (var context = ApplicationDbContext.Create())
            {
                return context.Nodes.Select(NodePartial.FromNode).ToList();
            }
        }

        [HttpGet]
        public Node Get(Guid id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                return context.Nodes.FirstOrDefault(n => n.Id == id);
            }
        }
    }
}
