using System.Web.Http;
using Ninject;
using PickupGames.Utilities.DependencyInjector;

namespace PickupGames.Api
{
    public class ApiControllerBase : ApiController
    {
        protected ApiControllerBase()
        {
            NinjectDependencyInjector.Dependencies = new StandardKernel(NinjectDependencyFactory.Create());
        }
    }
}