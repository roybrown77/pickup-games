using System.Collections.Generic;
using System.Threading.Tasks;
using PickupGames.Domain.AccountManagement.Models;
using PickupGames.Domain.AccountManagement.Services.Messaging;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.AccountManagement.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> AddRefreshToken(RefreshToken token);
        Task<User> FindUserBy(string userName, string password);
        Client FindClient(string clientId);
        Task<bool> RemoveRefreshToken(string refreshTokenId);
        Task<ResponseResult> RegisterUser(RegisterUserRequest registerUserModel);
        List<RefreshToken> GetAllRefreshTokens();
        Task<RefreshToken> FindRefreshToken(string refreshTokenId);
    }
}
