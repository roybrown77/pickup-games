using PickupGames.Domain.Objects;

namespace PickupGames.Repositories
{
    public interface IGeographyRepository
    {
        Coordinates GetCoordinates(string location);
        string DistanceBetweenCoordinates(Coordinates start, Coordinates end);
    }
}
