namespace PickupGames.Domain.Objects
{
    public class GameSearchRequest
    {
        public GamesSortBy SortBy { get; set; }
        public int Index { get; set; }
        public int NumberOfResultsPerPage { get; set; }
    }
}