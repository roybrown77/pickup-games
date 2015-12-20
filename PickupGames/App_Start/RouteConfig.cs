using System.Web.Routing;

namespace PickupGames
{
    class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "UserEmailValidation", id = UrlParameter.Optional }
            );
        }
    }
}
