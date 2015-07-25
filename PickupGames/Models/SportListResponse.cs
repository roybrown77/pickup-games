using System.Collections.Generic;

namespace PickupGames.Models
{
    public class SportListResponse : ResponseBase
    {
        public List<Sport> Sports { get; set; }
    }
}