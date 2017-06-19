using PickupGames.Infrastructure.Exceptions;

namespace PickupGames.Infrastructure.Logging
{
    public static class ErrorLogExtensions
    {
        public static string ConvertToApplicationExceptionLogMessage(this ErrorLog errorLog)
        {
            return string.Format("Reference Id: {0}, Error Message: {1}, Errors: {2}", errorLog.CorrelationId,
                errorLog.Message, errorLog.Errors.ConvertToString());
        }

        public static string ConvertToExceptionLogMessage(this ErrorLog errorLog)
        {
            return string.Format("Reference Id: {0}, Error Message: {1}, Error Source: {2}, Error Stack Trace: {3}",
                errorLog.CorrelationId, errorLog.Message, errorLog.Source, errorLog.StackTrace);
        }
    }
}
