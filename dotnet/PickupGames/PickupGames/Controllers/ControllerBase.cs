using System.Web.Mvc;
using Ninject;

namespace PickupGames.Controllers
{
    public class ControllerBase : Controller
    {
        public static StandardKernel IocContainer;

        public ControllerBase()
        {
            IocContainer = new StandardKernel(new Dependencies());
        }
    }
}