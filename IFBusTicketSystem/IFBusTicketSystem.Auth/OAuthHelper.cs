using System;
using IFBusTicketSystem.Auth.Providers;
using IFBusTicketSystem.DAL.MappingConfiguration;
using Microsoft.Owin;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;

namespace IFBusTicketSystem.Auth
{
    public static class OAuthHelper
    {
        public static OAuthAuthorizationServerOptions GetOAuthServerOptions()
        {
            return new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new AuthorizationServerProvider(FluentNhibernateConfiguration.GetSessionFactory.OpenSession()),
                RefreshTokenProvider = new RefreshTokenProvider(FluentNhibernateConfiguration.GetSessionFactory.OpenSession())
            };
        }

        public static GoogleOAuth2AuthenticationOptions GetGoogleOAuthOptions()
        {
            return new GoogleOAuth2AuthenticationOptions
            {
                ClientId = "639517171655-eit8q8itemlfdv9pe1ubi7dndvs11gce.apps.googleusercontent.com",
                ClientSecret = "MSLRF8UT-hU0-86HErDsT02b",
                Provider = new GoogleAuthProvider()
            };
        }
    }
}
