using System;
using System.ComponentModel.DataAnnotations;

namespace PickupGames.Models
{
    public class GameCreateModel
    {
        [Required]
        public string Sport { get; set; }

        [Required]
        public DateTime GameDate { get; set; }

        [Required]
        public TimeSpan GameTime { get; set; }

        [Required]
        public string Location { get; set; }
    }
}