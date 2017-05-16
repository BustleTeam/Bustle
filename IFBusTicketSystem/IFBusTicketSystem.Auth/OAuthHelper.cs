using System;
using IFBusTicketSystem.DAL.MappingConfiguration;
using Microsoft.Owin;
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
    }
}
