using System.Web.Mvc;
using Ninject;

namespace PickupGames.Controllers
{
    public class ControllerBase : Controller
    {
        public ControllerBase()
        {
            IocContainer.Dependencies = new StandardKernel(new Dependencies());
        }
    }
}