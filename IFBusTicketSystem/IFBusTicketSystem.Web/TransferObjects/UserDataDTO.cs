using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class UserDataDTO
    {
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public List<TicketInfoDTO> Tickets { get; set; } = new List<TicketInfoDTO>();
    }
}