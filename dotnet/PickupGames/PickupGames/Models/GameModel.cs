using System;
using System.ComponentModel.DataAnnotations;

namespace PickupGames.Models
{
    public class GameModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Sport { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        public string Location { get; set; }
    }
}