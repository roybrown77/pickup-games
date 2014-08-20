using System;
using System.Collections.Generic;
using PickupGames.Domain.Objects;
using PickupGames.Repositories.Interfaces;

namespace PickupGames.Repositories.Mocks
{
    public class MockGameRepository : IGameRepository
    {
        public void Add(Game game)
        {
        }

        public List<Game> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<Game> FindAll(GameSearchRequest request)
        {
            throw new NotImplementedException();
        }

        public List<Game> FindBy(string location)
        {
            throw new NotImplementedException();
        }

        public List<Game> FindBy(string location, GameSearchRequest request)
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
                }
            };
        }

        public List<Game> FindBy(SearchQuery searchQuery)
        {
            throw new NotImplementedException();
        }

        public List<Game> FindBy(SearchQuery searchQuery, GameSearchRequest request)
        {
            var temp = new GoogleGeographyRepository();

            if (request.Index% 2 == 1)
            {
                return new List<Game>
                       {
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
                                   Name = "touch football",
                                   Sport = "Football",
                                   GameDate = DateTime.Now.Date,
                                   GameTime = DateTime.Now.TimeOfDay,
                                   Location = "Brookline, MA",
                                   LocationLat = temp.GetCoordinates("Brookline, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Brookline, MA").Lng,
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
                                   Location = "Malden, MA",
                                   LocationLat = temp.GetCoordinates("Malden, MA").Lat,
                                   LocationLng = temp.GetCoordinates("Malden, MA").Lng,
                                   PlayerCount = 6
                               }
                       };
            }

            return new List<Game>
            {
                new Game
                {
                    Id = Guid.NewGuid(),
                    Name = "3 on 3 basketball",
                    Sport = "Basketball",
                    GameDate = DateTime.Now.Date,
                    GameTime = DateTime.Now.TimeOfDay,
                    Location = "Medford, MA",
                    LocationLat = temp.GetCoordinates("Medford, MA").Lat,
                    LocationLng = temp.GetCoordinates("Medford, MA").Lng,
                    PlayerCount = 8
                },
                new Game
                {
                    Id = Guid.NewGuid(),
                    Name = "touch football",
                    Sport = "Football",
                    GameDate = DateTime.Now.Date,
                    GameTime = DateTime.Now.TimeOfDay,
                    Location = "Somerville, MA",
                    LocationLat = temp.GetCoordinates("Somerville, MA").Lat,
                    LocationLng = temp.GetCoordinates("Somerville, MA").Lng,
                    PlayerCount = 6
                },
                new Game
                {
                    Id = Guid.NewGuid(),
                    Name = "touch football",
                    Sport = "Football",
                    GameDate = DateTime.Now.Date,
                    GameTime = DateTime.Now.TimeOfDay,
                    Location = "Waltham, MA",
                    LocationLat = temp.GetCoordinates("Waltham, MA").Lat,
                    LocationLng = temp.GetCoordinates("Waltham, MA").Lng,
                    PlayerCount = 6
                },
                new Game
                {
                    Id = Guid.NewGuid(),
                    Name = "3 on 3 basketball",
                    Sport = "Basketball",
                    GameDate = DateTime.Now.Date,
                    GameTime = DateTime.Now.TimeOfDay,
                    Location = "Watertown, MA",
                    LocationLat = temp.GetCoordinates("Watertown, MA").Lat,
                    LocationLng = temp.GetCoordinates("Watertown, MA").Lng,
                    PlayerCount = 8
                }
            };
        }
    }
}
