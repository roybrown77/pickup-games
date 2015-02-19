using System.Collections.Generic;
using System.Web.Http;
using PickupGames.Domain.Objects;
using PickupGames.Domains;
using PickupGames.Mappers;
using PickupGames.Models;

namespace PickupGames.Controllers
{
    public class Tests2Controller : ApiControllerBase
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