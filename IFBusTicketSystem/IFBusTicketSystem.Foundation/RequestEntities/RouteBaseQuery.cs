using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class RouteBaseQuery : EntityBaseQuery
    {
        public Route Route { set; get; }

        public RouteBaseQuery(int id, Route route) : base(id)
        {
            Route = route;
        }

        public RouteBaseQuery(Route route)
        {
            Route = route;
        }
    }
}
