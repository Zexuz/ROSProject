using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoS.MVC.Startup))]
namespace RoS.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
