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

        List<GameModel> games2 = new List<GameModel>()
        {
            new GameModel{Sport = "hockey"},
            new GameModel{Sport = "soccer"},
        };

        public IEnumerable<GameModel> Get()
        {
            return games;
        }

        public IEnumerable<GameModel> Get(GameModel game)
        {
            return games2;
        }

        public GameModel Put(GameModel game)
        {
            return game;
        }

        public IEnumerable<GameModel> Post(GameModel game)
        {
            return games2;
        }    
    }
}