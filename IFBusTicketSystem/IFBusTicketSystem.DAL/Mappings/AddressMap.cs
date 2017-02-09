using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.DAL.Mappings
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Map(_ => _.Country);
            Map(_ => _.City);
            Map(_ => _.Street);
            Map(_ => _.Building);
        }
    }
}
