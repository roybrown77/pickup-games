using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using PickupGames.Repositories;
using PickupGames.Utilities;
using PickupGames.Models;
using PickupGames.ViewModels;
using PickupGames.Services;
using PickupGames.Providers;

namespace PickupGames.Providers
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