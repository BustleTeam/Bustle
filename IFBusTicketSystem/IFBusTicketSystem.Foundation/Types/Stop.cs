using System;

namespace IFBusTicketSystem.Foundation.Types
{
    public class Stop
    {
        public virtual int Id { get; set; }
        public virtual Station Station { get; set; }
        public virtual DateTime Arrival { get; set; }
        public virtual DateTime Departure { get; set; }
    }
}
