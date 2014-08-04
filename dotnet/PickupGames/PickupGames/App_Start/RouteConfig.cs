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
                name: "SearchGames",
                url: "Games/Search/{SearchLocation}",
                defaults: new { controller = "Games", action = "Search" }
            );

            /*routes.MapRoute(
                name: "SearchGamesQuery",
                url: "SearchGames/[query]",
                defaults: new { controller = "SearchGames", action = "Results" }
            );

            routes.MapRoute(
                name: "SearchGamesQueryPage",
                url: "SearchGames/[query]/[page]",
                defaults: new { controller = "SearchGames", action = "Results", page = 1 }
            );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}