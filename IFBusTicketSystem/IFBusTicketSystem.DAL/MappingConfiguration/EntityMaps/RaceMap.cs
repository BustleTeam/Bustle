using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.DAL.MappingConfiguration.EntityMaps
{
    class RaceMap : ClassMap<Race>
    {
        public RaceMap()
        {
            Id(r => r.Id);
            References(r => r.Route).Not.Nullable();
            Map(r => r.Arrival).Not.Nullable();
            Map(r => r.Departure).Not.Nullable();
            HasMany(r => r.Seats).Cascade.All();
            HasMany(r => r.Stops).Inverse().Cascade.All();
        }
    }
}
