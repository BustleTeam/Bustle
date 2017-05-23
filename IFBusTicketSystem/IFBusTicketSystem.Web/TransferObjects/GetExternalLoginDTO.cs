namespace IFBusTicketSystem.Web.TransferObjects
{
  public class GetExternalLoginDTO
  {
      public string Provider { get; set; }
      public string Error { get; set; } = null;
  }
}