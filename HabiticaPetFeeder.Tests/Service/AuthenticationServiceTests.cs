using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Authentication;
using HabiticaPetFeeder.Logic.Service.Encryption;
using Moq;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service
{
    public class AuthenticationServiceTests_Fixture
    {
        public IAuthenticationService AuthenticationService { get; private set; }

        public Mock<IEncryptionService> MockEncryptionService { get; private set; }

        public AuthenticationServiceTests_Fixture()
        {
            MockEncryptionService = new Mock<IEncryptionService>();

            AuthenticationService = new AuthenticationService(TestHelpers.GetMockedLogFactoryForType<AuthenticationService>().Object, MockEncryptionService.Object);
        }
    }

    public class AuthenticationServiceTests : IClassFixture<AuthenticationServiceTests_Fixture>
    {
        private readonly AuthenticationServiceTests_Fixture fixture;

        public AuthenticationServiceTests(AuthenticationServiceTests_Fixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void GetAuthenticationTokenForUser_ReturnsBase64EncodedUserIdAndKey()
        {
            const string expected = "dGVzdFVzZXI6dGVzdEtleQ==";
            var input = new UserApiAuthInfo("testUser", "unencryptedTestKey");

            fixture.MockEncryptionService.Setup(x => x.Encrypt(input.ApiUserKey)).Returns("testKey");

            var actual = fixture.AuthenticationService.GetAuthenticationTokenForUser(input);

            Assert.Equal(expected, actual);
        }
    }
}