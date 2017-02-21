namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class Ticket
    {
        public virtual int Id { get; set; }
        public virtual User Passenger { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
