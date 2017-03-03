using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.DAL.MappingConfiguration.EntityMaps
{
    class StopMap : ClassMap<Stop>
    {
        public StopMap()
        {
            Id(s => s.Id);
            References(s => s.Station).Not.Nullable();
            Map(s => s.Arrival).Not.Nullable();
            Map(s => s.Departure).Not.Nullable();
            References(s => s.Race);
        }
    }
}
