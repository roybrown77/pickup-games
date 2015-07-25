﻿using System.Collections.Generic;

namespace PickupGames.Models
{
    public class GameSearchResponse : ResponseBase
    {
        public string SearchLocationLat { get; set; }
        public string SearchLocationLng { get; set; }
        public List<Game> Games { get; set; }
        public List<Location> PlacesToPlayGames { get; set; }
    }
}