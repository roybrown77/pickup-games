using System.Collections.Generic;
using PickupGames.Domain.GameLocationManagement.Models;
using PickupGames.Domain.GameManagement.Services.Messaging;

namespace PickupGames.Domain.GameManagement.ViewModels
{
    public class GamesPageViewModel
    {
        public GamesPageViewModel()
        {
            GameSearchModel = new GameSearchRequest();
        }

        public GameSearchRequest GameSearchModel { get; set; }
        public List<EditGameRequest> GameListModel { get; set; }
        public List<Location> PlacesToPlayGamesModel { get; set; }
    }
}