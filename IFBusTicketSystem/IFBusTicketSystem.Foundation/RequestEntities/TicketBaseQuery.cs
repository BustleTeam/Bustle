using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class TicketBaseQuery : EntityBaseQuery
    {
        public Ticket Ticket { get; set; }
    }
}
