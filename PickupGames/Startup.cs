using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using PickupGames.Domain.AccountManagement.Repositories;
//using PickupGames.Infrastructure.DependencyInjection;
using PickupGames.Infrastructure.Logging;

[assembly: OwinStartup(typeof(PickupGames.Startup))]
namespace PickupGames
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            //GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(new IoCContainer().Initialize());
            GlobalConfiguration.Configuration.MessageHandlers.Add(new MessageLoggingHandler());
            config.Services.Replace(typeof(IHttpActionInvoker), new CustomHttpActionInvoker());
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions
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