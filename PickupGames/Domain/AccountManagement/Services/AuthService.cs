using System.Collections.Generic;
using System.Threading.Tasks;
using Ninject;
using PickupGames.Domain.AccountManagement.Models;
using PickupGames.Domain.AccountManagement.Repositories;
using PickupGames.Domain.AccountManagement.ViewModels;
using PickupGames.Infrastructure.DependencyInjector;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.AccountManagement.Services
{
    public class AuthService
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
