namespace IFBusTicketSystem.Web.TransferObjects
{
    public class StopDTO
    {
        public int Id { get; set; }
        public string Station { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public string RouteName { get; set; }
    }
}