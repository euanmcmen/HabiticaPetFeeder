using HabiticaPetFeeder.Logic.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace HabiticaPetFeeder.Logic.Service.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> logger;

        public AuthenticationService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<AuthenticationService>();
        }

        public string GetAuthenticationTokenForUser(UserApiAuthInfo userApiAuthInfo)
        {
            if (userApiAuthInfo is null || string.IsNullOrEmpty(userApiAuthInfo.ApiUserId) || string.IsNullOrEmpty(userApiAuthInfo.ApiUserKey))
                throw new ArgumentNullException(nameof(userApiAuthInfo));

            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userApiAuthInfo.ApiUserId}:{userApiAuthInfo.ApiUserKey}"));
        }
    }
}
