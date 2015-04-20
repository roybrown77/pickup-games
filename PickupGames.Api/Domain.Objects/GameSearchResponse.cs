using System.Collections.Generic;

namespace PickupGames.Api.Domain.Objects
{
    public class GameSearchResponse : ResponseBase
    {
        public string SearchLocationLat { get; set; }
        public string SearchLocationLng { get; set; }
        public List<Game> Games { get; set; }
    }
}