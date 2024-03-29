﻿using System;
using System.Net;
using System.Xml.Linq;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.Geography.Repositories.Interfaces;

namespace PickupGames.Domain.Geography.Repositories
{
    public class GeographyRepository : IGeographyRepository
    {
        public Coordinate GetCoordinates(string address)
        {
            var coordinates = new Coordinate();

            var geocoderUri = string.Format(@"http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", address);

            var request = WebRequest.Create(geocoderUri);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
                if (stream != null)
                {
                    var xdoc = XDocument.Load(stream);
                    var result = xdoc.Element("GeocodeResponse").Element("result");
                    var locationElement = result.Element("geometry").Element("location");

                    coordinates.Lat = locationElement.Element("lat").Value;
                    coordinates.Lng = locationElement.Element("lng").Value;

                    return coordinates;
                }

            return null;
        }

        public Distance DistanceBetweenCoordinates(Coordinate start, Coordinate end)
        {
            var geocoderUri =
                string.Format(
                    @"http://maps.googleapis.com/maps/api/distancematrix/xml?origins={0},{1}&destinations={2},{3}&units=imperial&mode=Car&language=us-en&sensor=false", start.Lat,start.Lng,end.Lat,end.Lng);
            
            var request = WebRequest.Create(geocoderUri);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
                if (stream != null)
                {
                    var xdoc = XDocument.Load(stream);
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

            return null;
        }
    }
}