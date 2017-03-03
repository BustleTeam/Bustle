using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.DAL.MappingConfiguration.EntityMaps
{
    class RouteMap : ClassMap<Route>
    {
        public RouteMap()
        {
            Id(r => r.Id);
            Map(r => r.Name).Not.Nullable();
            Map(r => r.Description);
            HasManyToMany(r => r.Stations).Inverse().Cascade.SaveUpdate();
        }
    }
}
