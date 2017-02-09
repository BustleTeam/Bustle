using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.DAL.Mappings
{
    public class RouteMap : ClassMap<Route>
    {
        public RouteMap()
        {
            Id(_ => _.Id);
            Map(_ => _.Name);
            Map(_ => _.Description);
            HasMany(_ => _.Stations);
        }
    }
}
