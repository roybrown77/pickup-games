using System.Collections.Generic;
using PickupGames.Domain.Objects;
using PickupGames.Models;
using PickupGames.Utilities;

namespace PickupGames.Mappers
{
    public static class GamesMapper
    {
        public static Game ConvertGameCreateModelToGame(GameCreateModel gameModel)
        {
            var coordinates = GeographyUtility.GetCoordinates(gameModel.Location);

            return new Game
                       {                          
                           Name = gameModel.Name,
                           Sport = gameModel.Sport,
                           GameTime = gameModel.GameTime,
                           Location = gameModel.Location,
                           LocationLat = coordinates.Lat,
                           LocationLng = coordinates.Lng
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
                                          Id = game.Id,
                                          Name = game.Name,
                                          Sport = game.Sport,
                                          GameDate = game.GameDate,
                                          GameTime = game.GameTime,
                                          Location = game.Location,
                                          PlayerCount = game.PlayerCount,
                                          DistanceToLocation = game.DistanceToLocation,
                                          LocationLat = game.LocationLat,
                                          LocationLng = game.LocationLng
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