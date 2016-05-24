using System.Collections.Generic;
using PickupGames.Domain.GamePlaceManagement.Models;
using PickupGames.Domain.Geography.Repositories.Messaging;

namespace PickupGames.Domain.GamePlaceManagement.Repositories.Interfaces
{
    public interface IGamePlaceRepository
    {
        List<Place> GetPlaces(GeographySearchQuery geographySearchQuery);
    }
}
