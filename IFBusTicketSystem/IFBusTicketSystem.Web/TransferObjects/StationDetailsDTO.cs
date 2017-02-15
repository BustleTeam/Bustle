using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class StationDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Locality { get; set; }
        public string Description { get; set; }
        public IEnumerable<RouteDTO> Routes { get; set; } = new List<RouteDTO>();
    }
}