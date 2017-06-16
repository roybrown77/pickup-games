using System.Collections.Generic;

namespace PickupGames.Domain.GamePlaceManagement.Repositories.Messaging
{    
        public class GoogleMapsPlacesResponse
        {
            public List<object> html_attributions { get; set; }
            public string next_page_token { get; set; }
            public List<Result> results { get; set; }
            public string status { get; set; }
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

        public class Geometry
        {
            public GoogleMapsLocation location { get; set; }
        }

        public class GoogleMapsLocation
        {
            public double lat { get; set; }
            public double lng { get; set; }
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
}