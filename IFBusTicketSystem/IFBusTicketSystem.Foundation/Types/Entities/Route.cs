using System.Collections.Generic;

namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class Route : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IEnumerable<Station> Stations { get; set; } = new List<Station>();
    }
}
