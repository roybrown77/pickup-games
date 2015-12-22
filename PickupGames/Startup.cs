using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Owin;
using System;
using System.Web.Http;
using PickupGames.Domain.AccountManagement.Repositories;
using PickupGames.Infrastructure.DependencyInjector2;

[assembly: OwinStartup(typeof(PickupGames.Startup))]
namespace PickupGames
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            NinjectDependencyInjector.Dependencies = new StandardKernel(NinjectDependencyFactory.Create());

            ConfigureOAuth(app);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}