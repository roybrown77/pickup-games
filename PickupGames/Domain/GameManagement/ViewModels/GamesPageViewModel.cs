using System.Collections.Generic;
using PickupGames.Domain.GameLocationManagement.Models;

namespace PickupGames.Domain.GameManagement.ViewModels
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