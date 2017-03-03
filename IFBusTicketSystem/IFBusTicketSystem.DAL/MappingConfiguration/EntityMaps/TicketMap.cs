using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.DAL.MappingConfiguration.EntityMaps
{
    class TicketMap : ClassMap<Ticket>
    {
        public TicketMap()
        {
            Id(t => t.Id);
            References(t => t.Passenger).Not.Nullable();
            References(t => t.Seat).Not.Nullable();
        }
    }
}
