using System.Collections.Generic;

namespace IFBusTicketSystem.Foundation.Types
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Station> Stations { get; set; } = new List<Station>();
    }
}
