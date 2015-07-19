using System;
namespace PickupGames.Repositories
{
    interface IAuthRepository
    {
        System.Threading.Tasks.Task<bool> AddRefreshToken(PickupGames.Models.RefreshToken token);
        PickupGames.Models.Client FindClient(string clientId);
        System.Threading.Tasks.Task<PickupGames.Models.RefreshToken> FindRefreshToken(string refreshTokenId);
        System.Threading.Tasks.Task<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> FindUserBy(string email);
        System.Threading.Tasks.Task<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> FindUserBy(string userName, string password);
        System.Collections.Generic.List<PickupGames.Models.RefreshToken> GetAllRefreshTokens();
        System.Threading.Tasks.Task<Microsoft.AspNet.Identity.IdentityResult> RegisterUser(PickupGames.Models.UserModel userModel);
        System.Threading.Tasks.Task<bool> RemoveRefreshToken(PickupGames.Models.RefreshToken refreshToken);
        System.Threading.Tasks.Task<bool> RemoveRefreshToken(string refreshTokenId);
    }
}
