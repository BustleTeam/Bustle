namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class Client
    {
        public virtual string Id { get; set; }
        public virtual string Secret { get; set; }
        public virtual string Name { get; set; }
        public virtual ApplicationType ApplicationType { get; set; }
        public virtual bool Active { get; set; }
        public virtual int RefreshTokenLifeTime { get; set; }
        public virtual string AllowedOrigin { get; set; }
    }
}
