using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Services.Messaging;
using PickupGames.Domain.GamePlaceManagement.Models;

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
        public List<Place> PlacesToPlayGamesModel { get; set; }
    }
}