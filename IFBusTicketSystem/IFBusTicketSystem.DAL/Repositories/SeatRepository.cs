using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.Foundation.Types.Entities;
using NHibernate;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class SeatRepository : Repository<Seat>, ISeatRepository
    {
    }
}
