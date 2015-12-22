using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using PickupGames.Domain.GameLocationManagement.Repositories;
using PickupGames.Domain.GameLocationManagement.Services;
using PickupGames.Domain.GameManagement.Mappers;
using PickupGames.Domain.GameManagement.Repositories;
using PickupGames.Domain.GameManagement.Services;
using PickupGames.Domain.GameManagement.Services.Messaging;
using PickupGames.Infrastructure.Geography;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Controllers.GameManagement
{
    [Authorize]
    public class GamesController : ApiController
    {
        readonly IGamePageViewService _gamePageService;
        private readonly IGameService _gameService;

        //public GamesController(IGamePageViewService gamePageService, IGameService gameService)
        //{
        //    _gamePageService = new GamePageViewService(new GeographyService(), new GameService(new MockGameRepository(), new GeographyService()),  new GameLocationService(new GameLocationRepository()));
        //    _gameService = new GameService(new MockGameRepository(), new GeographyService());
        //}

        [AllowAnonymous]
        [Route("api/v1/games")]
        [HttpGet]
        public HttpResponseMessage GetGamesByQuery([FromUri] GameSearchRequest request)
        {
            var searchQuery = GamesMapper.ConvertGameSearchModelToGameSearchQuery(request);

            var gamePageService = new GamePageViewService(new GeographyService(), new GameService(new MockGameRepository(), new GeographyService()),  new GameLocationService(new GameLocationRepository()));
            var rawResponse = gamePageService.FindBy(searchQuery);

            if (rawResponse.Status == ResponseStatus.Failed)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to get games");
            }

            var response = GamesMapper.ConvertGameSearchResponseToGamesPageModel(rawResponse);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("api/v1/games")]
        [HttpPost]
        public HttpResponseMessage CreateGame(CreateGameRequest reqest)
        {
            if (ModelState.IsValid)
            {
                //var user = HttpContext.Current.User;
                var identity = (ClaimsIdentity)User.Identity;
                var claims = identity.Claims;
                var userId = claims.Where(c => c.Type == "userid").Single().Value;

                var game = GamesMapper.ConvertGameCreateModelToGame(userId, reqest);

                var gameService = new GameService(new MockGameRepository(), new GeographyService());
                var response = gameService.CreateGame(game);

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
        public HttpResponseMessage UpdateGame(string id, EditGameRequest request)
        {
            var game = GamesMapper.ConvertGameModelToGame(request);

            var gameService = new GameService(new MockGameRepository(), new GeographyService());
            var response = gameService.EditGame(new Guid(id), game);

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
            var gameService = new GameService(new MockGameRepository(), new GeographyService());
            var response = gameService.DeleteGame(new Guid(id));

            if (response.Status == ResponseStatus.Failed)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to delete game");
            }
            
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}