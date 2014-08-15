using System;
using PickupGames.Domain.Objects;
using PickupGames.Repositories;

namespace PickupGames.Domains
{
    public class GameDomain
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGeographyRepository _geographyRepository;

        public GameDomain() 
            : this(new GameRepository(), new GoogleGeographyRepository())
        {
        }

        public GameDomain(IGameRepository gameRepository, IGeographyRepository geographyRepository)
        {
            _gameRepository = gameRepository;
            _geographyRepository = geographyRepository;
        }

        public BasicResponse CreateGame(Game game)
        {
            try
            {
                var coordinates = _geographyRepository.GetCoordinates(game.Location);
                game.LocationLat = coordinates.Lat;
                game.LocationLng = coordinates.Lng;

                _gameRepository.Add(game);

                return new BasicResponse
                {
                    Status = "Success"
                };
            }
            catch (Exception ex)
            {
                return new BasicResponse
                {
                    Status = "Failed",
                    Message = ex.Message
                };
            }
        }

        public GameSearchResponse FindBy(string location)
        {
            try
            {
                var coordinates = _geographyRepository.GetCoordinates(location);                

                return new GameSearchResponse
                           {
                               Status = "Success",
                               Games = _gameRepository.FindBy(location),
                               SearchLocationLat = coordinates.Lat,
                               SearchLocationLng = coordinates.Lng
                           };
            }
            catch (Exception ex)
            {
                return new GameSearchResponse
                           {
                               Status = "Failed",
                               Message = ex.Message
                           };
            }
        }

        public GameSearchResponse FindBy(SearchQuery searchQuery)
        {
            try
            {
                var coordinates = _geographyRepository.GetCoordinates(searchQuery.Location);

                return new GameSearchResponse
                {
                    Status = "Success",
                    Games = _gameRepository.FindBy(searchQuery),
                    SearchLocationLat = coordinates.Lat,
                    SearchLocationLng = coordinates.Lng
                };
            }
            catch (Exception ex)
            {
                return new GameSearchResponse
                {
                    Status = "Failed",
                    Message = ex.Message
                };
            }
        }
    }
}