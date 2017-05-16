using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.DAL.MappingConfiguration.EntityMaps
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Id(c => c.Id);
            Map(c => c.Secret).Not.Nullable();
            Map(c => c.Name).Length(100).Not.Nullable();
            Map(c => c.ApplicationType).CustomType<ApplicationType>();
            Map(c => c.Active);
            Map(c => c.RefreshTokenLifeTime);
            Map(c => c.AllowedOrigin).Length(100);
        }
    }
}
