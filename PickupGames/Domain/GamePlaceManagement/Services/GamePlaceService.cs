using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Repositories.Messaging;
using PickupGames.Domain.GamePlaceManagement.Models;
using PickupGames.Domain.GamePlaceManagement.Repositories.Interfaces;
using PickupGames.Domain.GamePlaceManagement.Services.Interfaces;
using PickupGames.Domain.Geography.Repositories.Messaging;

namespace PickupGames.Domain.GamePlaceManagement.Services
{
    public class GamePlaceService : IGamePlaceService
    {
        private readonly IGamePlaceRepository _gamePlaceRepository;

        public GamePlaceService(IGamePlaceRepository gamePlaceRepository)
        {
            _gamePlaceRepository = gamePlaceRepository;
        }

        public List<Place> FindBy(GameSearchQuery gameSearchQuery)
        {
            var placesToPlayGames = _gamePlaceRepository.GetPlaces(new GeographySearchQuery { Address = gameSearchQuery.Location, Radius = gameSearchQuery.ZoomInMeters.ToString() });
            return placesToPlayGames;
        }        
    }
}