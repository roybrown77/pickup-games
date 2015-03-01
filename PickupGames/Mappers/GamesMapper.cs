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
                           Sport = gameModel.Sport,
                           GameTime = gameModel.GameTime,
                           Location = gameModel.Location
                       };
        }

        public static GamesPageModel ConvertGameSearchResponseToGamesPageModel(GameSearchResponse response)
        {
            return new GamesPageModel
                       {
                           GameListModel = ConvertGameListToGameModelList(response.Games),
                           GameSearchModel = ConvertGameSearchResponseToGameSearchModel(response)
                       };
        }

        private static GameSearchModel ConvertGameSearchResponseToGameSearchModel(GameSearchResponse response)
        {
            return new GameSearchModel
            {
                LocationLat = response.SearchLocationLat,
                LocationLng = response.SearchLocationLng
            };
        }

        private static List<GameModel> ConvertGameListToGameModelList(IEnumerable<Game> games)
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
                                          Sport = game.Sport,
                                          GameDate = game.GameDate,
                                          GameTime = game.GameTime,
                                          Location = game.Location,
                                          PlayerCount = game.PlayerCount,
                                          DistanceToCenterLocation = game.DistanceToCenterLocation.Value + " " + game.DistanceToCenterLocation.Unit,
                                          LocationLat = game.LocationLat,
                                          LocationLng = game.LocationLng,
                                          LocationImageUrl = "https://maps.googleapis.com/maps/api/streetview?size=300x200&location=40.720032,-73.988354&fov=90&heading=235&pitch=10"
                                      });
            }

            return gameListModel;
        }

        public static GameSearchQuery ConvertGameSearchModelToGameSearchQuery(GameSearchModel searchModel)
        {
            return new GameSearchQuery
                       {
                           Location = searchModel.Location ?? "usa",
                           Index = searchModel.Index ?? 1,
                           Zoom = searchModel.Zoom ?? 3
                       };
        }
    }
}