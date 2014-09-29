using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PickupGames.Startup))]
namespace PickupGames
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
