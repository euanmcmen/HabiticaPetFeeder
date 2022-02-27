using FakeItEasy;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Proxy.Interface;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service;

public class AuthenticationServiceTests_Fixture
{
    public IAuthenticationService AuthenticationService { get; private set; }

    public IEncryptionService EncryptionService { get; private set; }

    public AuthenticationServiceTests_Fixture()
    {
        EncryptionService = A.Fake<IEncryptionService>();

        AuthenticationService = new AuthenticationService(TestHelpers.GetFakeLoggerFactoryForType<AuthenticationService>(), EncryptionService);
    }
}

public class AuthenticationServiceTests : IClassFixture<AuthenticationServiceTests_Fixture>
{
    private readonly AuthenticationServiceTests_Fixture fixture;

    private readonly UserApiAuthInfo testAuthInfo = new UserApiAuthInfo("testUser", "testKey");

    private const string PlainText = "testUser:testKey";
    private const string Encrypted_PlainText = "encrypted";
    private const string Encoded_Encrypted_PlainText = "ZW5jcnlwdGVk";



    public AuthenticationServiceTests(AuthenticationServiceTests_Fixture fixture)
    {
        this.fixture = fixture;

        A.CallTo(() => fixture.EncryptionService.Encrypt(PlainText)).Returns(Encrypted_PlainText);
        A.CallTo(() => fixture.EncryptionService.Decrypt(Encrypted_PlainText)).Returns(PlainText);
    }

    [Fact]
    public void GetAuthenticationTokenForUserAuth_ReturnsBase64EncodedUserIdAndKeyToken()
    {
        var actual = fixture.AuthenticationService.GetAuthenticationTokenForUserAuth(testAuthInfo);

        Assert.Equal(Encoded_Encrypted_PlainText, actual);
    }

    [Fact]
    public void GetUserAuthFromAuthenticationToken_ReturnsUserAuthFromToken()
    {
        var actual = fixture.AuthenticationService.GetUserAuthFromAuthenticationToken(Encoded_Encrypted_PlainText);

        Assert.Equal(testAuthInfo, actual);
    }
}
