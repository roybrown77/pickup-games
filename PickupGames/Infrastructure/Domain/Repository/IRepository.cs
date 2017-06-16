using PickupGames.Infrastructure.Domain.Models;

namespace PickupGames.Infrastructure.Domain.Repository
{
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);
    }
}
