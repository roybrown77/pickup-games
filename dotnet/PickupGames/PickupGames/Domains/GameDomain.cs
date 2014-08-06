using System;
using PickupGames.Domain.Objects;
using PickupGames.Repositories;

namespace PickupGames.Domains
{
    public class GameDomain
    {
        private readonly IGameRepository _gameRepository;

        public GameDomain() : this(new GameRepository())
        {
        }

        public GameDomain(IGameRepository repository)
        {
            _gameRepository = repository;
        }

        public BasicResponse CreateGame(Game game)
        {
            try
            {
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

        public GameSearchResponse GetBy(string location)
        {
            try
            {
                return new GameSearchResponse
                           {
                               Status = "Success",
                               Games = _gameRepository.FindBy(location)
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
                return new GameSearchResponse
                {
                    Status = "Success",
                    Games = _gameRepository.FindBy(searchQuery)
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