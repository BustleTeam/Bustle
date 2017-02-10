using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Types;
using NHibernate;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        public RouteRepository(ISession session)
            :base(session)
        {            
        }
    }
}
