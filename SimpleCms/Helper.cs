using SimpleCms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCms
{
    public static class Helper
    {
        public static Page GetPage(Guid id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                return context.Pages.SingleOrDefault(p => p.Id == id);
            }
        }
    }
}