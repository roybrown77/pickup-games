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

        public static GamesModel ConvertGameListToGamesModel(GameSearchResponse response)
        {
            return new GamesModel
                       {
                           GameListModel = ConvertGameListToGamesModelList(response.Games),
                           GameSearchModel = GetGameSearchModel(response)
                       };
        }

        private static GameSearchModel GetGameSearchModel(GameSearchResponse response)
        {
            return new GameSearchModel
            {
                LocationLat = response.SearchLocationLat,
                LocationLng = response.SearchLocationLng,
                Zoom = response.Zoom
            };
        }

        private static List<GameModel> ConvertGameListToGamesModelList(IEnumerable<Game> games)
        {
            var gameListModel = new List<GameModel>();

            if (games == null)
            {
                return gameListModel;
            }

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
                                          DistanceToCenterLocation = game.DistanceToCenterLocation.Value + " " + game.DistanceToCenterLocation.Unit,
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
                           Location = searchModel.Location,
                           Index = searchModel.Index ?? 1,
                           Zoom = searchModel.Zoom ?? 3
                       };
        }
    }
}