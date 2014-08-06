using System.Collections.Generic;

namespace PickupGames.Domain.Objects
{
    public class GameSearchResponse : ResponseBase
    {
        public List<Game> Games { get; set; }
    }
}