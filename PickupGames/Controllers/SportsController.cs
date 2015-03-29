using System.Net;
using System.Net.Http;
using System.Web.Http;
using PickupGames.Domain.Objects;
using PickupGames.Domains;
using PickupGames.Mappers;
using PickupGames.Models;

namespace PickupGames.Controllers
{
    public class SportsController : ApiControllerBase
    {
        [System.Web.Mvc.Route("api/v1/sports")]
        public SportListResponse Get()
        {
            var domain = new SportDomain();
            var response = domain.FindAll();
            return response;
        }

        //[System.Web.Mvc.Route("~/api/v2/sports/")]
        //[HttpGet]
        //public SportListResponse GetV2()
        //{
        //    var domain = new SportDomain();
        //    var response = domain.FindAll();
        //    return response;
        //}
    }
}