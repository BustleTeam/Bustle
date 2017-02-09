using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.DAL.Mappings
{
    public class RaceMap : ClassMap<Race>
    {
        public RaceMap()
        {
            Id(_ => _.Id);
            References(_ => _.Route);
            HasMany(_ => _.Stops);
        }
    }
}
