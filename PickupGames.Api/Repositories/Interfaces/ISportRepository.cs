using System.Collections.Generic;
using PickupGames.Api.Domain.Objects;

namespace PickupGames.Api.Repositories.Interfaces
{
    public interface ISportRepository
    {
        List<Sport> FindAll();
    }
}
