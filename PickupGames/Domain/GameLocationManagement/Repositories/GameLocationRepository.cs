using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Infrastructure.Geography;

namespace PickupGames.Domain.GameLocationManagement.Repositories
{
    public class GameLocationRepository : IGameLocationRepository
    {
        public List<Location> GetPlaces(GeographySearchQuery geographySearchQuery)
        {
            var locations = new List<Location>();

            var request = (HttpWebRequest)WebRequest.Create("https://maps.googleapis.com/maps/api/place/textsearch/json?query=court+field+gym+park+basketball+" + geographySearchQuery.Address + "&radius=5&key=AIzaSyCx7-UeC9DGPev5LeZWCc6ikS20hZLfx6w");
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream(); 
            var streamReader = new StreamReader(stream);
            var jsonObject = JsonConvert.DeserializeObject<RootObject>(streamReader.ReadToEnd());
            var results = jsonObject.results;

            foreach (var entry in results)
            {
                locations.Add(new Location
                {
                    Name = entry.name,   
                    Lat = entry.geometry.location.lat.ToString(CultureInfo.InvariantCulture),
                    Lng = entry.geometry.location.lng.ToString(CultureInfo.InvariantCulture),
                    Address = entry.formatted_address
                });
            }

            return locations;
        }

        public class RepoLocation
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Geometry
        {
            public RepoLocation location { get; set; }
        }

        public class OpeningHours
        {
            public bool open_now { get; set; }
            public List<object> weekday_text { get; set; }
        }

        public class Photo
        {
            public int height { get; set; }
            public List<object> html_attributions { get; set; }
            public string photo_reference { get; set; }
            public int width { get; set; }
        }

        public class Result
        {
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string icon { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public OpeningHours opening_hours { get; set; }
            public string place_id { get; set; }
            public double rating { get; set; }
            public string reference { get; set; }
            public List<string> types { get; set; }
            public List<Photo> photos { get; set; }
        }

        public class RootObject
        {
            public List<object> html_attributions { get; set; }
            public string next_page_token { get; set; }
            public List<Result> results { get; set; }
            public string status { get; set; }
        }
    }
}