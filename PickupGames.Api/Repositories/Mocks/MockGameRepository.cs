using System;
using System.Collections.Generic;
using PickupGames.Api.Domain.Objects;
using PickupGames.Api.Repositories.Interfaces;

namespace PickupGames.Api.Repositories.Mocks
{
    public class MockGameRepository : IGameRepository
    {
        public static Dictionary<Guid, Game> _games = new Dictionary<Guid, Game>();

        public void Add(Game game)
        {
            game.Id = Guid.NewGuid();
            _games.Add(game.Id, game);
        }

        public void Edit(Guid id, Game game)
        {
            if (_games.ContainsKey(id))
            {
                _games[id] = game;
            }
            
            throw new Exception("GameNotFoundToEdit");
        }

        public void Delete(Guid id)
        {
            if (_games.ContainsKey(id))
            {
                _games.Remove(id);
            }

            throw new Exception("GameNotFoundToDelete");
        }

        private List<Game> GetGames()
        {
            var gameList = new List<Game>();

            foreach (var game in _games)
            {
                game.Value.Sport.Name = GetSportName(game.Value.Sport.Id);
                gameList.Add(game.Value);
            }

            return gameList;
        }

        private string GetSportName(string sportId)
        {
            return MockSportRepository._sports.Find(x => x.Id == sportId).Name;
        }

        public List<Game> FindAll()
        {
            return GetGames();
        }

        public List<Game> FindBy(string location)
        {
            return GetGames();

            //return _games.FindAll(x => x.Location == location);
        }

        public List<Game> FindBy(GameSearchQuery gameSearchQuery)
        {
            //var games = new List<Game>();

            //if (gameSearchQuery.Index % 2 == 1)
            //{
            //    games = new List<Game>
            //           {
            //               new Game
            //                   {
            //                       Id = Guid.NewGuid(),
            //                       Name = "touch football",
            //                       Sport = "Football",
            //                       DateTime = DateTime.Now,
            //                       Location = "Boston, MA",
            //                       LocationLat = "42.358431",
            //                       LocationLng = "-71.059773",
            //                       PlayerCount = 6
            //                   },
            //               new Game
            //                   {
            //                       Id = Guid.NewGuid(),
            //                       Name = "touch football",
            //                       Sport = "Football",
            //                       DateTime = DateTime.Now.Date,
            //                       Location = "Brookline, MA",
            //                       LocationLat = "42.331764",
            //                       LocationLng = "-71.121163",
            //                       PlayerCount = 6
            //                   },
            //               new Game
            //                   {
            //                       Id = Guid.NewGuid(),
            //                       Name = "touch football",
            //                       Sport = "Football",
            //                       DateTime = DateTime.Now,
            //                       Location = "Chicago, IL",
            //                       LocationLat = "41.878114",
            //                       LocationLng = "-87.629798",
            //                       PlayerCount = 6
            //                   },
            //           };
            //}
            //else
            //{
            //    games = new List<Game>
            //            {
            //                new Game
            //                {
            //                    Id = Guid.NewGuid(),
            //                    Name = "3 on 3 basketball",
            //                    Sport = "Basketball",
            //                    DateTime = DateTime.Now,
            //                    Location = "Medford, MA",
            //                    LocationLat = "42.418430",
            //                    LocationLng = "-71.106164",
            //                    PlayerCount = 8
            //                },
            //                new Game
            //                {
            //                    Id = Guid.NewGuid(),
            //                    Name = "touch football",
            //                    Sport = "Football",
            //                    DateTime = DateTime.Now,
            //                    Location = "Somerville, MA",
            //                    LocationLat = "42.387597",
            //                    LocationLng = "-71.099497",
            //                    PlayerCount = 6
            //                }
            //            };    
            //}

            //_games = games;

            //return _games;

            return GetGames();
        }
    }
}
