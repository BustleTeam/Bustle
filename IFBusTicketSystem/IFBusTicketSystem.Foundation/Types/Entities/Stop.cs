using System;

namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class Stop
    {
        public virtual int Id { get; set; }
        public virtual Station Station { get; set; }
        public virtual DateTime Arrival { get; set; }
        public virtual DateTime Departure { get; set; }
        public virtual Race Race { get; set; }
    }
}
