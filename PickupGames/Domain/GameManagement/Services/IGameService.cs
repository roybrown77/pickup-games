using System;
using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories.Messaging;

namespace PickupGames.Domain.GameManagement.Services
{
    public interface IGameService
    {
        void CreateGame(Game game);
        void EditGame(Guid id, Game game);
        void DeleteGame(Guid id);
        List<Game> FindBy(GameSearchQuery gameSearchQuery, Coordinate centerCoordinates);
    }
}