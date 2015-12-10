using Ninject.Modules;
using PickupGames.Domain.AccountManagement.Repositories;
using PickupGames.Domain.GameManagement.Repositories;
using PickupGames.Infrastructure.Geography;

namespace PickupGames.Infrastructure.DependencyInjector
{
    public class MockNinjectDependencies : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameRepository>().ToMethod(context => new MockGameRepository());            
            Bind<ISportRepository>().ToMethod(context => new MockSportRepository());
            Bind<IGeographyService>().ToMethod(context => new GeographyService());
            Bind<IAuthRepository>().ToMethod(context => new MockAuthRepository());
            Bind<IAuthorizationServerProvider>().ToMethod(context => new MockAuthorizationServerProvider());
        }
    }
}
