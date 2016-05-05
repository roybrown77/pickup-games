using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.Owin;
using Owin;
using SportsPick;

[assembly: OwinStartup(typeof(Startup))]
namespace SportsPick
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            //config.Services.Replace(typeof(IHttpActionInvoker), new CustomHttpActionInvoker());
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
        }
    }
}