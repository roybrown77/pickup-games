using System;

namespace PickupGames.Models
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public string Sport { get; set; }
        public DateTime GameDateTime { get; set; }
        public string Location { get; set; }
        public string LocationLat { get; set; }
        public string LocationLng { get; set; }
        public string DistanceToCenterLocation { get; set; }
        
        public int PlayerCount { get; set; }
        public int Views { get; set; }
        public string LocationImageUrl { get; set; }
    }
}