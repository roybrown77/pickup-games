﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using PickupGames.Domain.AccountManagement.Repositories;
using PickupGames.Domain.AccountManagement.Services;
using PickupGames.Domain.AccountManagement.Services.Messaging;
using PickupGames.Infrastructure.Response;

namespace PickupGames.Controllers.AccountManagement
{
    [RoutePrefix("api/v1/Account")]
    public class AccountController : ApiController
    {
        private readonly IAuthService _authService;

        //public AccountController(IAuthService authService)
        //{
        //    _authService = new AuthService(new MockAuthRepository());
        //}

        [Route("Register")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> Register(RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var authService = new AuthService(new MockAuthRepository());
                var result = await authService.RegisterUser(request);

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