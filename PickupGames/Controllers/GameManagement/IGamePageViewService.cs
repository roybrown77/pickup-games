using PickupGames.Domain.GameManagement.Models;

namespace PickupGames.Controllers.GameManagement
{
    public interface IGamePageViewService
    {
        GameSearchResponse FindBy(GameSearchQuery gameSearchQuery);
    }
}