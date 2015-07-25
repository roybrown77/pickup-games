using System;
using System.Net;
using System.Xml.Linq;
using PickupGames.Models;
using PickupGames.Repositories.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;
using PickupGames.Repositories.Interfaces;

namespace PickupGames.Repositories
{
    public class GoogleGeographyRepository : IGeographyRepository
    {
        public Coordinate GetCoordinates(string address)
        {
            var coordinates = new Coordinate();

            var geocoderUri = string.Format(@"http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", address);

            var request = WebRequest.Create(geocoderUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());
            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");

            coordinates.Lat = locationElement.Element("lat").Value;
            coordinates.Lng = locationElement.Element("lng").Value;
            
            return coordinates;
        }

        public Distance DistanceBetweenCoordinates(Coordinate start, Coordinate end)
        {
            var geocoderUri =
                string.Format(
                    @"http://maps.googleapis.com/maps/api/distancematrix/xml?origins={0},{1}&destinations={2},{3}&units=imperial&mode=Car&language=us-en&sensor=false", start.Lat,start.Lng,end.Lat,end.Lng);
            
            var request = WebRequest.Create(geocoderUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());
            var result = xdoc.Element("DistanceMatrixResponse").Element("row");
            var distanceElement = result.Element("element").Element("distance");
            var distance = distanceElement.Element("text").Value;

            var array = distance.Split(Convert.ToChar(" "));

            return new Distance
            {
                Value = double.Parse(array[0]),
                Unit = array[1]
            };
        }

        public List<Location> GetPlaces(GeographySearchQuery geographySearchQuery)
        {
            var locations = new List<Models.Location>();

            var request = (HttpWebRequest)WebRequest.Create("https://maps.googleapis.com/maps/api/place/textsearch/json?query=court+field+gym+park+basketball+" + geographySearchQuery.Address + "&radius=5&key=AIzaSyCx7-UeC9DGPev5LeZWCc6ikS20hZLfx6w");
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream(); 
            var streamReader = new StreamReader(stream);
            var jsonObject = JsonConvert.DeserializeObject<RootObject>(streamReader.ReadToEnd());
            var results = jsonObject.results;

            foreach (var entry in results)
            {
                locations.Add(new Models.Location
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