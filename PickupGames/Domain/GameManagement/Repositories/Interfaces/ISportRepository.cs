using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Models;

namespace PickupGames.Domain.GameManagement.Repositories.Interfaces
{
    public interface ISportRepository
    {
        List<Sport> FindAll();
    }
}
