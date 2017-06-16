using System.Collections.Generic;

namespace PickupGames.Infrastructure.Response
{
    public class ResponseResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
