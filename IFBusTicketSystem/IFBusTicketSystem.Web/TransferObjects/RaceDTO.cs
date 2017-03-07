using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class RaceDTO
    {
        public int Id { get; set; }
        [Required]
        public RouteDTO Route { get; set; }
        [Required]
        public string Arrival { get; set; }
        [Required]
        public string Departure { get; set; }
        [Required]
        public IEnumerable<StopDTO> Stops { get; set; } = new List<StopDTO>();
        [Required]
        public IEnumerable<SeatDTO> Seats { get; set; } = new List<SeatDTO>();
    }
}