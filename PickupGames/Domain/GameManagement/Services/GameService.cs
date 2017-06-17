using System;
using System.Collections.Generic;
using System.Net;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories.Interfaces;
using PickupGames.Domain.GameManagement.Repositories.Messaging;
using PickupGames.Domain.GameManagement.Services.Interfaces;
using PickupGames.Domain.GameManagement.Services.Messaging;
using PickupGames.Domain.GamePlaceManagement.Models;
using PickupGames.Domain.Geography.Repositories.Interfaces;
using PickupGames.Infrastructure.Exceptions;

namespace PickupGames.Domain.GameManagement.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGeographyRepository _geographyRepository;

        public GameService(IGameRepository gameRepository, IGeographyRepository geographyRepository)
        {
            _gameRepository = gameRepository;
            _geographyRepository = geographyRepository;
        }

        public void CreateGame(CreateGameRequest request)
        {
            try
            {
                var coordinates = _geographyRepository.GetCoordinates(request.Location);

                var game = new Game
                {
                    Id = Guid.NewGuid(),
                    Sport = new Sport { Id = request.SportId },
                    DateTime = request.DateTime,
                    Location = new Location { Address = request.Location, Lat = coordinates.Lat, Lng = coordinates.Lng },
                    UserId = request.UserId                    
                };
                                
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
                _gameRepository.Save(id, game);
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

            games = games.GetGamesWithinRadius(maxDistance);

            return games;
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