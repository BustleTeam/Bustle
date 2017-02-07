namespace IFBusTicketSystem.Foundation.Types
{
    public class Seat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public Race Race { get; set; }
        public bool IsAvailable { get; set; }
    }
}
