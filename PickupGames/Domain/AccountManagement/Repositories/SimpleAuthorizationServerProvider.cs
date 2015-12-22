using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using PickupGames.Domain.AccountManagement.Models;
using PickupGames.Domain.AccountManagement.Services;
using PickupGames.Infrastructure.Encoding;

namespace PickupGames.Domain.AccountManagement.Repositories
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider, IAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            var clientId = string.Empty;
            var clientSecret = string.Empty;
            
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                //Remove the comments from the below line context.SetError, and invalidate context 
                //if you want to force sending clientId/secrects once obtain access tokens. 
                context.Validated();
                //context.SetError("invalid_clientId", "ClientId should be sent.");
                return;
            }

            var authService = new AuthService(new MockAuthRepository());
            var client = authService.FindClient(context.ClientId);
            
            if (client == null)
            {
                context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
                return;
            }

            if (client.ApplicationType == ApplicationType.NativeConfidential)
            {
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret should be sent.");
                    return;
                }
                
                if (client.Secret != EncodingUtilities.GetHash(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret is invalid.");
                    return;
                }
            }

            if (!client.Active)
            {
                context.SetError("invalid_clientId", "Client is inactive.");
                return;
            }

            context.OwinContext.Set("as:clientAllowedOrigin", client.AllowedOrigin);
            context.OwinContext.Set("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            context.Validated();            
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin") ?? "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var authService = new AuthService(new MockAuthRepository());
            var user = await authService.FindUserBy(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("username", context.UserName));
            identity.AddClaim(new Claim("userid", user.Id));
            identity.AddClaim(new Claim("role", "user"));
            
            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { 
                        "as:client_id", context.ClientId ?? string.Empty
                    },
                    { 
                        "userName", context.UserName
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }
            
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }
    }
}