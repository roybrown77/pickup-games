using System.Collections.Generic;
using PickupGames.Domain.Objects;

namespace PickupGames.Repositories.Interfaces
{
    public interface IGameRepository
    {
        void Add(Game game);
        List<Game> FindBy(string location);
        List<Game> FindBy(SearchQuery searchQuery);
    }
}
