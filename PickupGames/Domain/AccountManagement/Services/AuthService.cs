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
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService()
        {
            _authRepository = NinjectDependencyInjector.Dependencies.Get<IAuthRepository>();
        }

        public Task<bool> AddRefreshToken(RefreshToken token)
        {
            return _authRepository.AddRefreshToken(token);
        }

        public Task<User> FindUserBy(string userName, string password)
        {
            return _authRepository.FindUserBy(userName, password);
        }

        public Client FindClient(string clientId)
        {
            return _authRepository.FindClient(clientId);
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
