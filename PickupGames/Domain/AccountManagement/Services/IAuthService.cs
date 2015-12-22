using System.Collections.Generic;
using System.Threading.Tasks;
using PickupGames.Domain.AccountManagement.Models;
using PickupGames.Domain.AccountManagement.ViewModels;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.AccountManagement.Services
{
    public interface IAuthService
    {
        Task<bool> AddRefreshToken(RefreshToken token);
        Task<User> FindUserBy(string userName, string password);
        Client FindClient(string clientId);
        Task<bool> RemoveRefreshToken(string refreshTokenId);
        Task<ResponseResult> RegisterUser(UserViewModel userModel);
        List<RefreshToken> GetAllRefreshTokens();
        Task<RefreshToken> FindRefreshToken(string refreshTokenId);
    }
}
