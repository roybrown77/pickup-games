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
            var response = GamesMapper.ConvertGameSearchResponseToGamesPageModel(rawResponse);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("api/v1/games")]
        [HttpPost]
        public HttpResponseMessage CreateGame(CreateGameRequest request)
        {
            //var user = HttpContext.Current.User;
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.Claims;
            var userId = claims.Single(c => c.Type == "userid").Value;
            request.UserId = userId;

            var gameService = new GameService(new MockGameRepository(), new GeographyService());
            gameService.CreateGame(request);
            return new HttpResponseMessage(HttpStatusCode.Created);                        
        }

        [Route("api/v1/games/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateGame(string id, EditGameRequest request)
        {
            var game = GamesMapper.ConvertGameModelToGame(request);
            var gameService = new GameService(new MockGameRepository(), new GeographyService());
            gameService.EditGame(new Guid(id), game);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("api/v1/games/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteGame(string id)
        {
            var gameService = new GameService(new MockGameRepository(), new GeographyService());
            gameService.DeleteGame(new Guid(id));
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}