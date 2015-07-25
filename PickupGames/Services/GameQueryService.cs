using System;
using System.Collections.Generic;
using Ninject;
using PickupGames.Models;
using PickupGames.Repositories.Interfaces;
using PickupGames.Utilities.DependencyInjector;

namespace PickupGames.Domains
{
    public class GameQueryService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGeographyRepository _geographyRepository;

        public GameQueryService()
        {
            _gameRepository = NinjectDependencyInjector.Dependencies.Get<IGameRepository>();
            _geographyRepository = NinjectDependencyInjector.Dependencies.Get<IGeographyRepository>();
        }

        //public GameSearchResponse FindBy(string location)
        //{
        //    try
        //    {
        //        var centerCoordinates = _geographyRepository.GetCoordinates(location);
                
        //        var games = _gameRepository.FindBy(location);

        //        SetDistanceToCenter(games, centerCoordinates);

        //        return new GameSearchResponse
        //                   {
        //                       Games = games,
        //                       SearchLocationLat = centerCoordinates.Lat,
        //                       SearchLocationLng = centerCoordinates.Lng
        //                   };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new GameSearchResponse
        //                   {
        //                       Status = ResponseStatus.Failed,
        //                       Message = ex.Message
        //                   };
        //    }
        //}

        public GameSearchResponse FindBy(GameSearchQuery gameSearchQuery)
        {
            try
            {
                var centerCoordinates = _geographyRepository.GetCoordinates(gameSearchQuery.Location);
                var userSavedGames = GetUserSavedGames(gameSearchQuery, centerCoordinates);
                var placesToPlayGames = GetPlacesToPlayGames(gameSearchQuery, centerCoordinates);
                
                return new GameSearchResponse
                {
                    Games = userSavedGames,
                    PlacesToPlayGames = placesToPlayGames,
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

        private List<Game> GetUserSavedGames(GameSearchQuery gameSearchQuery, Coordinate centerCoordinates)
        {
            // get all games by state, region or country and filter down by maxDistance; must convert to formatted address if zip specified? get by zip

            var games = _gameRepository.FindBy(gameSearchQuery);

            SetDistanceToCenter(games, centerCoordinates);

            var maxDistance = gameSearchQuery.GetZoomMaxDistance();

            games = GetGamesWithinRadius(games, maxDistance);

            return games;
        }

        private List<Location> GetPlacesToPlayGames(GameSearchQuery gameSearchQuery, Coordinate centerCoordinates)
        {
            var placesToPlayGames = new List<Location>();

            placesToPlayGames = _geographyRepository.GetPlaces(new GeographySearchQuery { Address = gameSearchQuery.Location, Radius = gameSearchQuery.ZoomInMeters.ToString()});

            return placesToPlayGames;
        }

        private List<Game> GetGamesWithinRadius(IEnumerable<Game> games, Distance maxDistance)
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

        private void SetDistanceToCenter(List<Game> games, Coordinate centerCoordinate)
        {
            foreach (var game in games)
            {
                var gameCoordinate = new Coordinate
                {
                    Lat = game.Location.Lat,
                    Lng = game.Location.Lng
                };

                game.Location.DistanceToCenterLocation = _geographyRepository.DistanceBetweenCoordinates(gameCoordinate, centerCoordinate);
            }

            // must convert ft into miles
            // must consider km
            //games = games.OrderBy(x => double.Parse(x.DistanceToCenterLocation.Replace(" mi","").Replace(" km",""))).ToList();            
        }
    }
}