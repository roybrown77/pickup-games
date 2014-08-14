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
            var model = GamesMapper.ConvertGameListToGamesModel(response.Games);
            return View(model);
        }

        public ActionResult Create()
        {
            return View("CreateGame");
        }

        [HttpPost]
        public ActionResult Create(GameCreateModel gameModel)
        {
            var domain = new GameDomain();
            var game = GamesMapper.ConvertGameCreateModelToGame(gameModel);
            var response = domain.CreateGame(game);

            if (response.Status == "Success")
            {
                return RedirectToAction("Index");
            }
            
            return View("CreateGame");                                  
        }                

        public ActionResult Search(GameSearchModel searchModel)
        {
            var domain = new GameDomain();
            var searchQuery = GamesMapper.ConvertSearchModelToSearchQuery(searchModel);
            var response = domain.FindBy(searchQuery);
            var model = GamesMapper.ConvertGameListToGamesModel(response.Games);
            return View("Index", model);
        }

        [HttpPost]
        public JsonResult SearchByAjax(GameSearchModel searchModel)
        {
            var domain = new GameDomain();
            var searchQuery = GamesMapper.ConvertSearchModelToSearchQuery(searchModel);
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

        [HttpPost]
        public JsonResult Watch(string gameId)
        {
            return Json(new BasicResponse { Status = "Success" });
        }        
    }
}