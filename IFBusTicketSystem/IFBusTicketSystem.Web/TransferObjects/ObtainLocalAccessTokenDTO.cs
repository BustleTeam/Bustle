namespace IFBusTicketSystem.Web.TransferObjects
{
  public class ObtainLocalAccessTokenDTO
  {
      public string Provider { get; set; }
      public string ExternalAccessToken { get; set; }
  }
}