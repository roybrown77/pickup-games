using System.Collections.Generic;
using PickupGames.Api.Domain.Objects;
using System;

namespace PickupGames.Api.Repositories.Interfaces
{
    public interface IGameRepository
    {
        void Add(Game game);
        void Edit(Guid id, Game game);
        void Delete(Guid id);
        List<Game> FindAll();
        List<Game> FindBy(string location);
        List<Game> FindBy(GameSearchQuery gameSearchQuery);        
    }
}
