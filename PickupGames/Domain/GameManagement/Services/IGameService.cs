using System;
using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.GameManagement.Services
{
    public interface IGameService
    {
        BasicResponse CreateGame(Game game);
        BasicResponse EditGame(Guid id, Game game);
        BasicResponse DeleteGame(Guid id);
        List<Game> FindBy(GameSearchQuery gameSearchQuery, Coordinate centerCoordinates);
    }
}