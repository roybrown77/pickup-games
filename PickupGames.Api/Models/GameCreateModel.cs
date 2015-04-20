using System;
using System.ComponentModel.DataAnnotations;

namespace PickupGames.Api.Models
{
    public class GameCreateModel
    {
        [Required]
        public string SportId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Location { get; set; }
    }
}