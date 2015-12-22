//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using PickupGames.Domain.AccountManagement.Models;
//using PickupGames.Domain.AccountManagement.ViewModels;
//using PickupGames.Infrastructure.Response;

//namespace PickupGames.Domain.AccountManagement.Repositories
//{
//    public class AuthRepositoryEF : IDisposable, IAuthRepository
//    {
//        private AuthContext _ctx;
//        private UserManager<IdentityUser> _userManager;

//        public AuthRepositoryEF()
//        {
//            _ctx = new AuthContext();
//            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
//        }

//        public async Task<ResponseResult> RegisterUser(RegisterUserRequest userModel)
//        {
//            var userByEmail = await FindUserBy(userModel.Email);

//            if (userByEmail != null)
//            {
//                return new ResponseResult(); //return IdentityResult.Failed("Login info is incorrect.");
//            }

//            IdentityUser user = new IdentityUser
//            {
//                UserName = userModel.UserName,
//                Email = userModel.Email
//            };

//            var result = await _userManager.CreateAsync(user, userModel.Password);

//            return new ResponseResult 
//            {
//                Succeeded = result.Succeeded,
//                Errors = result.Errors
//            };
//        }

//        public async Task<IdentityUser> FindUserBy(string userName, string password)
//        {
//            IdentityUser user = await _userManager.FindAsync(userName, password);
            
//            if (user == null)
//            {
//                user = await _userManager.FindByEmailAsync(userName);
                
//                if (user != null)
//                {
//                    user = await _userManager.FindAsync(user.UserName, password);
//                }
//            }

//            return user;
//        }

//        public async Task<IdentityUser> FindUserBy(string email)
//        {
//            IdentityUser user = await _userManager.FindByEmailAsync(email);
//            return user;
//        }

//        public ClientViewModel FindClient(string clientId)
//        {
//            var client = _ctx.Clients.Find(clientId);

//            return client;
//        }

//        public async Task<bool> AddRefreshToken(RefreshToken token)
//        {

//            var existingToken = _ctx.RefreshTokens.SingleOrDefault(r => r.Subject == token.Subject && r.ClientId == token.ClientId);

//            if (existingToken != null)
//            {
//                var result = await RemoveRefreshToken(existingToken);
//            }

//            _ctx.RefreshTokens.Add(token);

//            return await _ctx.SaveChangesAsync() > 0;
//        }

//        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
//        {
//            var refreshToken = await _ctx.RefreshTokens.FindAsync(refreshTokenId);

//            if (refreshToken != null)
//            {
//                _ctx.RefreshTokens.Remove(refreshToken);
//                return await _ctx.SaveChangesAsync() > 0;
//            }

//            return false;
//        }

//        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
//        {
//            _ctx.RefreshTokens.Remove(refreshToken);
//            return await _ctx.SaveChangesAsync() > 0;
//        }

//        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
//        {
//            var refreshToken = await _ctx.RefreshTokens.FindAsync(refreshTokenId);

//            return refreshToken;
//        }

//        public List<RefreshToken> GetAllRefreshTokens()
//        {
//            return _ctx.RefreshTokens.ToList();
//        }

//        public void Dispose()
//        {
//            _ctx.Dispose();
//            _userManager.Dispose();
//        }
//    }
//}