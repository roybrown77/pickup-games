using System;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using PickupGames.Models;
using PickupGames.ViewModels;

namespace PickupGames.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<bool> AddRefreshToken(RefreshToken token);
        ClientViewModel FindClient(string clientId);
        Task<RefreshToken> FindRefreshToken(string refreshTokenId);
        Task<User> FindUserBy(string email);
        Task<User> FindUserBy(string userName, string password);
        List<RefreshToken> GetAllRefreshTokens();
        Task<ResponseResult> RegisterUser(UserViewModel userModel);
        Task<bool> RemoveRefreshToken(RefreshToken refreshToken);
        Task<bool> RemoveRefreshToken(string refreshTokenId);
    }
}
