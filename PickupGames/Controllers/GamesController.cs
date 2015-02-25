using System.Collections.Generic;
using PickupGames.Domain.Objects;
using PickupGames.Domains;
using PickupGames.Mappers;
using PickupGames.Models;

namespace PickupGames.Controllers
{
    //[RoutePrefix("api/Games")]
    public class GamesController : ApiControllerBase
    {
        //List<GameModel> games = new List<GameModel>()
        //{
        //    new GameModel{Sport = "basketball"},
        //    new GameModel{Sport = "football"},
        //};

        //List<GameModel> games2 = new List<GameModel>()
        //{
        //    new GameModel{Sport = "hockey"},
        //    new GameModel{Sport = "soccer"},
        //};

        //public IEnumerable<GameModel> Get()
        //{
        //    return games;
        //}

        //public IEnumerable<GameModel> Get(GameSearchModel gameSearchModel)
        //{
        //    return games;
        //}

        //public GameModel Put(GameModel game)
        //{
        //    return game;
        //}

        //[Route("{location}/{index}?{parameters ie zoom, sport}")]
        public GameSearchResponse Post(GameSearchModel gameSearchModel)
        {
            var searchQuery = GamesMapper.ConvertGameSearchModelToGameSearchQuery(gameSearchModel);
            var domain = new GameDomain();
            return domain.FindBy(searchQuery);
        }    
    }
}