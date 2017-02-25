using System.ComponentModel.DataAnnotations;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class SeatDTO
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
    }
}