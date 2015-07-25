using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using PickupGames.ViewModels;

namespace PickupGames.Repositories
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("name=AuthContext")
        {
        }

        public DbSet<ClientViewModel> Clients { get; set; }
        public DbSet<RefreshTokenViewModel> RefreshTokens { get; set; }
    }
}