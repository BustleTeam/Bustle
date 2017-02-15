using IFBusTicketSystem.DAL;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.BL.Interfaces;
using Microsoft.Practices.Unity;

namespace IFBusTicketSystem.BL.Services
{
    public class RouteService : IRouteService
    {
        [Dependency]
        public UnitOfWork UnitOfWork { get; set; }

        public void CreateRoute(RouteBaseQuery query)
        {
            if (query.Route != null)
            {
                UnitOfWork.BeginTransaction();
                UnitOfWork.Routes.Create(query.Route);
                UnitOfWork.Commit();
            }
        }

        public void DeleteRoute(EntityBaseQuery query)
        {
            if (query.Id > 0)
            {
                var route = UnitOfWork.Routes.GetById(query.Id);
                if (route != null)
                {
                    UnitOfWork.BeginTransaction();
                    UnitOfWork.Routes.Delete(query.Id);
                    UnitOfWork.Commit();
                }
            }
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            var routes = UnitOfWork.Routes.GetAll().ToList();
            return routes;

        }

        public Route GetRaceRouteById(EntityBaseQuery query)
        {
            var route = UnitOfWork.Routes.GetById(query.Id);
            if (route != null)
            {
                return route;
            }
            return null;
        }

        public void UpdateRoute(RouteBaseQuery query)
        {
            if (query.Route != null)
            {
                var route = UnitOfWork.Routes.GetById(query.Id);
                if (route != null)
                {
                    UnitOfWork.BeginTransaction();
                    UnitOfWork.Routes.Update(query.Route);
                    UnitOfWork.Commit();
                }
            }
        }
    }
}
