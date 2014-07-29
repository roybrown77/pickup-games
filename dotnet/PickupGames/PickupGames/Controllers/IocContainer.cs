using Ninject;

namespace PickupGames.Controllers
{
    public static class IocContainer
    {
        public static StandardKernel Dependencies { get; set; }
    }
}