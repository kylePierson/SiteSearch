using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteAlerts.Startup))]
namespace SiteAlerts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
