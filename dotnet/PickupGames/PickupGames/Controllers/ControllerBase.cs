using System.Web.Mvc;
using Ninject;
using PickupGames.Utilities.DependencyInjector;

namespace PickupGames.Controllers
{
    public class ControllerBase : Controller
    {
        public ControllerBase()
        {
            NinjectDependencyInjector.Dependencies = new StandardKernel(NinjectDependencyFactory.Create());
        }
    }
}