using NHibernate.AspNet.Identity;

namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class UserInfo : IdentityUser
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Sex Sex { get; set; }
        //public virtual Address Address { get; set; }
    }
}
