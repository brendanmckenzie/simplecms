using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleCms.Admin.Startup))]
namespace SimpleCms.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
