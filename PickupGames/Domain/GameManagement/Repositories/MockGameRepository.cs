using System;
using System.Collections.Generic;
using System.Net;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Domain.GameManagement.Repositories.Interfaces;
using PickupGames.Domain.GameManagement.Repositories.Messaging;
using PickupGames.Infrastructure.Exceptions;

namespace PickupGames.Domain.GameManagement.Repositories
{
    public class MockGameRepository : IGameRepository
    {
        public static List<Game> Games = new List<Game>();

        public MockGameRepository()
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

            //var games = new List<Game>
            //           {
            //               new Game
            //                   {
            //                       Id = Guid.NewGuid(),
            //                       Sport = new Sport { Id = "Football", Name = "Football"},
            //                       DateTime = DateTime.Now,
            //                       Location = new Location{Address = "Somerville, MA", Lat = "42.387597", Lng = "-71.099497"},
            //                       PlayerCount = 6
            //                   },
            //               new Game
            //                   {
            //                       Id = Guid.NewGuid(),
            //                       Sport = new Sport { Id = "Football", Name = "Football"},
            //                       DateTime = DateTime.Now.Date,
            //                       Location = new Location{Address = "Brookline, MA", Lat = "42.331764", Lng = "-71.121163" },
            //                       PlayerCount = 6
            //                   },
            //               new Game
            //                   {
            //                       Id = Guid.NewGuid(),
            //                       Sport = new Sport { Id = "Football", Name = "Football"},
            //                       DateTime = DateTime.Now,
            //                       Location = new Location{Address = "Chicago, IL", Lat = "41.878114", Lng = "-87.629798",},
            //                       PlayerCount = 6
            //                   },
            //           };
            
            //_games = new Dictionary<Guid, Game>();

            //foreach (var game in games)
            //{
            //    Add(game);
            //}
        }

        public List<Game> FindAll()
        {
            return GetGames();
        }

        public List<Game> FindBy(string address)
        {
            return GetGames();
            //var games = GetGames();
            //return games.FindAll(x => x.Location.Address == address);
        }

        public List<Game> FindBy(GameSearchQuery gameSearchQuery)
        {
            return GetGames();
            //var games = GetGames();
            //return games.FindAll(x => x.Location.Address == gameSearchQuery.Location || x.Sport.Id == gameSearchQuery.Sport || x.DateTime >= gameSearchQuery.GameTimeStart || x.DateTime <= gameSearchQuery.GameTimeEnd || x.DateTime.Date >= gameSearchQuery.GameDateStart || x.DateTime.Date <= gameSearchQuery.GameDateEnd);
        }

        public void Add(Game game)
        {
            Games.Add(game);
        }

        public void Save(Guid id, Game game)
        {
            var gameFound = Games.Find(x => x.Id == id);

            if (gameFound == null)
            {
                throw new ApplicationLayerException(HttpStatusCode.BadRequest, "Game does not exist: " + id);
            }

            gameFound.DateTime = game.DateTime;
            gameFound.Sport = game.Sport;
            gameFound.Location = game.Location;                                       
        }

        public void Delete(Guid id)
        {
            var gameFound = Games.Find(x => x.Id == id);
            Games.Remove(gameFound);            
        }

        private List<Game> GetGames()
        {
            var gameList = new List<Game>();

            foreach (var game in Games)
            {
                game.Sport.Name = GetSportName(game.Sport.Id);
                gameList.Add(game);
            }

            return gameList;
        }

        private string GetSportName(string sportId)
        {
            return MockSportRepository.Sports.Find(x => x.Id == sportId.ToLower()).Name;
        }        
    }
}
