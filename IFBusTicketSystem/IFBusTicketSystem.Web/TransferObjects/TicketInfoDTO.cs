namespace IFBusTicketSystem.Web.TransferObjects
{
    public class TicketInfoDTO
    {
        public int TicketId { get; set; }
        public string RaceName { get; set; }
        public int SeatNumber { get; set; }
        public string PassengerName { get; set; }
    }
}