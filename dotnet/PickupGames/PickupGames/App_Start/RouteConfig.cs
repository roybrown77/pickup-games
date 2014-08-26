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
               name: "Games",
               url: "Games",
               defaults: new { controller = "Games", action = "Search", page = 1 }
            );

            routes.MapRoute(
               name: "GamesSearch",
               url: "Games/Search",
               defaults: new { controller = "Games", action = "Search", page = 1 }
            );


            routes.MapRoute(
               name: "GamesSearchPage",
               url: "Games/Search/{page}",
               defaults: new { controller = "Games", action = "Search", page = 1 }
            );       

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}