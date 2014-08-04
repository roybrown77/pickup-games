using System.Collections.Generic;
using System.Web.Mvc;
using PickupGames.Models;

namespace PickupGames.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return View(new GameSearchModel());
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
        public ActionResult SearchGames(GameSearchModel searchModel)
        {
            var model = new GamesModel
            {
                Game = new GameCreateModel(),
                GameSearchModel = new GameSearchModel(),
                Games = new List<GameModel>()
            };

            return View("SearchGames", model);
        }
    }
}