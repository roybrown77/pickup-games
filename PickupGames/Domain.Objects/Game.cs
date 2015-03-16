using System;

namespace PickupGames.Domain.Objects
{
    public class Game
    {
        public Guid Id { get; set; }
        public Sport Sport { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public string LocationLat { get; set; }
        public string LocationLng { get; set; }
        public Distance DistanceToCenterLocation { get; set; }

        public int PlayerCount { get; set; }
        public int Views { get; set; }
        public string LocationImageUrl { get; set; }
    }
}