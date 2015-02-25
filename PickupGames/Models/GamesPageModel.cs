using System.Collections.Generic;

namespace PickupGames.Models
{
    public class GamesPageModel
    {
        public GamesPageModel()
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