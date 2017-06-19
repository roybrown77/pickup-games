using System;
using PickupGames.Domain.GamePlaceManagement.Models;

namespace PickupGames.Domain.GameManagement.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public Sport Sport { get; set; }
        public string DateTime { get; set; }
        public string UserId { get; set; }
        public Location Location { get; set; }
        public int PlayerCount { get; set; }
    }
}