using System.Web.Http;
using IFBusTicketSystem.Auth;
using IFBusTicketSystem.DAL.Interfaces;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(IFBusTicketSystem.Web.Startup))]

namespace IFBusTicketSystem.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);
            app.UseWebApi(config);
            ConfigureOAuth(app);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthHelper.GetOAuthServerOptions(ServiceLocator.Resolve<IUserRepository>()));
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
