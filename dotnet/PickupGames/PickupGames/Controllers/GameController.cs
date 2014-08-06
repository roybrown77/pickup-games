using System.Web.Mvc;

namespace PickupGames.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View("CreateGame");
        }        
    }
}
