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
            var temp = new GoogleGeographyRepository();

            return new List<Game>
                       {
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "street hockey",
                                   Sport = "Hockey",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Attleboro, MA",
                                   LocationLat = temp.GetCoordinates("Attleboro, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Attleboro, MA").Lng,
                                   PlayerCount = 6
                               }
                       };
        }

        public List<Game> FindBy(SearchQuery searchQuery)
        {
            var temp = new GoogleGeographyRepository();

            return new List<Game>
                       {
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "touch football",
                                   Sport = "Football",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Attleboro, MA",
                                   LocationLat = temp.GetCoordinates("Attleboro, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Attleboro, MA").Lng,
                                   PlayerCount = 6
                               },
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "touch football",
                                   Sport = "Football",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Boston, MA",
                                   LocationLat = temp.GetCoordinates("Boston, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Boston, MA").Lng,
                                   PlayerCount = 6
                               },
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "3 on 3 basketball",
                                   Sport = "Basketball",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Canton, MA",
                                   LocationLat = temp.GetCoordinates("Canton, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Canton, MA").Lng,
                                   PlayerCount = 8
                               },
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "touch football",
                                   Sport = "Football",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Dedham, MA",
                                   LocationLat = temp.GetCoordinates("Dedham, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Dedham, MA").Lng,
                                   PlayerCount = 6
                               },
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "3 on 3 basketball",
                                   Sport = "Basketball",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "East Boston, MA",
                                   LocationLat = temp.GetCoordinates("East Boston, MA").Lat,
                                   LocationLng = temp.GetCoordinates("East Boston, MA").Lng,
                                   PlayerCount = 8
                               },
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "touch football",
                                   Sport = "Football",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Fall River, MA",
                                   LocationLat = temp.GetCoordinates("Fall River, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Fall River, MA").Lng,
                                   PlayerCount = 6
                               },
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "touch football",
                                   Sport = "Football",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Hyde Park, MA",
                                   LocationLat = temp.GetCoordinates("Attleboro, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Attleboro, MA").Lng,
                                   PlayerCount = 6
                               }/*,
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "3 on 3 basketball",
                                   Sport = "Basketball",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Ipswich, MA",
                                   LocationLat = temp.GetCoordinates("Ipswich, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Ipswich, MA").Lng,
                                   PlayerCount = 8
                               },
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "touch football",
                                   Sport = "Football",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Lowell, MA",
                                   LocationLat = temp.GetCoordinates("Lowell, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Lowell, MA").Lng,
                                   PlayerCount = 6
                               },
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "3 on 3 basketball",
                                   Sport = "Basketball",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Mattapan, MA",
                                   LocationLat = temp.GetCoordinates("Mattapan, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Mattapan, MA").Lng,
                                   PlayerCount = 8
                               },
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "touch football",
                                   Sport = "Football",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Newton, MA",
                                   LocationLat = temp.GetCoordinates("Newton, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Newton, MA").Lng,
                                   PlayerCount = 6
                               },
                           new Game
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "3 on 3 basketball",
                                   Sport = "Basketball",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Waltham, MA",
                                   LocationLat = temp.GetCoordinates("Waltham, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Waltham, MA").Lng,
                                   PlayerCount = 8
                               }*/
                       };
        }
    }
}
