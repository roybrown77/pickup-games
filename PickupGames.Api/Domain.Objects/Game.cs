using System;

namespace PickupGames.Api.Domain.Objects
{
    public class Game
    {
        public Guid Id { get; set; }
        public Sport Sport { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }

        public Location Location { get; set; }

        public int PlayerCount { get; set; }
        public int Views { get; set; }
    }
}