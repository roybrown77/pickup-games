using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories.Messaging;
using PickupGames.Domain.GameManagement.Services.Messaging;

namespace PickupGames.Domain.GameManagement.Mappers
{
    public static class GamesMapper
    {
        public static GameSearchQuery ConvertGameSearchModelToGameSearchQuery(GameSearchRequest searchModel)
        {
            return new GameSearchQuery
                       {
                           Location = searchModel.Location ?? "usa",
                           Index = searchModel.Index ?? 1,
                           Zoom = searchModel.Zoom ?? 3
                       };
        }

        public static Game ConvertGameModelToGame(EditGameRequest editGameModel)
        {
            return new Game()
            {
                Sport = editGameModel.Sport,
                DateTime = editGameModel.DateTime,
                Location = editGameModel.Location
            };
        }
    }
}