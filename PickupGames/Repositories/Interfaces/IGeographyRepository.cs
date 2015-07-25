using PickupGames.Models;
using System.Collections.Generic;

namespace PickupGames.Repositories.Interfaces
{
    public interface IGeographyRepository
    {
        Coordinate GetCoordinates(string address);
        Distance DistanceBetweenCoordinates(Coordinate start, Coordinate end);
        List<Location> GetPlaces(GeographySearchQuery geographySearchQuery);
    }
}
