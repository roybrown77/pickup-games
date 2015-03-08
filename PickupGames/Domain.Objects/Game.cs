using System;

namespace PickupGames.Domain.Objects
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public int PlayerCount { get; set; }
        public Distance DistanceToCenterLocation { get; set; }
        public string LocationLat { get; set; }
        public string LocationLng { get; set; }
    }
}