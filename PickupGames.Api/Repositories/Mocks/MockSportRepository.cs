using System;
using System.Collections.Generic;
using PickupGames.Api.Domain.Objects;
using PickupGames.Api.Repositories.Interfaces;

namespace PickupGames.Api.Repositories.Mocks
{
    public class MockSportRepository : ISportRepository
    {
        public static List<Sport> _sports = new List<Sport>
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
            return _sports;
        }
    }
}
