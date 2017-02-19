using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using IFBusTicketSystem.Foundation.Constants;
using NLog;

namespace IFBusTicketSystem.Web.Filters
{
    public class CheckExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
           var logger = LogManager.GetLogger(LogHelper.LoggerName);
           logger.Error(context.Exception);

            //Todo: Maybe later add more specific exception checking and appropriate status code (V.Y.)
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}