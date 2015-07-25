using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PickupGames.Models
{
    public class ResponseResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
