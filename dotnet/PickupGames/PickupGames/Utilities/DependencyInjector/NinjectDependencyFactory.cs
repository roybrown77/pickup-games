﻿using Ninject.Modules;

namespace PickupGames.Utilities.DependencyInjector
{
    public static class NinjectDependencyFactory
    {
        public static INinjectModule Create()
        {
            // switch between real and mock based on url parameter or web.config

            return new MockNinjectDependencies();
        }
    }
}