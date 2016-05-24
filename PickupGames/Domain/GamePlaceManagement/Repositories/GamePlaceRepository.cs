using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using PickupGames.Domain.GamePlaceManagement.Models;
using PickupGames.Domain.GamePlaceManagement.Repositories.Interfaces;
using PickupGames.Domain.GamePlaceManagement.Repositories.Messaging;
using PickupGames.Domain.Geography.Repositories.Messaging;

namespace PickupGames.Domain.GamePlaceManagement.Repositories
{
    public class GamePlaceRepository : IGamePlaceRepository
    {
        public List<Place> GetPlaces(GeographySearchQuery geographySearchQuery)
        {
            var places = new List<Place>();

            var request = (HttpWebRequest)WebRequest.Create("https://maps.googleapis.com/maps/api/place/textsearch/json?query=court+field+gym+park+basketball+" + geographySearchQuery.Address + "&radius=5&key=AIzaSyCx7-UeC9DGPev5LeZWCc6ikS20hZLfx6w");

            using (var response = (HttpWebResponse) request.GetResponse())
            using (var stream = response.GetResponseStream())
                if (stream != null)
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var jsonObject = JsonConvert.DeserializeObject<GoogleMapsPlacesResponse>(streamReader.ReadToEnd());
                        var results = jsonObject.results;

                        places.AddRange(results.Select(entry => new Place
                        {
                            Name = entry.name,
                            Address = entry.formatted_address,
                            Location = new Location() { Lat = entry.geometry.location.lat.ToString(CultureInfo.InvariantCulture), Lng = entry.geometry.location.lng.ToString(CultureInfo.InvariantCulture)},                            
                        }));

                        return places;
                    }
                }

            return new List<Place>();
        }
    }
}