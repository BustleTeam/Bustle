using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
    }
}
