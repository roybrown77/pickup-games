using System;
using System.Collections.Generic;
using Ninject;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Domain.GameLocationManagement.Repositories;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Services;
using PickupGames.Infrastructure.DependencyInjector;
using PickupGames.Infrastructure.Geography;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.GameLocationManagement.Services
{
    public class GamePageViewService
    {
        private readonly IGameService _gameService;
        private readonly IGameLocationRepository _gameLocationRepository;
        private readonly IGeographyService _geographyService;        

        public GamePageViewService()
        {
            _gameService = NinjectDependencyInjector.Dependencies.Get<IGameService>();
            _gameLocationRepository = NinjectDependencyInjector.Dependencies.Get<IGameLocationRepository>();
            _geographyService = NinjectDependencyInjector.Dependencies.Get<IGeographyService>();
        }

        //public GameSearchResponse FindBy(string location)
        //{
        //    try
        //    {
        //        var centerCoordinates = _geographyUtility.GetCoordinates(location);
                
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
                var centerCoordinates = _geographyService.GetCoordinates(gameSearchQuery.Location);
                var userSavedGames = _gameService.FindBy(gameSearchQuery, centerCoordinates);
                var placesToPlayGames = GetPlacesToPlayGames(gameSearchQuery);
                
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

        public List<Location> GetPlacesToPlayGames(GameSearchQuery gameSearchQuery)
        {
            var placesToPlayGames = new List<Location>();

            placesToPlayGames = _gameLocationRepository.GetPlaces(new GeographySearchQuery { Address = gameSearchQuery.Location, Radius = gameSearchQuery.ZoomInMeters.ToString() });

            return placesToPlayGames;
        }        
    }
}