namespace IFBusTicketSystem.Foundation.Types
{
    public class Station
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Locality { get; set; }
        public virtual string Description { get; set; }
    }
}
