using System.Collections.Generic;
using PickupGames.Api.Domain.Objects;
using PickupGames.Api.Models;
using System.Security.Claims;

namespace PickupGames.Mappers
{
    public static class GamesMapper
    {
        public static Game ConvertGameCreateModelToGame(string userId, GameCreateModel gameModel)
        {
            return new Game
                       {
                           Sport = new Sport { Id = gameModel.SportId },
                           DateTime = gameModel.DateTime,
                           Location = new Location { Address = gameModel.Location },
                           UserId = userId
                       };
        }

        public static GamesPageModel ConvertGameSearchResponseToGamesPageModel(GameSearchResponse response)
        {
            return new GamesPageModel
                       {
                           GameListModel = ConvertGameListToGameModelList(response.Games),
                           GameSearchModel = ConvertGameSearchResponseToGameSearchModel(response),
                           PlacesToPlayGamesModel = response.PlacesToPlayGames
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
                                          DateTime = game.DateTime,
                                          PlayerCount = game.PlayerCount,
                                          Location = new Location
                                          {
                                              Address = game.Location.Address,
                                              DistanceToCenterLocation = game.Location.DistanceToCenterLocation,
                                              Lat = game.Location.Lat,
                                              Lng = game.Location.Lng,
                                              ImageUrl = "https://maps.googleapis.com/maps/api/streetview?size=300x200&location=40.720032,-73.988354&fov=90&heading=235&pitch=10"
                                          }
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

        public static Game ConvertGameModelToGame(GameModel gameModel)
        {
            return new Game()
            {
                Sport = gameModel.Sport,
                DateTime = gameModel.DateTime,
                Location = gameModel.Location
            };
        }
    }
}