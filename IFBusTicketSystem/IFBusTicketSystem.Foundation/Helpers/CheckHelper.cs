using System;
using IFBusTicketSystem.Foundation.Exceptions;

namespace IFBusTicketSystem.Foundation.Helpers
{
    public static class CheckHelper
    {
        public static void CheckIfNull(this object obj, string message = "Null is not allowed.")
        {
            if(obj == null)
                throw new BadRequestException(message);
        }
    }
}
