using System;
using System.Net;
using System.Web;
using PickupGames.Infrastructure.Exceptions;

namespace PickupGames.Infrastructure.Logging
{
    public class LoggingHelper
    {
        public static ErrorLog GenerateExceptionErrorLog(Exception exception)
        {
            var correlationId = GetCorrelationId();
            
            return new ErrorLog
            {
                CorrelationId = correlationId,
                Message = exception.Message,
                Code = HttpStatusCode.InternalServerError,
                Source = exception.Source,
                StackTrace = exception.StackTrace
            };
        }

        public static ErrorLog GenerateApplicationErrorLog(ApplicationLayerException applicationLayerException)
        {
            var correlationId = GetCorrelationId();

            return new ErrorLog
            {
                CorrelationId = correlationId,
                Message = applicationLayerException.ErrorDescription,
                Code = applicationLayerException.StatusCode,
                Errors = applicationLayerException.Errors
            };
        }

        public static string GetCorrelationId()
        {
            var correlationId = HttpContext.Current == null ? "Not Available" : (string)HttpContext.Current.Items["CorrelationId"];
            return correlationId;
        }        
    }    
}
