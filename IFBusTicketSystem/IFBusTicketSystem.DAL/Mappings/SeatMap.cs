using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.DAL.Mappings
{
    public class SeatMap : ClassMap<Seat>
    {
        public SeatMap()
        {
            Id(_ => _.Id);
            Map(_ => _.Number);
            Map(_ => _.IsAvailable);
            References(_ => _.Race);
        }
    }
}
