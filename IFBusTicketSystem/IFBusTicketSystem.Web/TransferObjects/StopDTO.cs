using System.ComponentModel.DataAnnotations;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class StopDTO
    {
        public int Id { get; set; }
        [Required]
        public StationDTO Station { get; set; }
        [Required]
        public string Arrival { get; set; }
        [Required]
        public string Departure { get; set; }
        [Required]
        public RaceDTO Race { get; set; }
    }
}