using PickupGames.Domain.GameManagement.Models;

namespace PickupGames.Domain.GamePlaceManagement.Models
{
    public class Place
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Location Location { get; set; }
        public Distance DistanceToCenterLocation { get; set; }
        public string ImageUrl { get; set; }
    }
}