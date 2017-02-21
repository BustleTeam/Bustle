using IFBusTicketSystem.Foundation.RequestEntities;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Practices.Unity;
using IFBusTicketSystem.DAL.Interfaces;

namespace IFBusTicketSystem.BL.Services
{
    public class RouteService : IRouteService
    {
        [Dependency]
        public IRouteRepository Routes { get; set; }

        public void CreateRoute(RouteBaseQuery query)
        {
            if (query.Route != null)
            {
                Routes.Create(query.Route);
            }
        }

        public void DeleteRoute(EntityBaseQuery query)
        {
            if (query.Id > 0)
            {
                var route = Routes.GetById(query.Id);
                if (route != null)
                {
                    Routes.Delete(query.Id);
                }
            }
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            return Routes.GetAll().ToList();
        }

        public Route GetRouteById(EntityBaseQuery query)
        {
            return Routes.GetById(query.Id);
        }

        public void UpdateRoute(RouteBaseQuery query)
        {
            if (query.Route != null)
            {
                var route = Routes.GetById(query.Id);
                if (route != null)
                {
                    Routes.Update(query.Route);
                }
            }
        }
    }
}
