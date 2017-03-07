using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.BL.Services;
using IFBusTicketSystem.DAL;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.DAL.MappingConfiguration;
using IFBusTicketSystem.DAL.Repositories;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using NHibernate;
using NHibernate.AspNet.Identity;

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
                new InjectionFactory(c => FluentNhibernateConfiguration.GetSessionFactory));

            container.RegisterType<ISession>(new PerResolveLifetimeManager(), new InjectionFactory(c => c.Resolve<ISessionFactory>().OpenSession()));

            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());

        #region Repositories

            container.RegisterType<IRaceRepository, RaceRepository>(new PerResolveLifetimeManager());
            container.RegisterType<IStationRepository, StationRepository>(new PerResolveLifetimeManager());
            container.RegisterType<IRouteRepository, RouteRepository>(new PerResolveLifetimeManager());
            container.RegisterType<IStopRepository, StopRepository>(new PerResolveLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new PerResolveLifetimeManager(),
                new InjectionConstructor(new UserManager<UserInfo>(new UserStore<UserInfo>(container.Resolve<ISession>()))));
            container.RegisterType<ITicketRepository, TicketRepository>(new PerResolveLifetimeManager());
            container.RegisterType<ISeatRepository, SeatRepository>(new PerResolveLifetimeManager());

        #endregion

        #region Services

            container.RegisterType<IRaceService, RaceService>(new PerResolveLifetimeManager());
            container.RegisterType<IRouteService, RouteService>(new PerResolveLifetimeManager());
            container.RegisterType<IUserService, UserService>(new PerResolveLifetimeManager());
            container.RegisterType<ITicketService, TicketService>(new PerResolveLifetimeManager());

            container.RegisterType<IValidationService, ValidationService>(new PerResolveLifetimeManager());

            #endregion
        }
    }
}