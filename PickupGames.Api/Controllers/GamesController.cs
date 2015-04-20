using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;
using PickupGames.Api.Domain.Objects;
using PickupGames.Api.Domains;
using PickupGames.Mappers;
using PickupGames.Api.Models;

namespace PickupGames.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/v1/games")]
    public class GamesController : ApiController
    {
        [AllowAnonymous]
        //[System.Web.Mvc.Route("api/games/postcreategame/{gameSearchModel}")]
        public HttpResponseMessage Get([FromUri] GameSearchModel gameSearchModel)
        {
            var searchQuery = GamesMapper.ConvertGameSearchModelToGameSearchQuery(gameSearchModel);
            var domain = new GameDomain();
            var response = domain.FindBy(searchQuery);

            if (response.Status == ResponseStatus.Failed)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to get games");
            }

            var view = GamesMapper.ConvertGameSearchResponseToGamesPageModel(response);
            return Request.CreateResponse(HttpStatusCode.OK, view);
        }

        public HttpResponseMessage Post(GameCreateModel gameCreateModel)
        {
            if (ModelState.IsValid) { 
                var game = GamesMapper.ConvertGameCreateModelToGame(gameCreateModel);
                var domain = new GameDomain();
                var response = domain.CreateGame(game);

                if (response.Status == ResponseStatus.Failed)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to create game");
                }

                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values);
        }

        public HttpResponseMessage Put(string id, GameModel gameModel)
        {
            var game = GamesMapper.ConvertGameModelToGame(gameModel);
            var domain = new GameDomain();
            var response = domain.EditGame(new Guid(id), game);

            if (response.Status == ResponseStatus.Failed)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to update game");
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(string id)
        {
            var domain = new GameDomain();
            var response = domain.DeleteGame(new Guid(id));

            if (response.Status == ResponseStatus.Failed)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to delete game");
            }
            
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}