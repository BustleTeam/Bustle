using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Web.TransferObjects
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