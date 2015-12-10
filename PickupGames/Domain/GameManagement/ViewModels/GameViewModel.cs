using System;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Domain.GameManagement.Models;

namespace PickupGames.Domain.GameManagement.ViewModels
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