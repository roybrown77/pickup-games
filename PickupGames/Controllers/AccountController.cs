using System.Threading.Tasks;
using System.Web.Http;
using System;
using Microsoft.AspNet.Identity;
using Ninject;
using PickupGames.Repositories.Interfaces;
using PickupGames.Models;
using PickupGames.Repositories;
using PickupGames.ViewModels;
using PickupGames.Utilities.DependencyInjector;
using PickupGames.Services;

namespace PickupGames.Controllers
{
    [RoutePrefix("api/v1/Account")]
    public class AccountController : ApiController
    {
        [Route("Register")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> Register(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var authService = new AuthService();
                var result = await authService.RegisterUser(userModel);

                var errorResult = GetErrorResult(result);

                if (errorResult != null)
                {
                    return errorResult;
                }

                return Ok();
            }
            catch (Exception ex)
            {
                var temp = ex;
                return BadRequest(ex.Message);
            }
        }

        private IHttpActionResult GetErrorResult(ResponseResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}