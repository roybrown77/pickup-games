using System;

namespace PickupGames.Domain.GameManagement.Services.Messaging
{
    public class CreateGameRequest
    {
        public string SportId { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
    }
}