﻿using System.Collections.Generic;

namespace PickupGames.Models
{
    public class HomePageModel
    {
        public GameCreateModel Game { get; set; }
        public List<GameModel> Games { get; set; }
    }
}