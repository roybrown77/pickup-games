using PickupGames.Domain.GameManagement.Models;

namespace PickupGames.Domain.Geography.Repositories.Interfaces
{
    public interface IGeographyRepository
    {
        Coordinate GetCoordinates(string address);
        Distance DistanceBetweenCoordinates(Coordinate start, Coordinate end);
    }
}
