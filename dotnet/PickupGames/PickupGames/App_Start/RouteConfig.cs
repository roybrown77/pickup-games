using System.Web.Mvc;
using System.Web.Routing;

namespace PickupGames
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "GamesSearch",
               url: "Games/Search/{location}",
               defaults: new { controller = "Games", action = "Search", location = "usa" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}