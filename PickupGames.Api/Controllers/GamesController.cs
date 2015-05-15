using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;
using PickupGames.Api.Domain.Objects;
using PickupGames.Api.Domains;
using PickupGames.Mappers;
using PickupGames.Api.Models;
using System.Security.Claims;
using System.Linq;

namespace PickupGames.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/v1/games")]
    public class GamesController : ApiController
    {
        [AllowAnonymous]
        public HttpResponseMessage Get([FromUri] GameSearchModel gameSearchModel)
        {
            var searchQuery = GamesMapper.ConvertGameSearchModelToGameSearchQuery(gameSearchModel);
            var domain = new GameSearchDomain();
            var rawResponse = domain.FindBy(searchQuery);

            if (rawResponse.Status == ResponseStatus.Failed)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to get games");
            }

            var response = GamesMapper.ConvertGameSearchResponseToGamesPageModel(rawResponse);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public HttpResponseMessage Post(GameCreateModel gameCreateModel)
        {
            if (ModelState.IsValid) {

                // move to controller/routing filter
                //var user = HttpContext.Current.User;
                var identity = (ClaimsIdentity)User.Identity;
                var claims = identity.Claims;
                var userId = claims.Where(c => c.Type == "userid").Single().Value;

                var game = GamesMapper.ConvertGameCreateModelToGame(userId, gameCreateModel);
                var domain = new GameCrudDomain();
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
            var domain = new GameCrudDomain();
            var response = domain.EditGame(new Guid(id), game);

            if (response.Status == ResponseStatus.Failed)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to update game");
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(string id)
        {
            var domain = new GameCrudDomain();
            var response = domain.DeleteGame(new Guid(id));

            if (response.Status == ResponseStatus.Failed)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to delete game");
            }
            
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}