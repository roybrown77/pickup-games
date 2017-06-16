using Ninject.Modules;
using PickupGames.Domain.AccountManagement.Repositories;
using PickupGames.Domain.AccountManagement.Services;
using PickupGames.Domain.GameManagement.Repositories;
using PickupGames.Domain.GameManagement.Services;

namespace PickupGames.Infrastructure.DependencyInjector2
{
    public class MockNinjectDependencies : NinjectModule
    {
        public override void Load()
        {
            //Bind<IAuthorizationServerProvider>().ToMethod(context => new MockAuthorizationServerProvider());

            //Bind<IGameRepository>().ToMethod(context => new MockGameRepository());
            //Bind<IGamePlaceRepository>().ToMethod(context => new GamePlaceRepository());            
            //Bind<ISportRepository>().ToMethod(context => new MockSportRepository());
            //Bind<IGeographyService>().ToMethod(context => new GeographyService());
            //Bind<IAuthRepository>().ToMethod(context => new MockAuthRepository());

            //Bind<IAuthService>().ToMethod(context => new AuthService());
            //Bind<IGameService>().ToMethod(context => new GameService());
            //Bind<IGamePlaceService>().ToMethod(context => new GamePlaceService());            
        }
    }
}
