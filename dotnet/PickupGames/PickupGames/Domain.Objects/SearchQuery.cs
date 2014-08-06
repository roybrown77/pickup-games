using System;

namespace PickupGames.Domain.Objects
{
    public class SearchQuery
    {
        public string Name { get; set; }
        public string Sport { get; set; }
        public string GameDay { get; set; }
        public DateTime? GameDateStart { get; set; }
        public DateTime? GameDateEnd { get; set; }
        public DateTime? GameTimeStart { get; set; }
        public DateTime? GameTimeEnd { get; set; }
        public string SearchLocation { get; set; }
        public string Radius { get; set; }
        public int? PlayerCount { get; set; }
        public int? Views { get; set; }
    }
}