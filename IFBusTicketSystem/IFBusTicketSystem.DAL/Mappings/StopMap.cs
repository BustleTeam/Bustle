using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.DAL.Mappings
{
    public class StopMap : ClassMap<Stop>
    {
        public StopMap()
        {
            Id(_ => _.Id);
            Map(_ => _.Arrival).CustomSqlType("datetime2").Not.Nullable();
            Map(_ => _.Departure).CustomSqlType("datetime2").Not.Nullable();
            References(_ => _.Station);
        }
    }
}
