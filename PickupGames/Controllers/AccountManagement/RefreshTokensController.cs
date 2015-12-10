using System.Threading.Tasks;
using System.Web.Http;
using PickupGames.Domain.AccountManagement.Services;

namespace PickupGames.Controllers.AccountManagement
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