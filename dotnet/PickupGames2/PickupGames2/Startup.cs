using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PickupGames2.Startup))]
namespace PickupGames2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
