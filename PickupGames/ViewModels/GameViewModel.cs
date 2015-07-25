using System;
using PickupGames.Models;

namespace PickupGames.ViewModels
{
    public class GameViewModel
    {
        public Guid Id { get; set; }
        public Sport Sport { get; set; }
        public DateTime DateTime { get; set; }

        public Location Location { get; set; }

        public int PlayerCount { get; set; }
        public int Views { get; set; }
    }
}