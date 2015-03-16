using System.Collections.Generic;
using PickupGames.Domain.Objects;
using System;

namespace PickupGames.Repositories.Interfaces
{
    public interface IGameRepository
    {
        void Add(Game game);
        void Edit(Game game);
        void Delete(Guid id);
        List<Game> FindAll();
        List<Game> FindBy(string location);
        List<Game> FindBy(GameSearchQuery gameSearchQuery);        
    }
}
