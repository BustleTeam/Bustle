using System;

namespace IFBusTicketSystem.Foundation.Types
{
    public class Stop
    {
        public int Id { get; set; }
        public Station Station { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
    }
}
