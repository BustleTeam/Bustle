namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class ObtainLocalAccessTokenCommand
    {
        public string Provider { get; set; }
        public string ExternalAccessToken { get; set; }
    }
}
