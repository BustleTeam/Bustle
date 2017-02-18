using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class TicketBaseQuery : EntityBaseQuery
    {
        public Ticket Ticket { get; set; }

        public TicketBaseQuery(int id, Ticket ticket) : base(id)
        {
            Ticket = ticket;
        }

        public TicketBaseQuery(Ticket ticket)
        {
            Ticket = ticket;
        }
    }
}
