using System;
using System.Collections.Generic;

namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class Race
    {
        public virtual int Id { get; set; }
        public virtual Route Route { get; set; }
        public virtual DateTime Arrival { get; set; }
        public virtual DateTime Departure { get; set; }
        public virtual IEnumerable<Stop> Stops { get; set; } = new List<Stop>();
        public virtual IEnumerable<Seat> Seats { get; set; } = new List<Seat>();
    }
}
