using System;

namespace PickupGames.Domain.Objects
{
    public class Game
    {
        public string Name { get; set; }
        public string Sport { get; set; }
        public DateTime GameTime { get; set; }
        public string Location { get; set; }
        public int PlayerCount { get; set; }
        public string DistanceToLocation { get; set; }
    }
}