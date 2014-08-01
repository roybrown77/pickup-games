using System;
using System.Collections.Generic;
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
            return new BasicResponse
                       {
                           Status = "Success",
                           Games = new List<Game>
                                       {
                                           new Game
                                               {
                                                   Name = game.Name,
                                                   Sport = game.Name,
                                                   GameTime = game.GameTime,
                                                   Location = game.Location,
                                                   PlayerCount = 20,
                                                   DistanceToLocation = "25.5 mi"
                                               },
                                           new Game
                                               {
                                                   Name = "touch football",
                                                   Sport = "Football",
                                                   GameTime = DateTime.Now,
                                                   Location = "Boston, MA",
                                                   PlayerCount = 6,
                                                   DistanceToLocation = "5.5 mi"
                                               },
                                           new Game
                                               {
                                                   Name = "3 on 3 basketball",
                                                   Sport = "Basketball",
                                                   GameTime = DateTime.Now.Add(new TimeSpan(3)),
                                                   Location = "Atlanta, GA",
                                                   PlayerCount = 8,
                                                   DistanceToLocation = "10.23 mi"
                                               } 
                                       }
                       };
        }
    }
}