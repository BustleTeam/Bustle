using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using IFBusTicketSystem.Foundation.Constants;
using IFBusTicketSystem.Foundation.Exceptions;
using NLog;

namespace IFBusTicketSystem.Web.Filters
{
    public class CheckExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
           var logger = LogManager.GetLogger(LogHelper.LoggerName);
           logger.Error(context.Exception);

            context.Response = context.Request.CreateResponse(GetAppropriateStatusCode(context.Exception), context.Exception.Message);
        }

        private static HttpStatusCode GetAppropriateStatusCode(Exception exception)
        {
            if (exception is BadRequestException)
                  return HttpStatusCode.BadRequest;

            return HttpStatusCode.InternalServerError;
        }
    }
}