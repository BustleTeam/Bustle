using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Types;
using NHibernate;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class RaceRepository : Repository<Race>, IRaceRepository
    {
        public RaceRepository(ISession session)
            : base(session)
        {
        }
    }
}
