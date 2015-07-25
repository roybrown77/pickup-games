using System.Threading.Tasks;
using System.Web.Http;
using Ninject;
using PickupGames.Repositories;
using PickupGames.Repositories.Interfaces;
using PickupGames.Utilities.DependencyInjector;
using PickupGames.Services;

namespace PickupGames.Controllers
{
    [RoutePrefix("api/RefreshTokens")]
    public class RefreshTokensController : ApiController
    {
        [Authorize(Users = "Admin")]
        [Route("")]
        public IHttpActionResult Get()
        {
            var authService = new AuthService();
            return Ok(authService.GetAllRefreshTokens());
        }

        //[Authorize(Users = "Admin")]
        [AllowAnonymous]
        [Route("")]
        public async Task<IHttpActionResult> Delete(string tokenId)
        {
            var authService = new AuthService();
            var result = await authService.RemoveRefreshToken(tokenId);

            if (result)
            {
                return Ok();
            }

            return BadRequest("Token Id does not exist");
        }
    }
}