using System.Collections.Generic;
using PickupGames.Domain.Objects;
using PickupGames.Models;

namespace PickupGames.Mappers
{
    public static class GamesMapper
    {
        public static Game ConvertGameCreateModelToGame(GameCreateModel gameModel)
        {
            return new Game
                       {
                           Name = gameModel.Name,
                           Sport = gameModel.Sport,
                           GameTime = gameModel.GameTime,
                           Location = gameModel.Location
                       };
        }

        public static GamesModel ConvertGameListToGamesModel(List<Game> games)
        {
            return new GamesModel
                       {
                           GameListModel = ConvertGames(games)
                       };
        }

        private static List<GameModel> ConvertGames(IEnumerable<Game> games)
        {
            var gameListModel = new List<GameModel>();
            
            foreach (var game in games)
            {
                gameListModel.Add(new GameModel
                                      {
                                          Name = game.Name,
                                          Sport = game.Sport,
                                          GameDate = game.GameDate,
                                          GameTime = game.GameTime,
                                          Location = game.Location,
                                          PlayerCount = game.PlayerCount,
                                          DistanceToLocation = game.DistanceToLocation
                                      });
            }

            return gameListModel;
        }

        public static SearchQuery ConvertSearchModelToSearchQuery(GameSearchModel searchModel)
        {
            return new SearchQuery
                       {
                           Location = searchModel.Location
                       };
        }
    }
}