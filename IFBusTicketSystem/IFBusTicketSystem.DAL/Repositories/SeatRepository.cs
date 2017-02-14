using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Types;
using NHibernate;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class SeatRepository : Repository<Seat>, ISeatRepository
    {
    }
}
