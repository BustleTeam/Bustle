using IFBusTicketSystem.DAL.Interfaces;
using Microsoft.Practices.Unity;
using NHibernate;

namespace IFBusTicketSystem.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private ITransaction _transaction;

        [Dependency]
        public ISession Session { get; set; }
        [Dependency]
        public IRaceRepository Races { get; set; }
        [Dependency]
        public IRouteRepository Routes { get; set; }
        [Dependency]
        public ISeatRepository Seats { get; set; }
        [Dependency]
        public IStationRepository Stations { get; set; }
        [Dependency]
        public IStopRepository Stops { get; set; }
        [Dependency]
        public ITicketRepository Tickets { get; set; }
        [Dependency]
        public IUserRepository Users { get; set; }

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
