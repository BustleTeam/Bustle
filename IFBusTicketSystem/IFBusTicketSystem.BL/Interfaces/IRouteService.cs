using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using System.Collections.Generic;

namespace IFBusTicketSystem.BL.Interfaces
{
    public interface IRouteService
    {
        Route GetRaceRouteById(EntityBaseQuery query);
        IEnumerable<Route> GetAllRoutes();
        void CreateRoute(RouteBaseQuery query);
        void UpdateRoute(RouteBaseQuery query);
        void DeleteRoute(EntityBaseQuery query);
    }
}
