namespace IFBusTicketSystem.Web.TransferObjects
{
    public class SeatDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string RouteName { get; set; }
        public bool IsAvailable { get; set; }
    }
}