namespace IFBusTicketSystem.Web.TransferObjects
{
    public class ShortStopDTO
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
    }
}