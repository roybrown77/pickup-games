using System.Web.Http;
using PickupGames.Domains;
using PickupGames.Mappers;
using PickupGames.Models;

namespace PickupGames.Api
{
    public class TestsController : ApiControllerBase
    {
        [HttpPost]
        public GamesModel Get()
        {
            var domain = new GameDomain();
            var response = domain.FindBy("usa"); //get by user set location or url country
            return GamesMapper.ConvertGameListToGamesModel(response);
        }

        public GamesModel Get(GameSearchModel searchModel)
        {
            var domain = new GameDomain();
            var searchQuery = GamesMapper.ConvertSearchModelToSearchQuery(searchModel);
            var response = domain.FindBy(searchQuery);
            return GamesMapper.ConvertGameListToGamesModel(response);            
        }    
    }
}