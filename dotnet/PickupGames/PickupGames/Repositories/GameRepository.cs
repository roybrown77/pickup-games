using System;
using System.Collections.Generic;
using PickupGames.Domain.Objects;

namespace PickupGames.Repositories
{
    public class GameRepository : IGameRepository
    {
        public void Add(Game game)
        {
        }

        public List<Game> FindBy(string location)
        {
            return new List<Game>
                       {
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
                       };
        }

        public List<Game> FindBy(SearchQuery searchQuery)
        {
            return new List<Game>
                       {
                           new Game
                               {
                                   Name = "touch football",
                                   Sport = "Football",
                                   GameTime = DateTime.Now,
                                   Location = "Boston, MA",
                                   PlayerCount = 6,
                                   DistanceToLocation = "5.5 mi"
                               }
                       };
        }
    }
}
