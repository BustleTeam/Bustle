using System.Web;
using System.Web.Http;
using IFBusTicketSystem.DAL;

namespace IFBusTicketSystem.Web
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
