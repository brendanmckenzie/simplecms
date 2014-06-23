using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace SimpleCms.Admin.Controllers
{
    public class AuthController : ApiController
    {
        [Route(Name="Login")]
        public HttpResponseMessage Login()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("hello", Encoding.Unicode);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        }
    }
}
