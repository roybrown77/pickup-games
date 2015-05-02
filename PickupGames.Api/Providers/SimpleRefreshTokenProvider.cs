using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using PickupGames.Api.Repositories;
using PickupGames.Api.Repositories.Models;
using PickupGames.Api.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace PickupGames.Api.Providers
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

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context) 
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];
 
            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }
 
            var refreshTokenId = Guid.NewGuid().ToString("n");
 
            using (AuthRepository _repo = new AuthRepository())
            {
                var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime"); 
               
                var token = new RefreshToken() 
                { 
                    Id = Helpers.GetHash(refreshTokenId),
                    ClientId = clientid, 
                    Subject = context.Ticket.Identity.Name,
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime)) 
                };
 
                context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;
                
                token.ProtectedTicket = context.SerializeTicket();
 
                var result = await _repo.AddRefreshToken(token);
 
                if (result)
                {
                    context.SetToken(refreshTokenId);
                }
             
            }
        }
    }
}