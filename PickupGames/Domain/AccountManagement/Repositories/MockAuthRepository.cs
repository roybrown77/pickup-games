using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PickupGames.Domain.AccountManagement.Models;
using PickupGames.Domain.AccountManagement.ViewModels;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.AccountManagement.Repositories
{
    public class MockAuthRepository : IAuthRepository
    {
        private AuthContext _ctx;
        private UserManager<IdentityUser> _userManager;

        public async Task<ResponseResult> RegisterUser(UserViewModel userModel)
        {
            return new ResponseResult { Succeeded = true };
        }

        public async Task<User> FindUserBy(string userName, string password)
        {
            return new User { Id = "1", Name = userName, Password = password };
        }

        public async Task<User> FindUserBy(string email)
        {
            return new User();
        }

        public ClientViewModel FindClient(string clientId)
        {
            return new ClientViewModel { ClientId = clientId, Active = true };
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