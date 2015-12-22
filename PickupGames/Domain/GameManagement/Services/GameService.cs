using System;
using System.Collections.Generic;
using System.Net;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories;
using PickupGames.Domain.GameManagement.Repositories.Messaging;
using PickupGames.Infrastructure.Exceptions;
using PickupGames.Infrastructure.Geography;

namespace PickupGames.Domain.GameManagement.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGeographyService _geographyService;

        public GameService(IGameRepository gameRepository, IGeographyService geographyService)
        {
            _gameRepository = gameRepository;
            _geographyService = geographyService;
        }

        public void CreateGame(Game game)
        {
            try
            {
                var coordinates = _geographyService.GetCoordinates(game.Location.Address);
                game.Location = new Location { Lat = coordinates.Lat, Lng = coordinates.Lng };

                _gameRepository.Add(game);                
            }
            catch (Exception ex)
            {
                throw new ApplicationLayerException(HttpStatusCode.InternalServerError, "Unable to create game due to: " + ex.Message);
            }
        }

        public void EditGame(Guid id, Game game)
        {
            try
            {
                _gameRepository.Edit(id, game);
            }
            catch (Exception ex)
            {
                throw new ApplicationLayerException(HttpStatusCode.InternalServerError, "Unable to update game due to: " + ex.Message);
            }
        }

        public void DeleteGame(Guid id)
        {
            try
            {
                _gameRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationLayerException(HttpStatusCode.InternalServerError, "Unable to delete game due to: " + ex.Message);
            }
        }

        public List<Game> FindBy(GameSearchQuery gameSearchQuery, Coordinate centerCoordinates)
        {
            // get all games by state, region or country and filter down by maxDistance; must convert to formatted address if zip specified? get by zip

            var games = _gameRepository.FindBy(gameSearchQuery);

            SetDistanceToCenter(games, centerCoordinates);

            var maxDistance = gameSearchQuery.GetZoomMaxDistance();

            games = GetGamesWithinRadius(games, maxDistance);

            return games;
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

                game.Location.DistanceToCenterLocation = _geographyService.DistanceBetweenCoordinates(gameCoordinate, centerCoordinate);
            }

            // must convert ft into miles
            // must consider km
            //games = games.OrderBy(x => double.Parse(x.DistanceToCenterLocation.Replace(" mi","").Replace(" km",""))).ToList();            
        }
    }
}