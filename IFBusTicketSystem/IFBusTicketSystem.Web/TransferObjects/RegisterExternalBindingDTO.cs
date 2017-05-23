using System.ComponentModel.DataAnnotations;

namespace IFBusTicketSystem.Web.TransferObjects
{
  public class RegisterExternalBindingDTO
  {
      [Required]
      public string UserName { get; set; }
      [Required]
      public string Provider { get; set; }
      [Required]
      public string ExternalAccessToken { get; set; }
  }
}