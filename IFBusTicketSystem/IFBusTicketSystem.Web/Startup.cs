﻿using System.Web.Http;
using IFBusTicketSystem.Auth;
using IFBusTicketSystem.Auth.Helpers;
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
          ConfigureOAuth(app);

          var config = new HttpConfiguration();
          WebApiConfig.Register(config);
     
          app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
          app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
          app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
          // Token Generation
          app.UseOAuthAuthorizationServer(OAuthHelper.GetOAuthServerOptions());
          app.UseGoogleAuthentication(OAuthHelper.GetGoogleOAuthOptions());
          app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
