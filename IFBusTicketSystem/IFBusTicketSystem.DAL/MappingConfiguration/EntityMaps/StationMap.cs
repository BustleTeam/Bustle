using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.DAL.MappingConfiguration.EntityMaps
{
    class StationMap : ClassMap<Station>
    {
        public StationMap()
        {
            Id(s => s.Id);
            Map(s => s.Name).Not.Nullable();
            Map(s => s.Locality);
            Map(s => s.Description);
            HasManyToMany(s => s.Routes);
        }
    }
}
