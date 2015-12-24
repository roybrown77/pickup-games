using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using PickupGames.Domain.AccountManagement.Models;
using PickupGames.Domain.AccountManagement.Repositories;
using PickupGames.Domain.AccountManagement.Services.Messaging;
using PickupGames.Infrastructure.Exceptions;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.AccountManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
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

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            try
            {
                var result = await _authRepository.RemoveRefreshToken(refreshTokenId);

                if (!result)
                {
                    throw new ApplicationLayerException(HttpStatusCode.BadRequest, "Token Id was not removed for unknown reasons.");
                }


                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationLayerException(HttpStatusCode.BadRequest, "Token Id does not exist due to: " + ex.Message);
            }                        
        }

        public Task<ResponseResult> RegisterUser(RegisterUserRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.UserName,
                Password = request.Password,
                Email = request.Email,
                Active = true
            };

            return _authRepository.RegisterUser(user);
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
