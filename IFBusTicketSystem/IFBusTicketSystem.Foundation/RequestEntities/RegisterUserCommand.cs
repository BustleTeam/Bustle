using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class RegisterUserCommand
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }
    }
}
