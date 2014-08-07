namespace PickupGames.Controllers
{
    public static class DepedencyInjectorFactory
    {
        public static IDependencyInjector Create()
        {
            return new NinjectDependencyInjector();
        }
    }
}