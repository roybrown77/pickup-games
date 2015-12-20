using System;
using System.Collections.Generic;
using System.Net;

namespace PickupGames.Infrastructure.Exceptions
{
    public abstract class CustomException : Exception
    {
        public virtual string ErrorDescription { get; set; }
        public virtual HttpStatusCode StatusCode { get; set; }        
        public virtual IEnumerable<Error> Errors { get; set; }
    }    
}
