using System.Collections.Generic;
using System.Linq;

namespace PickupGames.Infrastructure.Exceptions
{
    public static class ErrorExtensions
    {
        public static string ConvertToString(this IEnumerable<Error> errors)
        {
            return string.Join(", ", errors.Select(error => string.Format("{0} - {1}", error.Id, error.Message)));
        }        
    }    
}
