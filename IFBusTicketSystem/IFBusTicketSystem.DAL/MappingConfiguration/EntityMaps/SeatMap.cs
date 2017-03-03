using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.DAL.MappingConfiguration.EntityMaps
{
    class SeatMap : ClassMap<Seat>
    {
        public SeatMap()
        {
            Id(s => s.Id);
            Map(s => s.Number).Not.Nullable();
            Map(s => s.IsAvailable);
        }
    }
}
