using PickupGames.Objects;
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
            _gameRepository.Add(game);
            return new BasicResponse{ Status = "Success"};
        }
    }
}