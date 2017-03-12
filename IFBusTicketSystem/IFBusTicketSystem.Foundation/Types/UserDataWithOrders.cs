using System.Collections.Generic;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Foundation.Types
{
    public class UserDataWithOrders
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Ticket> Orders { get; set; } = new List<Ticket>();
    }
}
