using System.Collections.Generic;
using System.Threading.Tasks;
using PickupGames.Domain.AccountManagement.Models;
using PickupGames.Domain.AccountManagement.ViewModels;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.AccountManagement.Repositories
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
