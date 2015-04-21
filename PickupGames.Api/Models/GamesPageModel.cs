using PickupGames.Api.Domain.Objects;
using System.Collections.Generic;

namespace PickupGames.Api.Models
{
    public class GamesPageModel
    {
        public GamesPageModel()
        {
            GameSearchModel = new GameSearchModel();
        }

        public GameSearchModel GameSearchModel { get; set; }
        public List<GameModel> GameListModel { get; set; }
        public List<Location> PlacesToPlayGamesModel { get; set; }
    }
}