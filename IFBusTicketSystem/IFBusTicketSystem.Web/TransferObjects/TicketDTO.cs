using System.ComponentModel.DataAnnotations;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class TicketDTO
    {
        public int Id { get; set; }
        [Required]
        public UserDTO Passenger { get; set; }
        [Required]
        public SeatDTO Seat { get; set; }
    }
}