using System;
using System.Net;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories.Messaging;
using PickupGames.Domain.GameManagement.Services;
using PickupGames.Domain.GamePlaceManagement.Services;
using PickupGames.Infrastructure.Exceptions;
using PickupGames.Infrastructure.Geography;

namespace PickupGames.Controllers.GameManagement
{
    public class GamePageViewService : IGamePageViewService
    {
        private readonly IGameService _gameService;
        private readonly IGeographyService _geographyService;
        private readonly IGamePlaceService _gamePlaceService;

        public GamePageViewService(IGeographyService geographyService, IGameService gameService, IGamePlaceService gamePlaceService)
        {
            _geographyService = geographyService;
            _gameService = gameService;
            _gamePlaceService = gamePlaceService;            
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
                var placesToPlayGames = _gamePlaceService.FindBy(gameSearchQuery);
                
                return new GameSearchResponse
                {
                    Games = userSavedGames,
                    PlacesToPlayGames = placesToPlayGames,
                    //SearchLocationLat = centerCoordinates.Lat,
                    //SearchLocationLng = centerCoordinates.Lng
                };
            }
            catch (Exception ex)
            {
                throw new ApplicationLayerException(HttpStatusCode.InternalServerError, "Unable to get games: due to" + ex.Message);
            }
        }       
    }
}