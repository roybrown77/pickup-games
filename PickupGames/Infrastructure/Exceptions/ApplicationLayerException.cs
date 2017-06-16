using System.Collections.Generic;
using System.Net;

namespace PickupGames.Infrastructure.Exceptions
{
    public class ApplicationLayerException : CustomException
    {
        public ApplicationLayerException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public ApplicationLayerException(HttpStatusCode statusCode, string errorDescription)
        {
            ErrorDescription = errorDescription;
            StatusCode = statusCode;
        }

        public ApplicationLayerException(HttpStatusCode statusCode, string errorDescription, IEnumerable<Error> errors)
        {
            ErrorDescription = errorDescription;
            StatusCode = statusCode;            
            Errors = errors;
        }        
    } 
}
