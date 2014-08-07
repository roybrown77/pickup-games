using System.Collections.Generic;

namespace PickupGames.Models
{
    public class GamesModel
    {
        public GamesModel()
        {
            GameSearchModel = new GameSearchModel();
        }

        public GameSearchModel GameSearchModel { get; set; }

        public List<GameModel> GameListModel { get; set; }
    }
}