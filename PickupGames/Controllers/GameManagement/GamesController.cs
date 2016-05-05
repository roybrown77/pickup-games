using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using PickupGames.Domain.GameManagement.Mappers;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories;
using PickupGames.Domain.GameManagement.Services;
using PickupGames.Domain.GameManagement.Services.Messaging;
using PickupGames.Domain.GamePlaceManagement.Repositories;
using PickupGames.Domain.GamePlaceManagement.Services;
using PickupGames.Domain.Geography;

namespace PickupGames.Controllers.GameManagement
{
    [Authorize]
    public class GamesController : ApiController
    {
        //readonly IGamePageViewService _gamePageService;

        private readonly IGameService _gameService;
        private readonly IGeographyRepository _geographyRepository;
        private readonly IGamePlaceService _gamePlaceService;

        public GamesController()
        {
            _geographyRepository = new GeographyRepository();
            _gameService = new GameService(new MockGameRepository(), new GeographyRepository());
            _gamePlaceService = new GamePlaceService(new GamePlaceRepository());
        }

        [AllowAnonymous]
        [Route("api/games")]
        [HttpGet]
        public HttpResponseMessage GetGamesByQuery([FromUri] GameSearchRequest request)
        {
            var searchQuery = GamesMapper.ConvertGameSearchModelToGameSearchQuery(request);

            //var gamePageService = new GamePageViewService(new GeographyRepository(), new GameService(new MockGameRepository(), new GeographyRepository()),  new GamePlaceService(new GamePlaceRepository()));
            //var rawResponse = gamePageService.FindBy(searchQuery);
            
            var centerCoordinates = _geographyRepository.GetCoordinates(searchQuery.Location);
            var userSavedGames = _gameService.FindBy(searchQuery, centerCoordinates);
            var placesToPlayGames = _gamePlaceService.FindBy(searchQuery);

            var viewModel = new GameSearchResponseListViewModel
            {
                Games = userSavedGames,
                PlacesToPlayGames = placesToPlayGames
            };

            var response = GamesMapper.ConvertGameSearchResponseToGamesPageModel(viewModel);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("api/games")]
        [HttpPost]
        public HttpResponseMessage CreateGame(CreateGameRequest request)
        {            
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.Claims;
            var userId = claims.Single(c => c.Type == "userid").Value;
            request.UserId = userId;

            var gameService = new GameService(new MockGameRepository(), new GeographyRepository());
            gameService.CreateGame(request);
            return new HttpResponseMessage(HttpStatusCode.Created);                        
        }

        [Route("api/games/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateGame(string id, EditGameRequest request)
        {
            var game = GamesMapper.ConvertGameModelToGame(request);
            var gameService = new GameService(new MockGameRepository(), new GeographyRepository());
            gameService.EditGame(new Guid(id), game);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("api/games/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteGame(string id)
        {
            var gameService = new GameService(new MockGameRepository(), new GeographyRepository());
            gameService.DeleteGame(new Guid(id));
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}