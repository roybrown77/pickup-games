using System.Collections.Generic;
using System.Net;
using PickupGames.Infrastructure.Exceptions;

namespace PickupGames.Infrastructure.Logging
{
    public class ErrorLog
    {
        public string Message { get; set; }
        public IEnumerable<Error> Errors { get; set; }
        public string CorrelationId { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}
