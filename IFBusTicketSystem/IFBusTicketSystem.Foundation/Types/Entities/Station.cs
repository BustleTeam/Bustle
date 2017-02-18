using System.Collections.Generic;

namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class Station : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Locality { get; set; }
        public virtual string Description { get; set; }
        public virtual IEnumerable<Route> Routes { get; set; } = new List<Route>();
    }
}
