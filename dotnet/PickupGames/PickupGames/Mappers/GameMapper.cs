using PickupGames.Models;
using PickupGames.Objects;

namespace PickupGames.Mappers
{
    public static class GameMapper
    {
        public static Game ConvertGameModelToGame(CreateGameModel gameModel)
        {
            return new Game();
        }
    }
}