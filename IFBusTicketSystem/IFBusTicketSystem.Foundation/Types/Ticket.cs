namespace IFBusTicketSystem.Foundation.Types
{
    public class Ticket
    {
        public int Id { get; set; }
        public User Passenger { get; set; }
        public Seat Seat { get; set; }
    }
}
