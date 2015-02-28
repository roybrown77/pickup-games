using System;
using System.Collections.Generic;
using PickupGames.Domain.Objects;
using PickupGames.Repositories.Interfaces;

namespace PickupGames.Repositories.Mocks
{
    public class MockGameRepository : IGameRepository
    {
        public static List<Game> _games = new List<Game>();
 
        public void Add(Game game)
        {
            _games.Add(game);
        }

        public void Edit(Game game)
        {
            var gameFound = _games.Find(x => x.Id == game.Id);
            if (gameFound != null)
            {
                gameFound = game;
            }
            
            throw new Exception("GameNotFound");
        }

        public List<Game> FindAll()
        {
            return new List<Game>();
        }

        public List<Game> FindBy(string location)
        {
            return _games.FindAll(x => x.Location == location);

            //return new List<Game>
            //{
            //    new Game
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "touch football",
            //        Sport = "Football",
            //        GameDate = DateTime.Now.Date,
            //        GameTime = DateTime.Now.TimeOfDay,
            //        Location = "Attleboro, MA",
            //        LocationLat = "41.944544",
            //        LocationLng = "-71.285608",
            //        PlayerCount = 6
            //    }
            //};
        }

        public List<Game> FindBy(GameSearchQuery gameSearchQuery)
        {
            return _games.FindAll(x => x.Location == gameSearchQuery.Location);

            //if (gameSearchQuery.Index % 2 == 1)
            //{
            //    return new List<Game>
            //           {
            //               new Game
            //                   {
            //                       Id = Guid.NewGuid(),
            //                       Name = "touch football",
            //                       Sport = "Football",
            //                       GameDate = DateTime.Now.Date,
            //                       GameTime = DateTime.Now.TimeOfDay,
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
            //                       GameDate = DateTime.Now.Date,
            //                       GameTime = DateTime.Now.TimeOfDay,
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
            //                       GameDate = DateTime.Now.Date,
            //                       GameTime = DateTime.Now.TimeOfDay,
            //                       Location = "Chicago, IL",
            //                       LocationLat = "41.878114",
            //                       LocationLng = "-87.629798",
            //                       PlayerCount = 6
            //                   },
            //           };
            //}

            //return new List<Game>
            //{
            //    new Game
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "3 on 3 basketball",
            //        Sport = "Basketball",
            //        GameDate = DateTime.Now.Date,
            //        GameTime = DateTime.Now.TimeOfDay,
            //        Location = "Medford, MA",
            //        LocationLat = "42.418430",
            //        LocationLng = "-71.106164",
            //        PlayerCount = 8
            //    },
            //    new Game
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "touch football",
            //        Sport = "Football",
            //        GameDate = DateTime.Now.Date,
            //        GameTime = DateTime.Now.TimeOfDay,
            //        Location = "Somerville, MA",
            //        LocationLat = "42.387597",
            //        LocationLng = "-71.099497",
            //        PlayerCount = 6
            //    }
            //};
        }
    }
}
