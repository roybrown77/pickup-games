using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Services.Messaging;
using PickupGames.Domain.GamePlaceManagement.Models;

namespace PickupGames.Domain.GameManagement.ViewModels
{
    public class GamesPageViewModel
    {
        public List<EditGameRequest> GameListModel { get; set; }
        public List<Place> PlacesToPlayGamesModel { get; set; }
    }
}