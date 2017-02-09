namespace IFBusTicketSystem.Foundation.Types
{
    public class Seat
    {
        public virtual int Id { get; set; }
        public virtual int Number { get; set; }
        public virtual Race Race { get; set; }
        public virtual bool IsAvailable { get; set; }
    }
}
