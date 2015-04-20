using System;
using PickupGames.Api.Domain.Objects;

namespace PickupGames.Api.Models
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public Sport Sport { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public string LocationLat { get; set; }
        public string LocationLng { get; set; }
        public string DistanceToCenterLocation { get; set; }
        
        public int PlayerCount { get; set; }
        public int Views { get; set; }
        public string LocationImageUrl { get; set; }
    }
}