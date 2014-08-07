using System;
using System.ComponentModel.DataAnnotations;

namespace PickupGames.Models
{
    public class GameSearchModel
    {
        public string Name { get; set; }

        public string Sport { get; set; }

        [Display(Name = "Recurring Day")]
        public string GameDay { get; set; }

        [Display(Name = "Game Date Start")]
        public DateTime? GameDateStart { get; set; }

        [Display(Name = "Game Date End")]
        public DateTime? GameDateEnd { get; set; }

        [Display(Name = "Game Time Start")]
        public DateTime? GameTimeStart { get; set; }

        [Display(Name = "Game Time End")]
        public DateTime? GameTimeEnd { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Radius to location")]
        public string Radius { get; set; }

        [Display(Name = "Players signed up")]
        public int? PlayerCount { get; set; }

        public int? Views { get; set; }
    }
}