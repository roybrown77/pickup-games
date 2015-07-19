using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickupGames.Models;

namespace PickupGames.Repositories
{
    public class MockAuthRepository : IAuthRepository
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public MockAuthRepository()
        {
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            return new IdentityResult();
        }

        public async Task<IdentityUser> FindUserBy(string userName, string password)
        {
            return new IdentityUser();
        }

        public async Task<IdentityUser> FindUserBy(string email)
        {
            return new IdentityUser();
        }

        public Client FindClient(string clientId)
        {
            return new Client();
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {
            return true;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            return true;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            return true;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            return new RefreshToken();
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return new List<RefreshToken>();
        }

    }
}