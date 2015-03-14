using System;
using System.ComponentModel.DataAnnotations;

namespace PickupGames.Models
{
    public class GameCreateModel
    {
        [Required]
        public Guid SportId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Location { get; set; }
    }
}