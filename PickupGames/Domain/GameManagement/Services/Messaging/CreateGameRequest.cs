using System;
using System.ComponentModel.DataAnnotations;

namespace PickupGames.Domain.GameManagement.Services.Messaging
{
    public class CreateGameRequest
    {
        [Required]
        public string SportId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Location { get; set; }
    }
}