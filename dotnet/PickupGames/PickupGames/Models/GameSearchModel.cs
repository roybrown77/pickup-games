using System;
using System.ComponentModel.DataAnnotations;

namespace PickupGames.Models
{
    public class GameSearchModel
    {
        public string Name { get; set; }

        public string Sport { get; set; }

        [Display(Name = "Game Time")]
        public DateTime GameTime { get; set; }

        public string Location { get; set; }

        [Display(Name = "Radius to location")]
        public string Radius { get; set; }

        [Display(Name = "Players signed up")]
        public int PlayerCount { get; set; }
    }
}