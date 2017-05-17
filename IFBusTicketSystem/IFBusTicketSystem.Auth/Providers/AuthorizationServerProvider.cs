using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IFBusTicketSystem.DAL;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.DAL.MappingConfiguration;
using IFBusTicketSystem.DAL.Repositories;
using IFBusTicketSystem.Foundation.Helpers;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using NHibernate;
using NHibernate.AspNet.Identity;

namespace IFBusTicketSystem.Auth.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;

        public AuthorizationServerProvider(ISession nHibernateSession = null)
        {
            var session = nHibernateSession ?? FluentNhibernateConfiguration.GetSessionFactory.OpenSession();

            var unitOfWork = new UnitOfWork
            {
                Session = session
            };

            _userRepository = new UserRepository(
                new UserManager<UserInfo>(
                    new UserStore<UserInfo>(
                        session)));

            _clientRepository = new ClientRepository
            {
                UnitOfWork = unitOfWork
            };
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin") ?? "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[]{ allowedOrigin });

            var user = await _userRepository.FindUser(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("userId", user.Id));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "as:client_id", context.ClientId ?? string.Empty
                },
                {
                    "userName", context.UserName
                }
            });

            var ticket = new AuthenticationTicket(identity, properties);

            context.Validated(ticket);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId, clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                //Note: Remove the comments from the below line context.SetError, and invalidate context 
                //if you want to force sending clientId/secrects once obtain access tokens. (V.Y.)
                context.Validated();
                //context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }

            var client = _clientRepository.GetSingle(_ => _.Id == context.ClientId);

            if (client == null)
            {
                context.SetError("invalid_clientId", $"Client '{context.ClientId}' is not registered in the system.");
                return Task.FromResult<object>(null);
            }

            if (client.ApplicationType == ApplicationType.NativeConfidential)
            {
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret should be sent.");
                    return Task.FromResult<object>(null);
                }

                if (client.Secret != clientSecret.GetHash())
                {
                    context.SetError("invalid_clientId", "Client secret is invalid.");
                    return Task.FromResult<object>(null);
                }
            }

            if (!client.Active)
            {
                context.SetError("invalid_clientId", "Client is inactive.");
                return Task.FromResult<object>(null);
            }

            context.OwinContext.Set("as:clientAllowedOrigin", client.AllowedOrigin);
            context.OwinContext.Set("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }

            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }
    }
}