using System;

namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class RefreshToken
    {
        public virtual string Id { get; set; }
        public virtual string Subject { get; set; }
        public virtual string ClientId { get; set; }
        public virtual DateTime IssuedUtc { get; set; }
        public virtual DateTime ExpiresUtc { get; set; }
        public virtual string ProtectedTicket { get; set; }
    }
}
