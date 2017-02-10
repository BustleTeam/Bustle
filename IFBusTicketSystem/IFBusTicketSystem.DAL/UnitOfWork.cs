using FluentNHibernate.Cfg;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.DAL.Repositories;
using NHibernate;

namespace IFBusTicketSystem.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private static readonly ISessionFactory SessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; } = SessionFactory.OpenSession();

        public IRaceRepository Races { get; private set; }
        public IRouteRepository Routes { get; private set; }
        public ISeatRepository Seats { get; private set; }
        public IStationRepository Stations { get; private set; }
        public IStopRepository Stops { get; private set; }
        public ITicketRepository Tickets { get; private set; }
        public IUserRepository Users { get; private set; }

        static UnitOfWork()
        {
            //TODO: Add SessionFactory configuration later (V.Y.)
            SessionFactory = Fluently.Configure().BuildSessionFactory();            
        }

        public UnitOfWork()
        {
            Races = new RaceRepository(Session);
            Routes = new RouteRepository(Session);
            Seats = new SeatRepository(Session);
            Stations = new StationRepository(Session);
            Stops = new StopRepository(Session);
            Tickets = new TicketRepository(Session);
            Users = new UserRepository(Session);
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
