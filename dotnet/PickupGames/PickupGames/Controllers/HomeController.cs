using System.Web.Mvc;
using PickupGames.Domains;
using PickupGames.Mappers;
using PickupGames.Models;

namespace PickupGames.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            var model = new CreateGameModel();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult CreateGame(CreateGameModel gameModel)
        {
            var gameDomain = new GameDomain();
            var game = GameMapper.ConvertGameModelToGame(gameModel);
            var response = gameDomain.CreateGame(game);
            return Json(response);   
        }
    }
}
