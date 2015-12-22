using System;
using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories.Messaging;

namespace PickupGames.Domain.GameManagement.Repositories
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
