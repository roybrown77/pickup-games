using PickupGames.Domain.GameManagement.Models;

namespace PickupGames.Infrastructure.Geography
{
    public interface IGeographyService
    {
        Coordinate GetCoordinates(string address);
        Distance DistanceBetweenCoordinates(Coordinate start, Coordinate end);
    }
}
