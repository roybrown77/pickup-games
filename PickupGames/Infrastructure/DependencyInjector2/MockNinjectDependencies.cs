using Ninject.Modules;
using PickupGames.Domain.AccountManagement.Repositories;
using PickupGames.Domain.AccountManagement.Services;
using PickupGames.Domain.GameLocationManagement.Repositories;
using PickupGames.Domain.GameLocationManagement.Services;
using PickupGames.Domain.GameManagement.Repositories;
using PickupGames.Domain.GameManagement.Services;
using PickupGames.Infrastructure.Geography;

namespace PickupGames.Infrastructure.DependencyInjector2
{
    public class MockNinjectDependencies : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthorizationServerProvider>().ToMethod(context => new MockAuthorizationServerProvider());

            Bind<IGameRepository>().ToMethod(context => new MockGameRepository());
            Bind<IGameLocationRepository>().ToMethod(context => new GameLocationRepository());            
            Bind<ISportRepository>().ToMethod(context => new MockSportRepository());
            Bind<IGeographyService>().ToMethod(context => new GeographyService());
            Bind<IAuthRepository>().ToMethod(context => new MockAuthRepository());

            Bind<IAuthService>().ToMethod(context => new AuthService());
            Bind<IGameService>().ToMethod(context => new GameService());
            Bind<IGameLocationService>().ToMethod(context => new GameLocationService());            
        }
    }
}
