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

        public int NumberFound { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}