using PickupGames.Api.Domain.Objects;

namespace PickupGames.Api.Repositories.Interfaces
{
    public interface IGeographyRepository
    {
        Coordinates GetCoordinates(string location);
        Distance DistanceBetweenCoordinates(Coordinates start, Coordinates end);
    }
}
