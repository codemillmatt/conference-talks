using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Foodie.Backend.Startup))]

namespace Foodie.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}