using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace PickupGames
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
 
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{version}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
 
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //var container = IoCFactory.GetStructureMapContainer(appSettings);
            //GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container.Initialize());

            //config.Services.Replace(typeof(IHttpActionInvoker), new CustomHttpActionInvoker());
        }
    }
}
