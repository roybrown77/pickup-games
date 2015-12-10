using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Infrastructure;
using PickupGames.Domain.AccountManagement.Models;
using PickupGames.Domain.AccountManagement.Services;
using PickupGames.Infrastructure.Encoding;

namespace PickupGames.Domain.AccountManagement.Repositories
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context) 
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            string hashedTokenId = EncodingUtilities.GetHash(context.Token);

            var authService = new AuthService();
            var refreshToken = await authService.FindRefreshToken(hashedTokenId);

            if (refreshToken != null)
            {
                //Get protectedTicket from refreshToken class
                context.DeserializeTicket(refreshToken.ProtectedTicket);
                var result = await authService.RemoveRefreshToken(hashedTokenId);
            }
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];
 
            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }
 
            var refreshTokenId = Guid.NewGuid().ToString("n");

            var authService = new AuthService();
            
            var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime"); 
            
            var token = new RefreshToken() 
            { 
                Id = EncodingUtilities.GetHash(refreshTokenId),
                ClientId = clientid, 
                Subject = context.Ticket.Identity.Name,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime)) 
            };
 
            context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
            context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;
            
            token.ProtectedTicket = context.SerializeTicket();
 
            var result = await authService.AddRefreshToken(token);
 
            if (result)
            {
                context.SetToken(refreshTokenId);
            }
        }
    }
}