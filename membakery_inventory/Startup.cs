using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(membakery_inventory.Startup))]
namespace membakery_inventory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
