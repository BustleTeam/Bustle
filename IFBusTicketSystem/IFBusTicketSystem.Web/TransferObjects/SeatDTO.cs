using System.ComponentModel.DataAnnotations;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class SeatDTO
    {
        public int Id { get; set; }
        [Range(0, 200)]
        public int Number { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
    }
}