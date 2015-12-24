using System;
using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories.Messaging;
using PickupGames.Domain.GameManagement.Services.Messaging;

namespace PickupGames.Domain.GameManagement.Services
{
    public interface IGameService
    {
        void CreateGame(CreateGameRequest game);
        void EditGame(Guid id, Game game);
        void DeleteGame(Guid id);
        List<Game> FindBy(GameSearchQuery gameSearchQuery, Coordinate centerCoordinates);
    }
}