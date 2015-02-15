using System.Web.Http;
using PickupGames.Domains;
using PickupGames.Mappers;
using PickupGames.Models;

namespace PickupGames.Api
{
    public class Tests2Controller : ApiControllerBase
    {
        public GamesModel Get()
        {
            var domain = new GameDomain();
            var response = domain.FindBy("usa");
            return GamesMapper.ConvertGameListToGamesModel(response);
        }

        public GamesModel Get(GameSearchModel searchModel)
        {
            var domain = new GameDomain();
            var searchQuery = GamesMapper.ConvertSearchModelToSearchQuery(searchModel);
            var response = domain.FindBy(searchQuery);
            return GamesMapper.ConvertGameListToGamesModel(response);
        }

        [HttpPost]
        public GamesModel SearchGames(GameSearchModel searchModel)
        {
            var domain = new GameDomain();
            var searchQuery = GamesMapper.ConvertSearchModelToSearchQuery(searchModel);
            var response = domain.FindBy(searchQuery);
            return GamesMapper.ConvertGameListToGamesModel(response);
        }    
    }
}