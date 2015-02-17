using System.Web.Http;

namespace PickupGames.Controllers
{
    //[RoutePrefix("api/Games")]
    public class TestsController : ApiControllerBase
    {
        public void Index()
        {
        }

        [HttpPost]
        //[Route("")]
        public void SearchGames(string location)
        {
            var locationTemp = location;
        }    
    }
}