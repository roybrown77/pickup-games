using System.Web.Mvc;
using Ninject;

namespace PickupGames.Controllers
{
    public class ControllerBase : Controller
    {
        public ControllerBase()
        {
            NinjectContainer.Dependencies = new StandardKernel(new NinjectDependencies());
        }
    }
}