using System.Collections.Generic;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.GameManagement.Models
{
    public class GameSearchResponse : ResponseBase
    {
        public string SearchLocationLat { get; set; }
        public string SearchLocationLng { get; set; }
        public List<Game> Games { get; set; }
        public List<Location> PlacesToPlayGames { get; set; }
    }
}