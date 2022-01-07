using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Authentication;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service
{
    public class AuthenticationServiceTests_Fixture
    {
        public IAuthenticationService AuthenticationService { get; private set; }

        public AuthenticationServiceTests_Fixture()
        {
            AuthenticationService = new AuthenticationService(TestHelpers.GetMockedLogFactoryForType<AuthenticationService>().Object);
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
            var input = new UserApiAuthInfo() { ApiUserId = "testUser", ApiUserKey = "testKey" };

            var actual = fixture.AuthenticationService.GetAuthenticationTokenForUser(input);

            Assert.Equal(expected, actual);
        }
    }
}