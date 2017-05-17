using System;
using System.Threading.Tasks;
using IFBusTicketSystem.DAL;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.DAL.MappingConfiguration;
using IFBusTicketSystem.DAL.Repositories;
using IFBusTicketSystem.Foundation.Helpers;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Owin.Security.Infrastructure;
using NHibernate;

namespace IFBusTicketSystem.Auth.Providers
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenProvider(ISession nHibernateSession = null)
        {
            var unitOfWork = new UnitOfWork
            {
                Session = nHibernateSession ?? FluentNhibernateConfiguration.GetSessionFactory.OpenSession()
            };

            _refreshTokenRepository = new RefreshTokenRepository
            {
                UnitOfWork = unitOfWork
            };
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");

            var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

            var token = new RefreshToken
            {
                Id = refreshTokenId.GetHash(),
                ClientId = clientid,
                Subject = context.Ticket.Identity.Name,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
            };

            context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
            context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

            token.ProtectedTicket = context.SerializeTicket();

            var result = _refreshTokenRepository.AddRefreshToken(token);

            if (result)
                context.SetToken(refreshTokenId);
        }

        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            return Task.Run(() => Create(context));
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin") ?? "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            string hashedTokenId = context.Token.GetHash();

            var refreshToken = _refreshTokenRepository.GetSingle(rt => rt.Id == hashedTokenId);

            if (refreshToken != null)
            {
                //Get protectedTicket from refreshToken class
                context.DeserializeTicket(refreshToken.ProtectedTicket);

                _refreshTokenRepository.Delete(hashedTokenId);
            }
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            return Task.Run(() => Receive(context));
        }
    }
}
