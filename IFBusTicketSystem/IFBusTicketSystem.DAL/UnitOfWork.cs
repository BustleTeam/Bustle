using FluentNHibernate.Cfg;
using IFBusTicketSystem.DAL.Interfaces;
using NHibernate;

namespace IFBusTicketSystem.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private static readonly ISessionFactory SessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; } = SessionFactory.OpenSession();

        static UnitOfWork()
        {
            //TODO: Add SessionFactory configuration later (V.Y.)
            SessionFactory = Fluently.Configure().BuildSessionFactory();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}
