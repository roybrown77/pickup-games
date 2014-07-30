using System.Collections.Generic;

namespace PickupGames.Objects
{
    public class BasicResponse : ResponseBase
    {
        public List<Game> Games { get; set; }
    }
}