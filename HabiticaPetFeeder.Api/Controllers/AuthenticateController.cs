using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace HabiticaPetFeeder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ILogger<AuthenticateController> logger;
        private readonly IAuthenticationService authenticationService;

        public AuthenticateController(ILoggerFactory loggerFactory, IAuthenticationService authenticationService)
        {
            logger = loggerFactory.CreateLogger<AuthenticateController>();

            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult GetAuthenticationTokenForUser(UserApiAuthInfo userApiAuthInfo)
        {
            if (userApiAuthInfo is null) return Unauthorized();

            var authenticationToken = authenticationService.GetAuthenticationTokenForUser(userApiAuthInfo);

            logger.LogInformation($"User Id: {userApiAuthInfo.ApiUserId} | Auth token generated: {authenticationToken}");

            return Ok(authenticationToken);
        }
    }
}
