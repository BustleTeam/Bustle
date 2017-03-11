using System;

namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class Ticket
    {
        public virtual int Id { get; set; }
        public virtual Guid Code { get; set; }
        public virtual UserInfo Passenger { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
