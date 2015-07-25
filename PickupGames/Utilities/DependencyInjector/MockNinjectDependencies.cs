﻿using Ninject.Modules;
using PickupGames.Providers;
using PickupGames.Repositories;
using PickupGames.Repositories.Interfaces;
using PickupGames.Repositories.Mocks;

namespace PickupGames.Utilities.DependencyInjector
{
    public class MockNinjectDependencies : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameRepository>().ToMethod(context => new MockGameRepository());
            Bind<ISportRepository>().ToMethod(context => new MockSportRepository());
            Bind<IGeographyRepository>().ToMethod(context => new GoogleGeographyRepository());
            Bind<IAuthRepository>().ToMethod(context => new MockAuthRepository());
            Bind<IAuthorizationServerProvider>().ToMethod(context => new MockAuthorizationServerProvider());
        }
    }
}