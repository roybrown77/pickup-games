namespace PickupGames.Infrastructure.Domain.Events
{
    public interface IDomainEventDispatcher
    {
        void Raise<T>(T domainEvent) where T : IDomainEvent;
    }
}