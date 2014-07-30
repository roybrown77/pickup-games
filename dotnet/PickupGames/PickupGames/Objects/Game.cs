using System;

namespace PickupGames.Objects
{
    public class Game
    {
        public string Name { get; set; }
        public string Sport { get; set; }
        public DateTime StartTime { get; set; }
        public string Location { get; set; }
        public int PlayerCount { get; set; }
        public string DistanceToLocation { get; set; }
    }
}