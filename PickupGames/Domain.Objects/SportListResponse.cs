using System.Collections.Generic;

namespace PickupGames.Domain.Objects
{
    public class SportListResponse : ResponseBase
    {
        public List<Sport> Sports { get; set; }
    }
}