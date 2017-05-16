using System;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Helpers;
using IFBusTicketSystem.Foundation.Types.Entities;
using NHibernate.Exceptions;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        public bool AddRefreshToken(RefreshToken token)
        {
            UnitOfWork.BeginTransaction();

            var existingToken = Session.QueryOver<RefreshToken>()
                .Where(rt => rt.Subject == token.Subject && rt.ClientId == token.ClientId)
                .SingleOrDefault();

            if (existingToken != null)
            {
                Delete(existingToken.Id);
            }
            
            Create(token);

            try
            {
                UnitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                UnitOfWork.Rollback();
                
                throw new DataException("Cannot add refresh token.", e);
            }
        }
    }
}
