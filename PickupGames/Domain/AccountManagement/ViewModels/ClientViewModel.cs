using System.ComponentModel.DataAnnotations;
using PickupGames.Domain.AccountManagement.Models;

namespace PickupGames.Domain.AccountManagement.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Secret { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ApplicationType ApplicationType { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        [MaxLength(100)]
        public string AllowedOrigin { get; set; }

        public string ClientId { get; set; }
    }    
}
