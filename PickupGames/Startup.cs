using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.Owin.Cors;
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
            //app.Map("/signalr", map =>
            //{
            //     Setup the CORS middleware to run before SignalR.
            //     By default this will allow all origins. You can 
            //     configure the set of origins and/or http verbs by
            //     providing a cors options with a different policy.
            //    map.UseCors(CorsOptions.AllowAll);
            //    var hubConfiguration = new HubConfiguration
            //    {
            //         You can enable JSONP by uncommenting line below.
            //         JSONP requests are insecure but some older browsers (and some
            //         versions of IE) require JSONP to work cross domain
            //         EnableJSONP = true
            //    };
            //     Run the SignalR pipeline. We're not using MapSignalR
            //     since this branch already runs under the "/signalr"
            //     path.
            //    map.RunSignalR(hubConfiguration);
            //});

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