using System.Collections.Generic;
using PickupGames.Domain.GamePlaceManagement.Models;
using PickupGames.Domain.Geography;

namespace PickupGames.Domain.GamePlaceManagement.Repositories
{
    public interface IGamePlaceRepository
    {
        List<Place> GetPlaces(GeographySearchQuery geographySearchQuery);
    }
}
