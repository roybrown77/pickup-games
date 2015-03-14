using System;
using System.Collections.Generic;
using Ninject;
using PickupGames.Domain.Objects;
using PickupGames.Repositories.Interfaces;
using PickupGames.Utilities.DependencyInjector;

namespace PickupGames.Domains
{
    public class SportDomain
    {
        private readonly ISportRepository _sportRepository;

        public SportDomain()
        {
            _sportRepository = NinjectDependencyInjector.Dependencies.Get<ISportRepository>();
        }

        public SportListResponse FindAll()
        {
            return new SportListResponse() { Sports = _sportRepository.FindAll() };
        }
    }
}