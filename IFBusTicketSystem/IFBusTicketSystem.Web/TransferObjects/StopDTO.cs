namespace IFBusTicketSystem.Web.TransferObjects
{
    public class StopDTO
    {
        public int Id { get; set; }
        public StationDTO Station { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public RaceDTO Race { get; set; }
    }
}