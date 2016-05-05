using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Repositories.Messaging;
using PickupGames.Domain.GamePlaceManagement.Models;
using PickupGames.Domain.GamePlaceManagement.Repositories;
using PickupGames.Domain.Geography;

namespace PickupGames.Domain.GamePlaceManagement.Services
{
    public class GamePlaceService : IGamePlaceService
    {
        private readonly IGamePlaceRepository _gamePlaceRepository;

        public GamePlaceService(IGamePlaceRepository gamePlaceRepository)
        {
            _gamePlaceRepository = gamePlaceRepository;
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

        public List<Place> FindBy(GameSearchQuery gameSearchQuery)
        {
            var placesToPlayGames = _gamePlaceRepository.GetPlaces(new GeographySearchQuery { Address = gameSearchQuery.Location, Radius = gameSearchQuery.ZoomInMeters.ToString() });
            return placesToPlayGames;
        }        
    }
}