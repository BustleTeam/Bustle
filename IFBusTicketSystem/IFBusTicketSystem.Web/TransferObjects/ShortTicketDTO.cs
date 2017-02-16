namespace IFBusTicketSystem.Web.TransferObjects
{
    public class ShortTicketDTO
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int SeatId { get; set; }
        public int SeatNumber { get; set; }
    }
}