using System.Collections.Generic;

namespace PickupGames.Infrastructure.Domain.Events
{
    public class StructureMapDomainEventHandlerFactory : IDomainEventHandlerFactory
    {
        private readonly IContainer _container;

        public StructureMapDomainEventHandlerFactory(IContainer container)
        {
            _container = container;
        }

        public IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>(T domainEvent) where T : IDomainEvent
        {
            return _container.GetAllInstances<IDomainEventHandler<T>>();
        }
    }
}
