using System.Collections.Generic;
using PickupGames.Domain.Objects;

namespace PickupGames.Repositories.Interfaces
{
    public interface ISportRepository
    {
        List<Sport> FindAll();
    }
}
