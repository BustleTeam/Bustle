using NHibernate.Validator.Constraints;

namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class Seat
    {
        public virtual int Id { get; set; }
        public virtual int Number { get; set; }
        public virtual bool IsAvailable { get; set; }
    }
}
