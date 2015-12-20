using System.Collections.Generic;
using System.Threading.Tasks;
using Ninject;
using PickupGames.Domain.AccountManagement.Models;
using PickupGames.Domain.AccountManagement.Repositories;
using PickupGames.Domain.AccountManagement.ViewModels;
using PickupGames.Infrastructure.DependencyInjector2;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.AccountManagement.Services
{
    public interface IAuthService
    {
        Task<bool> AddRefreshToken(RefreshToken token);
        ClientViewModel FindClient(string clientId);
        Task<User> FindUserBy(string userName, string password);
        Task<bool> RemoveRefreshToken(string refreshTokenId);
        Task<ResponseResult> RegisterUser(UserViewModel userModel);
        List<RefreshToken> GetAllRefreshTokens();
        Task<RefreshToken> FindRefreshToken(string refreshTokenId);
    }

    public class AuthService : IAuthService
    {
        private IAuthRepository _authRepository = null;

        public AuthService()
        {
            _authRepository = NinjectDependencyInjector.Dependencies.Get<IAuthRepository>();
        }

        public Task<bool> AddRefreshToken(RefreshToken token)
        {
            return _authRepository.AddRefreshToken(token);
        }

        public ClientViewModel FindClient(string clientId)
        {
            return _authRepository.FindClient(clientId);
        }

        public Task<User> FindUserBy(string userName, string password)
        {
            return _authRepository.FindUserBy(userName, password);
        }

        public Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            return _authRepository.RemoveRefreshToken(refreshTokenId);
        }

        public Task<ResponseResult> RegisterUser(UserViewModel userModel)
        {
            return _authRepository.RegisterUser(userModel);
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return _authRepository.GetAllRefreshTokens();
        }

        public Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            return _authRepository.FindRefreshToken(refreshTokenId);
        }
    }
}
