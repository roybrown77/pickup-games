using System.Collections.Generic;
using PickupGames.Domain.Objects;

namespace PickupGames.Repositories.Interfaces
{
    public interface IGameRepository
    {
        void Add(Game game);
        List<Game> FindAll();
        List<Game> FindBy(string location);
        List<Game> FindBy(GameSearchQuery gameSearchQuery);        
    }
}
