﻿using System.Collections.Generic;

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
    }
}