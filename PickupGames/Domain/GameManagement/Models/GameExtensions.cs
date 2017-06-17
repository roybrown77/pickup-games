using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Services.Messaging;
using PickupGames.Domain.GamePlaceManagement.Models;

namespace PickupGames.Domain.GameManagement.Models
{
    public static class GameExtensions
    {
        public static List<Game> GetGamesWithinRadius(this IEnumerable<Game> games, Distance maxDistance)
        {
            var newGames = new List<Game>();

            foreach (var game in games)
            {
                if (game.Location.DistanceToCenterLocation.Value < maxDistance.Value)
                {
                    newGames.Add(game);
                }
            }

            return newGames;
        }

        public static List<EditGameRequest> ConvertGameListToGameModelList(this IEnumerable<Game> games)
        {
            var gameListModel = new List<EditGameRequest>();

            if (games == null)
            {
                return gameListModel;
            }

            foreach (var game in games)
            {
                gameListModel.Add(new EditGameRequest
                {
                    Id = game.Id,
                    CreatedBy = game.UserId,
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
    }
}