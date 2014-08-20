using System.Collections.Generic;
using PickupGames.Domain.Objects;

namespace PickupGames.Repositories.Interfaces
{
    public interface IGameRepository
    {
        void Add(Game game);
        List<Game> FindAll();
        List<Game> FindAll(GameSearchRequest request);
        List<Game> FindBy(string location);
        List<Game> FindBy(string location, GameSearchRequest request);
        List<Game> FindBy(SearchQuery searchQuery);
        List<Game> FindBy(SearchQuery searchQuery, GameSearchRequest request);
    }
}
