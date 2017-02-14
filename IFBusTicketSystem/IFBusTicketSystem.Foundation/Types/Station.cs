using System.Collections.Generic;

namespace IFBusTicketSystem.Foundation.Types
{
    public class Station
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Locality { get; set; }
        public virtual string Description { get; set; }
        public virtual IEnumerable<Route> Routes { get; set; } = new List<Route>();
    }
}
