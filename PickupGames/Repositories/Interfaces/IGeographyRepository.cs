using PickupGames.Domain.Objects;
using System.Collections.Generic;

namespace PickupGames.Repositories.Interfaces
{
    public interface IGeographyRepository
    {
        Coordinates GetCoordinates(string address);
        Distance DistanceBetweenCoordinates(Coordinates start, Coordinates end);
        List<Location> GetPlaces(GeographySearchQuery geographySearchQuery);
    }
}
