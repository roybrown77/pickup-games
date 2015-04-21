﻿using Microsoft.Owin.Security.OAuth;
using PickupGames.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace PickupGames.Api.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            ClaimsIdentity identity;

            using (var _repo = new AuthRepository())
            {
                var user = await _repo.FindUserBy(context.UserName, context.Password);
                
                if (user == null)
                {
                    context.SetError("invalid_grant", "Login info is incorrect.");
                    return;
                }
                else
                {
                    var userByEmail = await _repo.FindUserBy(user.Email);

                    if (userByEmail == null)
                    {
                        context.SetError("invalid_grant", "Login info is incorrect.");
                        return;
                    }
                }

                identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("username", context.UserName));
                identity.AddClaim(new Claim("userid", user.Id));
                identity.AddClaim(new Claim("role", "user"));
            }

            context.Validated(identity);
        }
    }
}