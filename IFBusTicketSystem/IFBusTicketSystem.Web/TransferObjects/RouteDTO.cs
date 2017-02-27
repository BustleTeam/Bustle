using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class RouteDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public IEnumerable<StationDTO> Stations { get; set; } = new List<StationDTO>();
    }
}