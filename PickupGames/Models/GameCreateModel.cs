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
        public DateTime GameDate { get; set; }

        [Required]
        public TimeSpan GameTime { get; set; }

        [Required]
        public string Location { get; set; }

        public string RecurringDay { get; set; }
        public TimeSpan Duration { get; set; }
        public string Status { get; set; }
        public string AgeGroup { get; set; }
        public string Notes { get; set; }
    }
}