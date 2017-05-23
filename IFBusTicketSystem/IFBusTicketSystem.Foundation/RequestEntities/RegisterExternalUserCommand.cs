namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class RegisterExternalUserCommand
    {
        public string Provider { get; set; }
        public string AccessToken { get; set; }
        public string UserName { get; set; }
    }
}
