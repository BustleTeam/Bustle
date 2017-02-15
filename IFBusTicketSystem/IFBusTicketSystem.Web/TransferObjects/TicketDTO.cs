namespace IFBusTicketSystem.Web.TransferObjects
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public int SeatNumber { get; set; }
        public string RouteName { get; set; }
    }
}