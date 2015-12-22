namespace PickupGames.Domain.AccountManagement.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ApplicationType ApplicationType { get; set; }
        public bool Active { get; set; }
        public bool AllowedOrigin { get; set; }
        public string RefreshTokenLifeTime { get; set; }
        public string Secret { get; set; }
    }
}