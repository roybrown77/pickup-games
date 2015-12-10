using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace PickupGames.Domain.AccountManagement.Repositories
{
    public class MockAuthorizationServerProvider : OAuthAuthorizationServerProvider, IAuthorizationServerProvider
    {    
        public Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            return Task.FromResult<object>(null);
 	    }

        public Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.FromResult<object>(null);
 	    }

        public Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            return Task.FromResult<object>(null);
 	    }

        public Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            return Task.FromResult<object>(null);
 	    }
    }
}