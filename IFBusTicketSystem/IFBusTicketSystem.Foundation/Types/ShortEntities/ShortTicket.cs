using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class ShortTicket
    {
        public string PassengerEmail { get; set; }
        public int SeatId { get; set; }
    }
}