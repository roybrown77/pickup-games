using System;
using Ninject;
using PickupGames.Domain.GameLocationManagement.Services;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Services;
using PickupGames.Infrastructure.DependencyInjector;
using PickupGames.Infrastructure.Geography;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Controllers.GameManagement
{
    public class GamePageViewService
    {
        private readonly IGameService _gameService;
        private readonly IGeographyService _geographyService;
        private readonly IGameLocationService _gameLocationService;

        public GamePageViewService()
        {
            _geographyService = NinjectDependencyInjector.Dependencies.Get<IGeographyService>();
            _gameService = NinjectDependencyInjector.Dependencies.Get<IGameService>();
            _gameLocationService = NinjectDependencyInjector.Dependencies.Get<IGameLocationService>();            
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
                var placesToPlayGames = _gameLocationService.FindBy(gameSearchQuery);
                
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
    }
}