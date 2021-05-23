using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CakeDistribution.WebMVC.Startup))]
namespace CakeDistribution.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
