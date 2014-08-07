using System;
using System.ComponentModel.DataAnnotations;

namespace PickupGames.Models
{
    public class GameCreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Sport { get; set; }

        [Required]
        [Display(Name = "Game Date")]
        public DateTime GameDate { get; set; }

        [Required]
        [Display(Name = "Game Time")]
        public TimeSpan GameTime { get; set; }

        [Required]
        public string Location { get; set; }

        [Display(Name = "Recurring Day")]
        public string RecurringDay { get; set; }

        public TimeSpan Duration { get; set; }

        public string Status { get; set; }

        [Display(Name = "Age Group")]
        public string AgeGroup { get; set; }

        public string Notes { get; set; }
    }
}