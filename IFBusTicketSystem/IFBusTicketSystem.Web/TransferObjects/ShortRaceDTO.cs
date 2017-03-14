using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class ShortRaceDTO
    {
        public int Id { get; set; }
        [Required]
        public string RouteName { get; set; }
        public string RouteDescription { get; set; }
        [Required]
        public string Arrival { get; set; }
        [Required]
        public string Departure { get; set; }
        [Required]
        public IEnumerable<ShortStopDTO> Stops { get; set; } = new List<ShortStopDTO>();
        [Required]
        public IEnumerable<SeatDTO> Seats { get; set; } = new List<SeatDTO>();
    }
}