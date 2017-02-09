using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.DAL.Mappings
{
    public class StationMap : ClassMap<Station>
    {
        public StationMap()
        {
            Id(_ => _.Id);
            Map(_ => _.Name);
            Map(_ => _.Description);
            Map(_ => _.Locality);
        }
    }
}
