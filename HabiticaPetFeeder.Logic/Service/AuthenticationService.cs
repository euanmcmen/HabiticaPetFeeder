using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace HabiticaPetFeeder.Logic.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly ILogger<AuthenticationService> logger;
    private readonly IEncryptionService encryptionService;

    public AuthenticationService(ILoggerFactory loggerFactory, IEncryptionService encryptionService)
    {
        logger = loggerFactory.CreateLogger<AuthenticationService>();
        this.encryptionService = encryptionService;
    }

    public string GetAuthenticationTokenForUserAuth(UserApiAuthInfo userApiAuthInfo)
    {
        var encryptedUserBasicAuth = encryptionService.Encrypt($"{userApiAuthInfo.ApiUserId}:{userApiAuthInfo.ApiUserKey}");

        var encodedEncryptedUserBasicAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes(encryptedUserBasicAuth));

        return encodedEncryptedUserBasicAuth;

        //CredentialPair -> PlainText -> EncryptedPlainText -> Base64 EncryptedPlainText
    }

    public UserApiAuthInfo GetUserAuthFromAuthenticationToken(string authenticationToken)
    {
        var encryptedUserBasicAuth = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));

        var userBasicAuth = encryptionService.Decrypt(encryptedUserBasicAuth);

        var userBasicAuthParts = userBasicAuth.Split(new char[] { ':' });

        return new UserApiAuthInfo(userBasicAuthParts[0], userBasicAuthParts[1]);
    }
}
