using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using PickupGames.Models;

namespace PickupGames.Repositories
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("name=AuthContext")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}