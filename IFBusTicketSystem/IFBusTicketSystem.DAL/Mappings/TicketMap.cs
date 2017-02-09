using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.DAL.Mappings
{
    public class TicketMap : ClassMap<Ticket>
    {
        public TicketMap()
        {
            Id(_ => _.Id);
            References(_ => _.Passenger);
            References(_ => _.Seat);
        }
    }
}
