using System.Threading.Tasks;
using System.Web.Http;
using PickupGames.Domain.AccountManagement.Repositories;
using PickupGames.Domain.AccountManagement.Services;
using PickupGames.Domain.AccountManagement.Services.Interfaces;
using PickupGames.Domain.AccountManagement.Services.Messaging;

namespace PickupGames.Controllers.AccountManagement
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IAuthService _authService;

        [Route("Register")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authService = new AuthService(new MockAuthRepository());
            await authService.RegisterUser(request);
            return Ok();
        }
    }
}