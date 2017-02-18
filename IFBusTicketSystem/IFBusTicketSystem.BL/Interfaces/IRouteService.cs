using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using System.Collections.Generic;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.BL.Interfaces
{
    public interface IRouteService
    {
        Route GetRouteById(EntityBaseQuery query);
        IEnumerable<Route> GetAllRoutes();
        void CreateRoute(RouteBaseQuery query);
        void UpdateRoute(RouteBaseQuery query);
        void DeleteRoute(EntityBaseQuery query);
    }
}
