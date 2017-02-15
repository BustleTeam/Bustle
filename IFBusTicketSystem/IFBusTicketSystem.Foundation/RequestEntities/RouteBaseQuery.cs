using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class RouteBaseQuery : EntityBaseQuery
    {
        public Route Route { set; get; }
    }
}
