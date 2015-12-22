//using System.Data.Entity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using PickupGames.Domain.AccountManagement.ViewModels;

//namespace PickupGames.Domain.AccountManagement.Repositories
//{
//    public class AuthContext : IdentityDbContext<IdentityUser>
//    {
//        public AuthContext()
//            : base("name=AuthContext")
//        {
//        }

//        public DbSet<ClientViewModel> Clients { get; set; }
//        public DbSet<RefreshTokenViewModel> RefreshTokens { get; set; }
//    }
//}