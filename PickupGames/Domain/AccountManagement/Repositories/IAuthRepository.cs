using System.Collections.Generic;
using System.Threading.Tasks;
using PickupGames.Domain.AccountManagement.Models;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.AccountManagement.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> AddRefreshToken(RefreshToken token);
        Task<RefreshToken> FindRefreshToken(string refreshTokenId);
        Task<User> FindUserBy(string email);
        Task<User> FindUserBy(string userName, string password);
        Client FindClient(string clientId);
        List<RefreshToken> GetAllRefreshTokens();
        Task<ResponseResult> RegisterUser(User user);
        Task<bool> RemoveRefreshToken(RefreshToken refreshToken);
        Task<bool> RemoveRefreshToken(string refreshTokenId);
    }
}
