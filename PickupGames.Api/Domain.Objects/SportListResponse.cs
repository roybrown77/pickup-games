using System.Collections.Generic;

namespace PickupGames.Api.Domain.Objects
{
    public class SportListResponse : ResponseBase
    {
        public List<Sport> Sports { get; set; }
    }
}