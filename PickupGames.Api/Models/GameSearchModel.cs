using System;
using PickupGames.Api.Domain.Objects;

namespace PickupGames.Api.Models
{
    public class GameSearchModel
    {
        public string Sport { get; set; }
        public string GameDay { get; set; }
        public DateTime? GameDateStart { get; set; }
        public DateTime? GameDateEnd { get; set; }
        public DateTime? GameTimeStart { get; set; }
        public DateTime? GameTimeEnd { get; set; }
        public string Location { get; set; }
        public string LocationLat { get; set; }
        public string LocationLng { get; set; }
        public string Radius { get; set; }
        
        public int? PlayerCount { get; set; }
        public int? Views { get; set; }

        public GamesSortBy? SortBy { get; set; }
        public int? Index { get; set; }
        public int? NumberOfResultsPerPage { get; set; }
        public int? Zoom { get; set; }
    }
}