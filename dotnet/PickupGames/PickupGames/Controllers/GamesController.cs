using System.Web.Mvc;
using PickupGames.Domain.Objects;
using PickupGames.Domains;
using PickupGames.Mappers;
using PickupGames.Models;

namespace PickupGames.Controllers
{
    public class GamesController : ControllerBase
    {
        public ActionResult Index()
        {
            var domain = new GameDomain();
            var response = domain.FindBy("US"); //get by user specific location or login city, state
            var model = GameMapper.ConvertGameListToGamesModel(response.Games);
            return View("Games", model);
        }

        [HttpPost]
        public JsonResult Create(GameCreateModel gameModel)
        {
            var domain = new GameDomain();
            var game = GameMapper.ConvertGameCreateModelToGame(gameModel);
            var response = domain.CreateGame(game);            
            return Json(response);
        }

        public JsonResult JsonSearch(string location)
        {
            var domain = new GameDomain();
            var response = domain.FindBy(location);            
            return Json(response);
        }

        public ActionResult Search(GameSearchModel searchModel)
        {
            var domain = new GameDomain();
            var searchQuery = GameMapper.ConvertSearchModelToSearchQuery(searchModel);
            var response = domain.FindBy(searchQuery);
            var model = GameMapper.ConvertGameListToGamesModel(response.Games);
            return View("Games", model);
        }

        [HttpPost]
        public JsonResult JsonSearch(GameSearchModel searchModel)
        {
            var domain = new GameDomain();
            var searchQuery = GameMapper.ConvertSearchModelToSearchQuery(searchModel);
            var response = domain.FindBy(searchQuery);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Join(string gameId)
        {
            return Json(new BasicResponse { Status = "Success" });
        }

        [HttpPost]
        public JsonResult Delete(string gameId)
        {
            return Json(new BasicResponse { Status = "Success" });
        }
    }
}