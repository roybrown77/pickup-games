using System;
using System.ComponentModel.DataAnnotations;

namespace PickupGames.Models
{
    public class GameModel
    {
        public string Name { get; set; }

        public string Sport { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        public object Location { get; set; }
    }
}