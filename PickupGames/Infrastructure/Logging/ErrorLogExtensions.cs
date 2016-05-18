using PickupGames.Infrastructure.Exceptions;

namespace PickupGames.Infrastructure.Logging
{
    public static class ErrorLogExtensions
    {
        public static string ConvertToBrokenRuleLogMessage(this ErrorLog errorLog)
        {
            return string.Format("Reference Id: {0}, Error Message: {1}, Errors: {2}", errorLog.CorrelationId,
                errorLog.Message, errorLog.Errors.ConvertToString());
        }

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

        public static ErrorMessage ConvertToUserBrokenRuleErrorMessage(this ErrorLog errorLog)
        {
            return new ErrorMessage
            {
                CorrelationId = errorLog.CorrelationId,
                Message = errorLog.Message,
                Code = (int)errorLog.Code,
                Errors = errorLog.Errors  
            };
        }

        public static ErrorMessage ConvertToUserApplicationExceptionErrorMessage(this ErrorLog errorLog)
        {
            return new ErrorMessage
            {
                CorrelationId = errorLog.CorrelationId,
                Message = errorLog.Message,
                Code = (int)errorLog.Code,
                Errors = errorLog.Errors
            };
        }

        public static ErrorMessage ConvertToUserExceptionErrorMessage(this ErrorLog errorLog)
        {
            return new ErrorMessage
            {
                CorrelationId = errorLog.CorrelationId,
                Message = "Internal Exception. Please contact your administrator.",
                Code = (int)errorLog.Code
            };
        }
    }
}
