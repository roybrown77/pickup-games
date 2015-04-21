using PickupGames.Api.Domain.Objects;
using System.Collections.Generic;

namespace PickupGames.Api.Repositories.Interfaces
{
    public interface IGeographyRepository
    {
        Coordinates GetCoordinates(string address);
        Distance DistanceBetweenCoordinates(Coordinates start, Coordinates end);
        List<Location> GetPlaces(GeographySearchQuery geographySearchQuery);
    }
}
