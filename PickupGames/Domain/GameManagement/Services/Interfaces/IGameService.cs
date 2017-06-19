using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories.Messaging;

namespace PickupGames.Domain.GameManagement.Services.Interfaces
{
    public interface IGameService
    {
        List<Game> FindBy(GameSearchQuery gameSearchQuery, Coordinate centerCoordinates);
    }
}