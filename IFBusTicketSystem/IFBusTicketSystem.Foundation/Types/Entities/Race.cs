using System.Collections.Generic;

namespace IFBusTicketSystem.Foundation.Types
{
    public class Race
    {
        public virtual int Id { get; set; }
        public virtual Route Route { get; set; }
        public virtual IEnumerable<Stop> Stops { get; set; } = new List<Stop>();
    }
}
