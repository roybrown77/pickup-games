using System;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Domain.GameManagement.Models;

namespace PickupGames.Domain.GameManagement.Services.Messaging
{
    public class EditGameRequest
    {
        public Guid Id { get; set; }
        public Sport Sport { get; set; }
        public DateTime DateTime { get; set; }

        public Location Location { get; set; }

        public int PlayerCount { get; set; }
        public int Views { get; set; }
        public string CreatedBy { get; set; }
    }
}