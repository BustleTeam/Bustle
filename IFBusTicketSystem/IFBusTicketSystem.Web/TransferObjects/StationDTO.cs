using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class StationDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Locality { get; set; }
        public string Description { get; set; }
        public IEnumerable<RouteDTO> Routes { get; set; } = new List<RouteDTO>();
    }
}