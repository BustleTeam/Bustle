namespace IFBusTicketSystem.Foundation.Types
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public Sex Sex { get; set; } 
        public Address Address { get; set; }
    }
}
