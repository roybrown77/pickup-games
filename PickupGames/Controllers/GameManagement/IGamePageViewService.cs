using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories.Messaging;

namespace PickupGames.Controllers.GameManagement
{
    public interface IGamePageViewService
    {
        GameSearchResponseListViewModel FindBy(GameSearchQuery gameSearchQuery);
    }
}