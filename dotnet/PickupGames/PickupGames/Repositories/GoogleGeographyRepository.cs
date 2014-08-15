using System.Xml;
using PickupGames.Domain.Objects;

namespace PickupGames.Repositories
{
    public class GoogleGeographyRepository : IGeographyRepository
    {
        //private void GetCoordinates(string street, string city, string zipcode, string state)
        public Coordinates GetCoordinates(string location)
        {
            var coordinates = new Coordinates();

            //var geocoderUri = string.Format(@"http://maps.googleapis.com/maps/api/geocode/xml?address={0},{1},{2},{3}&sensor=false", street, city, zipcode, state);
            var geocoderUri = string.Format(@"http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", location);
            var geocoderXmlDoc = new XmlDocument();
            geocoderXmlDoc.Load(geocoderUri);
            var nsMgr = new XmlNamespaceManager(geocoderXmlDoc.NameTable);
            nsMgr.AddNamespace("geo", @"http://www.w3.org/2003/01/geo/wgs84_pos#");
            coordinates.Lat = geocoderXmlDoc.DocumentElement.SelectSingleNode(@"//geometry/location/lat", nsMgr).InnerText;
            coordinates.Lng = geocoderXmlDoc.DocumentElement.SelectSingleNode(@"//geometry/location/lng", nsMgr).InnerText;
            
            return coordinates;
        }
    }
}