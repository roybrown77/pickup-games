using System.Collections.Generic;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.ViewModels;

namespace PickupGames.Domain.GameManagement.Mappers
{
    public static class GamesMapper
    {
        public static Game ConvertGameCreateModelToGame(string userId, GameModel gameModel)
        {
            return new Game
                       {
                           Sport = new Sport { Id = gameModel.SportId },
                           DateTime = gameModel.DateTime,
                           Location = new Location { Address = gameModel.Location },
                           UserId = userId
                       };
        }

        public static GamesPageViewModel ConvertGameSearchResponseToGamesPageModel(GameSearchResponse response)
        {
            return new GamesPageViewModel
                       {
                           GameListModel = ConvertGameListToGameModelList(response.Games),
                           GameSearchModel = ConvertGameSearchResponseToGameSearchModel(response),
                           PlacesToPlayGamesModel = response.PlacesToPlayGames
                       };
        }

        private static GameSearchViewModel ConvertGameSearchResponseToGameSearchModel(GameSearchResponse response)
        {
            return new GameSearchViewModel
            {
                LocationLat = response.SearchLocationLat,
                LocationLng = response.SearchLocationLng
            };
        }

        private static List<GameViewModel> ConvertGameListToGameModelList(IEnumerable<Game> games)
        {
            var gameListModel = new List<GameViewModel>();

            if (games == null)
            {
                return gameListModel;
            }

            foreach (var game in games)
            {
                gameListModel.Add(new GameViewModel
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

        public static GameSearchQuery ConvertGameSearchModelToGameSearchQuery(GameSearchViewModel searchModel)
        {
            return new GameSearchQuery
                       {
                           Location = searchModel.Location ?? "usa",
                           Index = searchModel.Index ?? 1,
                           Zoom = searchModel.Zoom ?? 3
                       };
        }

        public static Game ConvertGameModelToGame(GameViewModel gameModel)
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