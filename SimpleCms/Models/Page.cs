using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCms.Models
{
    public class Page
    {
        public Guid Id { get; set; }

        public Page Parent { get; set; }

        public string Title { get; set; }

        public string UrlKey { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }
    }
}