using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;
using PickupGames.Models;
using PickupGames.Domains;
using PickupGames.Mappers;
using PickupGames.ViewModels;
using System.Security.Claims;
using System.Linq;

namespace PickupGames.Controllers
{
    [Authorize]
    public class GamesController : ApiController
    {
        [AllowAnonymous]
        [Route("api/v1/games")]
        [HttpGet]
        public HttpResponseMessage GetGamesByQuery([FromUri] GameSearchViewModel gameSearchModel)
        {
            var searchQuery = GamesMapper.ConvertGameSearchModelToGameSearchQuery(gameSearchModel);
            var domain = new GameQueryService();
            var rawResponse = domain.FindBy(searchQuery);

            if (rawResponse.Status == ResponseStatus.Failed)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to get games");
            }

            var response = GamesMapper.ConvertGameSearchResponseToGamesPageModel(rawResponse);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("api/v1/games")]
        [HttpPost]
        public HttpResponseMessage CreateGame(GameModel gameCreateModel)
        {
            if (ModelState.IsValid) {

                // move to controller/routing filter
                //var user = HttpContext.Current.User;
                var identity = (ClaimsIdentity)User.Identity;
                var claims = identity.Claims;
                var userId = claims.Where(c => c.Type == "userid").Single().Value;

                var game = GamesMapper.ConvertGameCreateModelToGame(userId, gameCreateModel);
                var domain = new GameCommandService();
                var response = domain.CreateGame(game);

                if (response.Status == ResponseStatus.Failed)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to create game");
                }

                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values);
        }

        [Route("api/v1/games")]
        [HttpPut]
        public HttpResponseMessage UpdateGame(string id, GameViewModel gameModel)
        {
            var game = GamesMapper.ConvertGameModelToGame(gameModel);
            var domain = new GameCommandService();
            var response = domain.EditGame(new Guid(id), game);

            if (response.Status == ResponseStatus.Failed)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to update game");
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("api/v1/games")]
        [HttpDelete]
        public HttpResponseMessage DeleteGame(string id)
        {
            var domain = new GameCommandService();
            var response = domain.DeleteGame(new Guid(id));

            if (response.Status == ResponseStatus.Failed)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to delete game");
            }
            
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}