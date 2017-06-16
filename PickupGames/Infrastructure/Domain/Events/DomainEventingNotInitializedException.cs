using System;

namespace PickupGames.Infrastructure.Domain.Events
{
    public class DomainEventingNotInitializedException : Exception
    {
        public DomainEventingNotInitializedException(string message)
            : base(message)
        {            
        }
    }
}
