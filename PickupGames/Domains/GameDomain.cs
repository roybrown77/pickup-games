using System;
using System.Collections.Generic;
using Ninject;
using PickupGames.Domain.Objects;
using PickupGames.Repositories.Interfaces;
using PickupGames.Utilities.DependencyInjector;

namespace PickupGames.Domains
{
    public class GameDomain
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGeographyRepository _geographyRepository;

        public GameDomain()
        {
            _gameRepository = NinjectDependencyInjector.Dependencies.Get<IGameRepository>();
            _geographyRepository = NinjectDependencyInjector.Dependencies.Get<IGeographyRepository>();
        }

        public BasicResponse CreateGame(Game game)
        {
            try
            {
                var coordinates = _geographyRepository.GetCoordinates(game.Location);
                game.LocationLat = coordinates.Lat;
                game.LocationLng = coordinates.Lng;

                _gameRepository.Add(game);

                return new BasicResponse
                {
                    Status = "Success"
                };
            }
            catch (Exception ex)
            {
                return new BasicResponse
                {
                    Status = "Failed",
                    Message = ex.Message
                };
            }
        }

        public GameSearchResponse FindBy(string location)
        {
            try
            {
                var centerCoordinates = _geographyRepository.GetCoordinates(location);
                
                var games = _gameRepository.FindBy(location);

                SetDistanceToCenter(games, centerCoordinates);

                return new GameSearchResponse
                           {
                               Status = "Success",
                               Games = games,
                               SearchLocationLat = centerCoordinates.Lat,
                               SearchLocationLng = centerCoordinates.Lng
                           };
            }
            catch (Exception ex)
            {
                return new GameSearchResponse
                           {
                               Status = "Failed",
                               Message = ex.Message
                           };
            }
        }

        public GameSearchResponse FindBy(GameSearchQuery gameSearchQuery)
        {
            try
            {
                var centerCoordinates = _geographyRepository.GetCoordinates(gameSearchQuery.Location);

                // get all games by state, region or country and filter down by maxDistance; must convert to formatted address if zip specified? get by zip

                var games = _gameRepository.FindBy(gameSearchQuery);
                
                SetDistanceToCenter(games, centerCoordinates);

                var maxDistance = GetMaxDistance(gameSearchQuery);

                games = GetGamesWithinRadius(games, maxDistance);

                return new GameSearchResponse
                {
                    Status = "Success",
                    Games = games,
                    SearchLocationLat = centerCoordinates.Lat,
                    SearchLocationLng = centerCoordinates.Lng
                };
            }
            catch (Exception ex)
            {
                return new GameSearchResponse
                {
                    Status = "Failed",
                    Message = ex.Message
                };
            }
        }

        private static Distance GetMaxDistance(GameSearchQuery gameSearchQuery)
        {
            var maxDistance = new Distance
            {
                Unit = "mi"
            };

            switch (gameSearchQuery.Zoom)
            {
                case 0:
                    maxDistance.Value = 10000;
                    break;
                case 1:
                    maxDistance.Value = 9000;
                    break;
                case 2:
                    maxDistance.Value = 7000;
                    break;
                case 3:
                    maxDistance.Value = 5000;
                    break;
                case 4:
                    maxDistance.Value = 2500;
                    break;
                case 5:
                    maxDistance.Value = 1500;
                    break;
                case 6:
                    maxDistance.Value = 750;
                    break;
                case 7:
                    maxDistance.Value = 500;
                    break;
                case 8:
                    maxDistance.Value = 200;
                    break;
                case 9:
                    maxDistance.Value = 100;
                    break;
                case 10:
                    maxDistance.Value = 50;
                    break;
                case 11:
                    maxDistance.Value = 25;
                    break;
                case 12:
                    maxDistance.Value = 15;
                    break;
                case 13:
                    maxDistance.Value = 7.5;
                    break;
                case 14:
                    maxDistance.Value = 3;
                    break;
                case 15:
                    maxDistance.Value = 1.5;
                    break;
                case 16:
                    maxDistance.Value = .75;
                    break;
                case 17:
                    maxDistance.Value = .5;
                    break;
                case 18:
                    maxDistance.Value = .25;
                    break;
                default:
                    maxDistance.Value = 5000;
                    break;
            }

            return maxDistance;
        }

        private List<Game> GetGamesWithinRadius(IEnumerable<Game> games, Distance maxDistance)
        {
            var newGames = new List<Game>();

            foreach (var game in games)
            {
                if (game.DistanceToCenterLocation.Value < maxDistance.Value)
                {
                    newGames.Add(game);
                }                
            }

            return newGames;
        }

        private void SetDistanceToCenter(IEnumerable<Game> games, Coordinates centerCoordinate)
        {
            foreach (var game in games)
            {
                var gameCoordinate = new Coordinates
                {
                    Lat = game.LocationLat,
                    Lng = game.LocationLng
                };

                game.DistanceToCenterLocation = _geographyRepository.DistanceBetweenCoordinates(gameCoordinate, centerCoordinate);
            }

            // must convert ft into miles
            // must consider km
            //games = games.OrderBy(x => double.Parse(x.DistanceToCenterLocation.Replace(" mi","").Replace(" km",""))).ToList();            
        }
    }
}