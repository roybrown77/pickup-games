namespace PickupGames.Domain.GameManagement.Services.Messaging
{
    public class CreateGameRequest
    {
        public string SportId { get; set; }
        public string DateTime { get; set; }
        public string Location { get; set; }
        public string UserId { get; set; }
    }
}