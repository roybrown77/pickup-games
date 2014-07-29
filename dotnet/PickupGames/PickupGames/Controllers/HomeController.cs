using System;
using System.Collections.Generic;
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
            var model = new HomePageModel
                            {
                                Game = new GameModel(),
                                Games = new List<GameModel>
                                               { 
                                                   new GameModel
                                                          {
                                                              Name = "touch football",
                                                              Sport = "Football",
                                                              StartTime = DateTime.Now,
                                                              Location = "Boston, MA"
                                                          },
                                                    new GameModel
                                                          {
                                                              Name = "3 on 3 basketball",
                                                              Sport = "Basketball",
                                                              StartTime = DateTime.Now.Add(new TimeSpan(3)),
                                                              Location = "Atlanta, GA"
                                                          } 
                                               }
                            };

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
        public JsonResult CreateGame(GameModel gameModel)
        {
            var gameDomain = new GameDomain();
            var game = GameMapper.ConvertGameModelToGame(gameModel);
            var response = gameDomain.CreateGame(game);
            return Json(response);   
        }
    }
}
