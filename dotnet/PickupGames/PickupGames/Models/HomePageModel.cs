using System.Collections.Generic;

namespace PickupGames.Models
{
    public class HomePageModel
    {
        public GameModel Game { get; set; }
        public List<GameModel> Games { get; set; }
    }
}