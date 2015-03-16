using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;
using PickupGames.Domain.Objects;
using PickupGames.Domains;
using PickupGames.Mappers;
using PickupGames.Models;

namespace PickupGames.Controllers
{
    //[System.Web.Mvc.RoutePrefix("api/games")]
    public class GamesController : ApiControllerBase
    {
        //[System.Web.Mvc.Route("api/games/postcreategame/{gameSearchModel}")]
        public GamesPageModel Get([FromUri] GameSearchModel gameSearchModel)
        {
            var searchQuery = GamesMapper.ConvertGameSearchModelToGameSearchQuery(gameSearchModel);
            var domain = new GameDomain();
            var response = domain.FindBy(searchQuery);
            var view = GamesMapper.ConvertGameSearchResponseToGamesPageModel(response);
            return view;
        }

        public HttpResponseMessage Post(GameCreateModel gameCreateModel)
        {
            if (ModelState.IsValid) { 
                var game = GamesMapper.ConvertGameCreateModelToGame(gameCreateModel);
                var domain = new GameDomain();
                var response = domain.CreateGame(game);

                if (response.Status == ResponseStatus.Failed)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, response.Message);
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
        }

        public void Put(string id, Game game)
        {
            //return Ok;
        }

        public void Delete(string id)
        {
            var domain = new GameDomain();
            domain.DeleteGame(new Guid(id));
            //return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}