using System.Collections.Generic;
using PickupGames.Infrastructure.Domain.Models;

namespace PickupGames.Infrastructure.Domain.Repository
{
    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        T FindBy(TId id);
        IEnumerable<T> FindAll();

        //following uses query object pattern to abstract sql construction
        //IEnumerable<T> FindBy(Query query);

        //following uses query object pattern to abstract sql construction with pagination parameters index and count
        //IEnumerable<T> FindBy(Query query, int index, int count);
    }
}
