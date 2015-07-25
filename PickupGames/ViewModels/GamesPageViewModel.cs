using PickupGames.Models;
using System.Collections.Generic;

namespace PickupGames.ViewModels
{
    public class GamesPageViewModel
    {
        public GamesPageViewModel()
        {
            GameSearchModel = new GameSearchViewModel();
        }

        public GameSearchViewModel GameSearchModel { get; set; }
        public List<GameViewModel> GameListModel { get; set; }
        public List<Location> PlacesToPlayGamesModel { get; set; }
    }
}