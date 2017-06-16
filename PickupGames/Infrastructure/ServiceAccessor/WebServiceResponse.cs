using System.Collections.Generic;
using PickupGames.Infrastructure.Exceptions;

namespace PickupGames.Infrastructure.ServiceAccessor
{
    public class WebServiceResponse
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public List<Error> Errors { get; set; }
    }
}
