using IFBusTicketSystem.DAL.Interfaces;
using Microsoft.Practices.Unity;
using NHibernate;

namespace IFBusTicketSystem.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        [Dependency]
        public ISession Session { get; set; }

        private ITransaction _transaction;

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
        }

        public void Rollback()
        {
            if (_transaction != null && _transaction.IsActive)
                _transaction.Rollback();
        }
    }
}
