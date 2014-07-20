using System.Web.Mvc;
using PickupGames.Models;

namespace PickupGames.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new GameModel();
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

        public ActionResult GetGames()
        {
            throw new System.NotImplementedException();
        }
    }
}
