using IFBusTicketSystem.Foundation.Types.ShortEntities;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class BookTicketCommand
    {
        public ShortTicket ShortTicket { get; set; }

        public BookTicketCommand(ShortTicket shortTicket)
        {
            ShortTicket = shortTicket;
        }
    }
}
