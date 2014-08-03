using System.Collections.Generic;

namespace PickupGames.Models
{
    public class GamesModel
    {
        public GameCreateModel Game { get; set; }
        public GameSearchModel GameSearchModel { get; set; }
        public List<GameModel> Games { get; set; }
    }
}