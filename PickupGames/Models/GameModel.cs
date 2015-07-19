using System;
using PickupGames.Domain.Objects;

namespace PickupGames.Models
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public Sport Sport { get; set; }
        public DateTime DateTime { get; set; }

        public Location Location { get; set; }

        public int PlayerCount { get; set; }
        public int Views { get; set; }
    }
}