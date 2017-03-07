using System;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class ShortStopDTO
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string StationName { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public string RouteName { get; set; }
    }
}