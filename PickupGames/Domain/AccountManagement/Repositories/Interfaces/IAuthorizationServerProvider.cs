using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace PickupGames.Domain.AccountManagement.Repositories.Interfaces
{
    interface IAuthorizationServerProvider
    {
        Task GrantRefreshToken(OAuthGrantRefreshTokenContext context);
        Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context);
        Task TokenEndpoint(OAuthTokenEndpointContext context);
        Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context);
    }
}
