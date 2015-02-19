using System.Collections.Generic;
using PickupGames.Models;

namespace PickupGames.Controllers
{
    public class GamesController : ApiControllerBase
    {
        List<GameModel> games = new List<GameModel>()
        {
            new GameModel{Sport = "basketball"},
            new GameModel{Sport = "football"},
        };

        public IEnumerable<GameModel> Get()
        {
            return games;
        }

        public GameModel Put(GameModel game)
        {
            return game;
        }

        public GameModel Post(GameModel game)
        {
            return null;
        }    
    }
}