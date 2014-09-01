using System;

namespace PickupGames.Domain.Objects
{
    public class SearchQuery
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
        public string NortheastLat { get; set; }
        public string NortheastLng { get; set; }
        public int Zoom { get; set; }
    }
}