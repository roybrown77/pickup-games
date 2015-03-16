﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using PickupGames.Domain.Objects;
using PickupGames.Domains;
using PickupGames.Mappers;
using PickupGames.Models;

namespace PickupGames.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/v1/sports")]
    public class SportsController : ApiControllerBase
    {
        public SportListResponse Get()
        {
            var domain = new SportDomain();
            var response = domain.FindAll();
            return response;
        }
    }
}