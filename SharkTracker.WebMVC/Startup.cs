using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharkTracker.WebMVC.Startup))]
namespace SharkTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
