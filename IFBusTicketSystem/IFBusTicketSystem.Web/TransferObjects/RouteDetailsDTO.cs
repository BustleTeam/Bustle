using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class RouteDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<StationDTO> Stations { get; set; } = new List<StationDTO>();
    }
}