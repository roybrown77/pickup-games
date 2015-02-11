using System.Web.Http;
using PickupGames.Domain.Objects;
using PickupGames.Domains;
using PickupGames.Mappers;
using PickupGames.Models;

namespace PickupGames.Controllers
{
    public class Games2Controller : ApiController
    {
        // GET: api/Games2
        public GameSearchResponse SearchByAjax(GameSearchModel searchModel)
        {
            var domain = new GameDomain();
            var searchQuery = GamesMapper.ConvertSearchModelToSearchQuery(searchModel);
            var response = domain.FindBy(searchQuery);
            return response;
        }

        // GET: api/Games2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Games2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Games2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Games2/5
        public void Delete(int id)
        {
        }
    }
}
