using System.Web.Mvc;
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
            var response = domain.GetBy("US"); //get by user location or all of login country
            var model = GameMapper.ConvertGameListToGamesModel(response.Games);
            return View("SearchGames", model);
        }

        [HttpPost]
        public JsonResult Create(GameCreateModel gameModel)
        {
            var domain = new GameDomain();
            var game = GameMapper.ConvertGameCreateModelToGame(gameModel);
            var response = domain.CreateGame(game);
            if (response.Status == "Success")
            {
                var gameResponse = domain.GetBy(gameModel.Location);
                return Json(gameResponse);
            }
            return Json(response);
        }

        public ActionResult Search(GameSearchModel searchModel)
        {
            var domain = new GameDomain();
            var searchQuery = GameMapper.ConvertSearchModelToSearchQuery(searchModel);
            var response = domain.FindBy(searchQuery);
            var model = GameMapper.ConvertGameListToGamesModel(response.Games);
            return View("SearchGames", model);
        }        
    }
}