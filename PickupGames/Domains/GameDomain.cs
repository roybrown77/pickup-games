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

                return new BasicResponse();
            }
            catch (Exception ex)
            {
                return new BasicResponse
                {
                    Status = ResponseStatus.Failed,
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
                               Games = games,
                               SearchLocationLat = centerCoordinates.Lat,
                               SearchLocationLng = centerCoordinates.Lng
                           };
            }
            catch (Exception ex)
            {
                return new GameSearchResponse
                           {
                               Status = ResponseStatus.Failed,
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

                var maxDistance = gameSearchQuery.GetZoomMaxDistance();

                games = GetGamesWithinRadius(games, maxDistance);

                return new GameSearchResponse
                {
                    Games = games,
                    SearchLocationLat = centerCoordinates.Lat,
                    SearchLocationLng = centerCoordinates.Lng
                };
            }
            catch (Exception ex)
            {
                return new GameSearchResponse
                {
                    Status = ResponseStatus.Failed,
                    Message = ex.Message
                };
            }
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