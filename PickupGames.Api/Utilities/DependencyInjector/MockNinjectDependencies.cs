using Ninject.Modules;
using PickupGames.Api.Repositories;
using PickupGames.Api.Repositories.Interfaces;
using PickupGames.Api.Repositories.Mocks;

namespace PickupGames.Api.Utilities.DependencyInjector
{
    public class MockNinjectDependencies : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameRepository>().ToMethod(context => new MockGameRepository());
            Bind<ISportRepository>().ToMethod(context => new MockSportRepository());
            Bind<IGeographyRepository>().ToMethod(context => new GoogleGeographyRepository());
        }
    }
}
