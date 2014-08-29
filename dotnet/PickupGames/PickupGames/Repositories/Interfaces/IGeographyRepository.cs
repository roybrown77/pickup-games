using PickupGames.Domain.Objects;

namespace PickupGames.Repositories.Interfaces
{
    public interface IGeographyRepository
    {
        Coordinates GetCoordinates(string location);
        Distance DistanceBetweenCoordinates(Coordinates start, Coordinates end);
    }
}
