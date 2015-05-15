using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using PickupGames.Api.Models;

namespace PickupGames.Api.Repositories
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