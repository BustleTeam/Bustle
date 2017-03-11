﻿using System.Security.Claims;
using System.Threading.Tasks;
using IFBusTicketSystem.DAL.Interfaces;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;

namespace IFBusTicketSystem.Auth
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        [Dependency]
        public IUserRepository UserRepository { get; set; }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});

            var user = await UserRepository.FindUser(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}