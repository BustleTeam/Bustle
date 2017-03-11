namespace IFBusTicketSystem.Foundation.Types.ShortEntities
{
    public class ShortStop
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string StationName { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public string RouteName { get; set; }
    }
}