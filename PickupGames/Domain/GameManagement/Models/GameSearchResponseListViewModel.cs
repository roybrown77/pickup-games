using System.Collections.Generic;
using PickupGames.Domain.GamePlaceManagement.Models;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.GameManagement.Models
{
    public class GameSearchResponseListViewModel : ResponseBase
    {
        public string SearchLocationLat { get; set; }
        public string SearchLocationLng { get; set; }
        public List<Game> Games { get; set; }
        public List<Place> PlacesToPlayGames { get; set; }
    }
}