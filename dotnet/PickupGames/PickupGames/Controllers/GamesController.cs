using System;
using System.Collections.Generic;
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
            var model = new GamesModel
            {
                Game = new GameCreateModel(),
                Games = new List<GameModel>
                                               { 
                                                   new GameModel
                                                          {
                                                              Name = "touch football",
                                                              Sport = "Football",
                                                              GameDateTime = DateTime.Now,
                                                              Location = "Boston, MA",
                                                              PlayerCount = 6,
                                                              DistanceToLocation = "5.5 mi"
                                                          },
                                                    new GameModel
                                                          {
                                                              Name = "3 on 3 basketball",
                                                              Sport = "Basketball",
                                                              GameDateTime = DateTime.Now.Add(new TimeSpan(3)),
                                                              Location = "Atlanta, GA",
                                                              PlayerCount = 8,
                                                              DistanceToLocation = "10.23 mi"
                                                          } 
                                               },
                GameSearchModel = new GameSearchModel()
            };

            return View("SearchGames", model);
        }

        [HttpPost]
        public JsonResult Create(GameCreateModel gameModel)
        {
            var gameDomain = new GameDomain();
            var game = GameMapper.ConvertGameCreateModelToGame(gameModel);
            var response = gameDomain.CreateGame(game);
            return Json(response);
        }

        public ActionResult Search(GameSearchModel searchModel)
        {
            var model = new GamesModel
            {
                Game = new GameCreateModel(),
                Games = new List<GameModel>
                                               { 
                                                   new GameModel
                                                          {
                                                              Name = "touch football",
                                                              Sport = "Football",
                                                              GameDateTime = DateTime.Now,
                                                              Location = "Boston, MA",
                                                              PlayerCount = 6,
                                                              DistanceToLocation = "5.5 mi"
                                                          },
                                                    new GameModel
                                                          {
                                                              Name = "3 on 3 basketball",
                                                              Sport = "Basketball",
                                                              GameDateTime = DateTime.Now.Add(new TimeSpan(3)),
                                                              Location = "Atlanta, GA",
                                                              PlayerCount = 8,
                                                              DistanceToLocation = "10.23 mi"
                                                          } 
                                               },
                GameSearchModel = searchModel
            };

            return View("SearchGames", model);
        }        
    }
}