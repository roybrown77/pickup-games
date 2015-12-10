using System.Collections.Generic;
using Ninject;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Domain.GameLocationManagement.Repositories;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Infrastructure.DependencyInjector;
using PickupGames.Infrastructure.Geography;

namespace PickupGames.Domain.GameLocationManagement.Services
{
    public class GameLocationService : IGameLocationService
    {
        private readonly IGameLocationRepository _gameLocationRepository;        

        public GameLocationService()
        {
            _gameLocationRepository = NinjectDependencyInjector.Dependencies.Get<IGameLocationRepository>();
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

        public List<Location> FindBy(GameSearchQuery gameSearchQuery)
        {
            var placesToPlayGames = _gameLocationRepository.GetPlaces(new GeographySearchQuery { Address = gameSearchQuery.Location, Radius = gameSearchQuery.ZoomInMeters.ToString() });
            return placesToPlayGames;
        }        
    }
}