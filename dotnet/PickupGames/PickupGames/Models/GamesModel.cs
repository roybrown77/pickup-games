using System.Collections.Generic;

namespace PickupGames.Models
{
    public class GamesModel
    {
        public GamesModel()
        {
            GameCreateModel = new GameCreateModel();
            GameSearchModel = new GameSearchModel();
        }

        public GameCreateModel GameCreateModel { get; set; }

        public GameSearchModel GameSearchModel { get; set; }

        public List<GameModel> GameListModel { get; set; }
    }
}