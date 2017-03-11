using IFBusTicketSystem.Web.TransferObjects;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class BookTicketQuery : EntityBaseQuery
    {
        public ShortTicket ShortTicket { get; set; }

        public BookTicketQuery(ShortTicket shortTicket)
        {
            ShortTicket = shortTicket;
        }
    }
}
