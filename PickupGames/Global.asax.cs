using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using PickupGames.Utilities.DependencyInjector;

namespace PickupGames
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //GlobalConfiguration.Configure(WebApiConfig.Register);

            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            //NinjectDependencyInjector.Dependencies = new StandardKernel(NinjectDependencyFactory.Create());
        }
    }
}
