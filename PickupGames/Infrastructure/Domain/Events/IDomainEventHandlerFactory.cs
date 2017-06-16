using System.Collections.Generic;

namespace PickupGames.Infrastructure.Domain.Events
{
    public interface IDomainEventHandlerFactory
    {
        IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>(T domainEvent) where T : IDomainEvent;
    }
}
