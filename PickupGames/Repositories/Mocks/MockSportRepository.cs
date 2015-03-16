using System;
using System.Collections.Generic;
using PickupGames.Domain.Objects;
using PickupGames.Repositories.Interfaces;

namespace PickupGames.Repositories.Mocks
{
    public class MockSportRepository : ISportRepository
    {
        public static List<Sport> _sports = new List<Sport>
            {
                new Sport 
                {
                    Id = Guid.NewGuid(),
                    Name = "basketball"
                },

                new Sport 
                {
                    Id = Guid.NewGuid(),
                    Name = "football"
                }
            };

        public List<Sport> FindAll()
        {
            return _sports;
        }
    }
}
