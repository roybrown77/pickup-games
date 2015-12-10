using System;

namespace PickupGames.Domain.GameManagement.Models
{
    public class GameSearchQuery
    {
        private int _index = 1;

        public string Name { get; set; }
        public string Sport { get; set; }
        public string GameDay { get; set; }
        public DateTime? GameDateStart { get; set; }
        public DateTime? GameDateEnd { get; set; }
        public DateTime? GameTimeStart { get; set; }
        public DateTime? GameTimeEnd { get; set; }
        public string Location { get; set; }
        public string Radius { get; set; }
        public int? PlayerCount { get; set; }
        public int? Views { get; set; }
        public GamesSortBy SortBy { get; set; }

        public int Index {
            get { return _index; }
            set { _index = value; }
        }

        public int NumberOfResultsPerPage { get; set; }
        public int Zoom { get; set; }
        
        public double ZoomInMeters 
        {
            get { return GetZoomMaxDistance().Value*1609.34; }
        }

        public Distance GetZoomMaxDistance()
        {
            var maxDistance = new Distance
            {
                Unit = "mi"
            };

            switch (Zoom)
            {
                case 0:
                    maxDistance.Value = 10000;
                    break;
                case 1:
                    maxDistance.Value = 9000;
                    break;
                case 2:
                    maxDistance.Value = 7000;
                    break;
                case 3:
                    maxDistance.Value = 5000;
                    break;
                case 4:
                    maxDistance.Value = 2500;
                    break;
                case 5:
                    maxDistance.Value = 1500;
                    break;
                case 6:
                    maxDistance.Value = 750;
                    break;
                case 7:
                    maxDistance.Value = 500;
                    break;
                case 8:
                    maxDistance.Value = 200;
                    break;
                case 9:
                    maxDistance.Value = 100;
                    break;
                case 10:
                    maxDistance.Value = 50;
                    break;
                case 11:
                    maxDistance.Value = 25;
                    break;
                case 12:
                    maxDistance.Value = 15;
                    break;
                case 13:
                    maxDistance.Value = 7.5;
                    break;
                case 14:
                    maxDistance.Value = 3;
                    break;
                case 15:
                    maxDistance.Value = 1.5;
                    break;
                case 16:
                    maxDistance.Value = .75;
                    break;
                case 17:
                    maxDistance.Value = .5;
                    break;
                case 18:
                    maxDistance.Value = .25;
                    break;
                default:
                    maxDistance.Value = 5000;
                    break;
            }

            return maxDistance;
        }
    }
}