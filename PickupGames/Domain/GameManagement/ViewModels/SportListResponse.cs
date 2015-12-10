using System.Collections.Generic;
using PickupGames.Domain.GameManagement.Models;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Domain.GameManagement.ViewModels
{
    public class SportListResponse : ResponseBase
    {
        public List<Sport> Sports { get; set; }
    }
}