using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.DAL.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(_ => _.Id);
            Map(_ => _.Name);
            Map(_ => _.Surname);
            Map(_ => _.Email);
            Map(_ => _.Password);
            Map(_ => _.Sex);
            References(_ => _.Address);
        }
    }
}
