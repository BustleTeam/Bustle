using FluentNHibernate.Mapping;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.DAL.MappingConfiguration.EntityMaps
{
    public class RefreshTokenMap : ClassMap<RefreshToken>
    {
        public RefreshTokenMap()
        {
            Id(rt => rt.Id);
            Map(rt => rt.Subject).Length(50).Not.Nullable();
            Map(rt=>rt.ClientId).Length(50).Not.Nullable();
            Map(rt => rt.IssuedUtc);
            Map(rt => rt.ExpiresUtc);
            Map(rt => rt.ProtectedTicket).Length(500).Not.Nullable();
        }
    }
}
