using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class RaceDetailsDTO
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string RouteDescription { get; set; }
        public IEnumerable<RouteDTO> Stops { get; set; } = new List<RouteDTO>();
    }
}