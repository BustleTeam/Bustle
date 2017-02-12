using System.Configuration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.DAL.MappingConfiguration;
using IFBusTicketSystem.Foundation.Types;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

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
            SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationManager.ConnectionStrings["BustleDB"].ConnectionString))
                .Mappings(_ => _.AutoMappings.Add(AutoMap.AssemblyOf<Race>(new StoreConfiguration())))
                .ExposeConfiguration(_ => new SchemaUpdate(_).Execute(false, true))
                .BuildSessionFactory();
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
