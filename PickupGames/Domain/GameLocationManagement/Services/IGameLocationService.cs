using System.Collections.Generic;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Domain.GameManagement.Repositories.Messaging;

namespace PickupGames.Domain.GameLocationManagement.Services
{
    public interface IGameLocationService
    {
        List<Location> FindBy(GameSearchQuery gameSearchQuery);
    }
}