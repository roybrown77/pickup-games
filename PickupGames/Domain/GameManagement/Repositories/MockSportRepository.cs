using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Models;

namespace PickupGames.Domain.GameManagement.Repositories
{
    public class MockSportRepository : ISportRepository
    {
        public static List<Sport> Sports = new List<Sport>
            {
                new Sport 
                {
                    Id = "basketball",
                    Name = "basketball"
                },

                new Sport 
                {
                    Id = "football",
                    Name = "football"
                }
            };

        public List<Sport> FindAll()
        {
            return Sports;
        }
    }
}
