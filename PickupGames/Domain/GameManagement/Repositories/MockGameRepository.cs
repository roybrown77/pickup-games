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

        public List<Game> FindAll()
        {
            return GetGames();
        }

        public List<Game> FindBy(string address)
        {
            return GetGames();            
        }

        public List<Game> FindBy(GameSearchQuery gameSearchQuery)
        {
            return GetGames();            
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
