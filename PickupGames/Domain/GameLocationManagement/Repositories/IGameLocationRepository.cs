using System.Collections.Generic;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Infrastructure.Geography;

namespace PickupGames.Domain.GameLocationManagement.Repositories
{
    public interface IGameLocationRepository
    {
        List<Location> GetPlaces(GeographySearchQuery geographySearchQuery);
    }
}
