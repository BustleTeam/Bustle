using System.Collections.Generic;

namespace IFBusTicketSystem.Foundation.Types
{
    public class Race
    {
        public int Id { get; set; }
        public Route Route { get; set; }
        public List<Stop> Stops { get; set; } = new List<Stop>();
    }
}
