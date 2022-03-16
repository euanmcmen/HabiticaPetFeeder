using FakeItEasy;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Proxy.Abstraction;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service;

public class AuthenticationServiceTests
{
    private readonly IAuthenticationService authenticationService;
    private readonly IEncryptionService encryptionService;

    private readonly UserApiAuthInfo testAuthInfo = new UserApiAuthInfo("testUser", "testKey");

    private const string PlainText = "testUser:testKey";
    private const string Encrypted_PlainText = "encrypted";
    private const string Encoded_Encrypted_PlainText = "ZW5jcnlwdGVk";

    public AuthenticationServiceTests()
    {
        encryptionService = A.Fake<IEncryptionService>();

        authenticationService = new AuthenticationService(TestHelpers.GetFakeLoggerFactoryForType<AuthenticationService>(), encryptionService);

        A.CallTo(() => encryptionService.Encrypt(PlainText)).Returns(Encrypted_PlainText);
        A.CallTo(() => encryptionService.Decrypt(Encrypted_PlainText)).Returns(PlainText);
    }

    [Fact]
    public void GetAuthenticationTokenForUserAuth_ReturnsBase64EncodedUserIdAndKeyToken()
    {
        var actual = authenticationService.GetAuthenticationTokenForUserAuth(testAuthInfo);

        Assert.Equal(Encoded_Encrypted_PlainText, actual);
    }

    [Fact]
    public void GetUserAuthFromAuthenticationToken_ReturnsUserAuthFromToken()
    {
        var actual = authenticationService.GetUserAuthFromAuthenticationToken(Encoded_Encrypted_PlainText);

        Assert.Equal(testAuthInfo, actual);
    }
}
