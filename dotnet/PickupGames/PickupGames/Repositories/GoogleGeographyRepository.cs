using System.Net;
using System.Xml.Linq;
using PickupGames.Domain.Objects;

namespace PickupGames.Repositories
{
    public class GoogleGeographyRepository : IGeographyRepository
    {
        public Coordinates GetCoordinates(string location)
        {
            var coordinates = new Coordinates();

            var geocoderUri = string.Format(@"http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", location);

            var request = WebRequest.Create(geocoderUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());
            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");

            coordinates.Lat = locationElement.Element("lat").Value;
            coordinates.Lng = locationElement.Element("lng").Value;
            
            return coordinates;
        }

        public string DistanceBetweenCoordinates(Coordinates start, Coordinates end)
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

            return distance;
        }
    }
}