using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickupGames.Domain.AccountManagement.Models;
using PickupGames.Domain.AccountManagement.ViewModels;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.AccountManagement.Repositories
{
    public class MockAuthRepository : IAuthRepository
    {
        public static List<RefreshToken> RefreshTokens = new List<RefreshToken>();
        public static List<Client> Clients = new List<Client>();
        public static List<User> Users = new List<User>();
    
        public async Task<ResponseResult> RegisterUser(UserViewModel userModel)
        {
            Users.Add(new User { Id = Guid.NewGuid().ToString(), Name = userModel.UserName, Password = userModel.Password, Email = userModel.Email, Active = true });
            return new ResponseResult { Succeeded = true };
        }

        public async Task<User> FindUserBy(string userName, string password)
        {
            foreach (var user in Users)
            {
                if (string.Equals(user.Password, password, StringComparison.CurrentCultureIgnoreCase) && string.Equals(user.Name, userName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return new User { Id = user.Id, Name = userName, Password = password };
                }
            }

            return null;
        }

        public Client FindClient(string clientId)
        {
            var client = Clients.Find(x=>x.Id == clientId);
            return client;
        }

        public async Task<User> FindUserBy(string email)
        {
            var user = Users.Find(x => x.Email == email);
            return user;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {
            var existingToken = RefreshTokens.SingleOrDefault(r => r.Subject == token.Subject && r.ClientId == token.ClientId);

            if (existingToken != null)
            {
                await RemoveRefreshToken(existingToken);
            }

            RefreshTokens.Add(token);

            return true;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            return RefreshTokens.Remove(RefreshTokens.SingleOrDefault(r => r.Id == refreshTokenId));
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            return RefreshTokens.Remove(refreshToken);
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            return RefreshTokens.SingleOrDefault(r => r.Id == refreshTokenId);
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return RefreshTokens.ToList();
        }
    }
}