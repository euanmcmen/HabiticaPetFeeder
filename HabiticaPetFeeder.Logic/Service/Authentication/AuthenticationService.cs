using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Encryption;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace HabiticaPetFeeder.Logic.Service.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> logger;
        private readonly IEncryptionService encryptionService;

        public AuthenticationService(ILoggerFactory loggerFactory, IEncryptionService encryptionService)
        {
            logger = loggerFactory.CreateLogger<AuthenticationService>();
            this.encryptionService = encryptionService;
        }

        public string GetAuthenticationTokenForUser(UserApiAuthInfo userApiAuthInfo)
        {
            if (userApiAuthInfo is null || string.IsNullOrEmpty(userApiAuthInfo.ApiUserId) || string.IsNullOrEmpty(userApiAuthInfo.ApiUserKey))
                throw new ArgumentNullException(nameof(userApiAuthInfo));

            var encryptedUserKey = encryptionService.Encrypt(userApiAuthInfo.ApiUserKey);

            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userApiAuthInfo.ApiUserId}:{encryptedUserKey}"));
        }
    }
}
