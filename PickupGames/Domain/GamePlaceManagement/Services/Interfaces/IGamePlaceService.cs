using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Repositories.Messaging;
using PickupGames.Domain.GamePlaceManagement.Models;

namespace PickupGames.Domain.GamePlaceManagement.Services.Interfaces
{
    public interface IGamePlaceService
    {
        List<Place> FindBy(GameSearchQuery gameSearchQuery);
    }
}