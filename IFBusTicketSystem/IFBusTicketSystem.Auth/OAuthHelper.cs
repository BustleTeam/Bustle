using System;
using IFBusTicketSystem.DAL.Interfaces;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.ServiceLocation;

namespace IFBusTicketSystem.Auth
{
    public class OAuthHelper
    {
        public static OAuthAuthorizationServerOptions GetOAuthServerOptions(IUserRepository userRepository = null)
        {
            return new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider
                {
                    UserRepository = userRepository
                }
            };
        }
    }
}
