using System.Collections.Generic;

namespace PickupGames.Infrastructure.Exceptions
{
    public class ErrorMessage
    {
        public ErrorMessage()
        {
            Errors = new List<Error>();
        }

        public string Message { get; set; }
        public int Code { get; set; }
        public IEnumerable<Error> Errors { get; set; }
        public string CorrelationId { get; set; }
    }
}
