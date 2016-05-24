using System.Collections.Generic;
using PickupGames.Domain.GamePlaceManagement.Models;
using PickupGames.Domain.GamePlaceManagement.Repositories.Interfaces;
using PickupGames.Domain.Geography.Repositories.Messaging;

namespace PickupGames.Domain.GamePlaceManagement.Repositories
{
    public class MockGamePlaceRepository : IGamePlaceRepository
    {
        public List<Place> GetPlaces(GeographySearchQuery geographySearchQuery)
        {
            var places = new List<Place>();

            var place = new Place
            {
                Name= "Home",
                Address = "194 College Farm Rd, Waltham, MA 02451",
                Location = new Location { Lat = "42.402079", Lng= "-71.241115" }
            };

            places.Add(place);

            place = new Place
            {
                Name = "Brandeis",
                Address = "415 South Street, Waltham, MA 02453",
                Location = new Location { Lat = "32.093349", Lng = "34.787169" }
            };

            places.Add(place);
            return places;
        }        
    }
}