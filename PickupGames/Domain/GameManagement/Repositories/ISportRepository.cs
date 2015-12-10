using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Models;

namespace PickupGames.Domain.GameManagement.Repositories
{
    public interface ISportRepository
    {
        List<Sport> FindAll();
    }
}
