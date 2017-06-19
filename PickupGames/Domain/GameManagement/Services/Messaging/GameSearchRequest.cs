namespace PickupGames.Domain.GameManagement.Services.Messaging
{
    public class GameSearchRequest
    {
        public string Location { get; set; }
        public int? Index { get; set; }        
        public int? Zoom { get; set; }
    }
}