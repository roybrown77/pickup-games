using System.Collections.Generic;
using PickupGames.Models;

namespace PickupGames.Repositories.Interfaces
{
    public interface ISportRepository
    {
        List<Sport> FindAll();
    }
}
