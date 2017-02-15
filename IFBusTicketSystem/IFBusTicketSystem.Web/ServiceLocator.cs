using System.Configuration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.BL.Services;
using IFBusTicketSystem.DAL;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.DAL.MappingConfiguration;
using IFBusTicketSystem.DAL.Repositories;
using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Practices.Unity;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace IFBusTicketSystem.Web
{
    public static class ServiceLocator
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        internal static IUnityContainer GetContainer
        {
            get
            {
                RegisterServices(Container);
                return Container;
            }
        }

        public static T Resolve<T>()
        {
            return GetContainer.Resolve<T>();
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<ISessionFactory>(new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationManager.ConnectionStrings["BustleDB"].ConnectionString))
                    .Mappings(_ => _.AutoMappings.Add(AutoMap.AssemblyOf<Race>(new StoreConfiguration())))
                    .ExposeConfiguration(_ => new SchemaUpdate(_).Execute(false, true))
                    .BuildSessionFactory()));

            container.RegisterType<ISession>(
                new PerRequestLifetimeManager(),
                new InjectionFactory(c => c.Resolve<ISessionFactory>().OpenSession()));

            container.RegisterType<IUnitOfWork, UnitOfWork>();

        #region Repositories

            container.RegisterType<IRaceRepository, RaceRepository>();
            container.RegisterType<IStationRepository, StationRepository>();
            container.RegisterType<IRouteRepository, RouteRepository>();
            container.RegisterType<IStopRepository, StopRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ITicketRepository, TicketRepository>();
            container.RegisterType<ISeatRepository, SeatRepository>();

        #endregion

        #region Services

            container.RegisterType<IRaceService, RaceService>();
            container.RegisterType<IRouteService, RouteService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ITicketService, TicketService>();

        #endregion
        }
    }
}