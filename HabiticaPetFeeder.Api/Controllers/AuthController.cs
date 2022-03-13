using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace HabiticaPetFeeder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> logger;
        private readonly IAuthenticationService authenticationService;

        public AuthController(ILoggerFactory loggerFactory, IAuthenticationService authenticationService)
        {
            logger = loggerFactory.CreateLogger<AuthController>();

            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("token")]
        public IActionResult GetAuthenticationTokenForUser(UserApiAuthInfo userApiAuthInfo)
        {
            try
            {
                var authenticationToken = authenticationService.GetAuthenticationTokenForUserAuth(userApiAuthInfo);
                return Ok(authenticationToken);
            }
            catch (ArgumentNullException ane)
            {
                logger.LogError(ane, $"A controller exception was caught. The user has passed invalid credentials. Message: {ane.Message}");
                return BadRequest();
            }
            catch (Exception e)
            {
                logger.LogError(exception: e, message: $"A general controller exception was caught. Message: {e.Message}");
                return StatusCode(500);
            }
        }
    }
}
