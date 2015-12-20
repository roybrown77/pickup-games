using System;
using System.Collections.Generic;
using Ninject;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories;
using PickupGames.Infrastructure.DependencyInjector2;
using PickupGames.Infrastructure.Geography;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.GameManagement.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGeographyService _geographyService;

        public GameService()
        {
            _gameRepository = NinjectDependencyInjector.Dependencies.Get<IGameRepository>();
            _geographyService = NinjectDependencyInjector.Dependencies.Get<IGeographyService>();
        }

        public BasicResponse CreateGame(Game game)
        {
            try
            {
                var coordinates = _geographyService.GetCoordinates(game.Location.Address);
                game.Location = new Location { Lat = coordinates.Lat, Lng = coordinates.Lng };

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

        public BasicResponse EditGame(Guid id, Game game)
        {
            try
            {
                _gameRepository.Edit(id, game);

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

        public BasicResponse DeleteGame(Guid id)
        {
            try
            {
                _gameRepository.Delete(id);

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