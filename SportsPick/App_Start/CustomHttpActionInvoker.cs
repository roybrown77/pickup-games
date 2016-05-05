using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using PickupGames.Infrastructure.Exceptions;
using PickupGames.Infrastructure.Logging;

namespace PickupGames
{
    //for more info, read http://www.codeproject.com/Articles/733512/Exception-Handling-in-WebAPI

    public class CustomHttpActionInvoker : ApiControllerActionInvoker
    {        
        public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var result = base.InvokeActionAsync(actionContext, cancellationToken);
            
            if (result.Exception != null)
            {               
                var baseException = result.Exception.InnerExceptions[0];

                string errorMessage;
                int errorCode;
                var errors = new List<Error>();

                HttpError errorMessagError;

                if (baseException is ApplicationLayerException)
                {
                    var baseExcept = baseException as ApplicationLayerException;

                    errorMessage = baseExcept.ErrorDescription ?? "Internal Exception. Please contact your administrator.";
                    errorCode = (int)baseExcept.StatusCode;
                    errors = baseExcept.Errors != null ? baseExcept.Errors.ToList() : errors;

                    errorMessagError = new HttpError(errorMessage) { { "Code", errorCode }, { "Errors", errors } };

                    LoggingFactory.GetLogger().Log("Error Code: " + errorCode + ", Error Description: " + errorMessage + ", Error Message: " + baseExcept.Message + ", Error Source: " + baseExcept.Source + ", Error Stack Trace: " + baseExcept.StackTrace + ", Errors: " + errors, LogType.Error);
                    
                    return Task.Run(() =>
                        actionContext.Request.CreateErrorResponse(baseExcept.StatusCode, errorMessagError));
                }

                errorMessage = "Internal Exception. Please contact your administrator.";
                errorCode = (int)HttpStatusCode.InternalServerError;
                
                LoggingFactory.GetLogger().Log("Error Code: " + errorCode + ", Error Description: " + errorMessage + ", Error Message: " + baseException.Message + ", Error Source: " + baseException.Source + ", Error Stack Trace: " + baseException.StackTrace + ", Errors: " + errors, LogType.Error);

                errorMessagError = new HttpError(errorMessage) { { "Code", errorCode } };
                    return Task.Run(() => actionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorMessagError));
            }

            return result;
        }
    }    
}