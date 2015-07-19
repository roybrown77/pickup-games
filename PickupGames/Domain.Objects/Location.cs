using System;

namespace PickupGames.Domain.Objects
{
    public class Location
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public Distance DistanceToCenterLocation { get; set; }
        public string ImageUrl { get; set; }
    }
}