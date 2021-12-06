using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.HabiticaApi;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service
{
    public class HabiticaApiServiceTests_Fixture
    {
        public HabiticaApiService HabiticaApiService { get; private set; }

        public Mock<IHabiticaApiClient> MockApiClient { get; private set; }

        public HabiticaApiServiceTests_Fixture()
        {
            MockApiClient = new Mock<IHabiticaApiClient>();

            HabiticaApiService= new HabiticaApiService(TestHelpers.GetMockedLogFactoryForType<HabiticaApiService>().Object, MockApiClient.Object);
        }
    }

    public class HabiticaApiServiceTests : IClassFixture<HabiticaApiServiceTests_Fixture>
    {
        private readonly HabiticaApiServiceTests_Fixture fixture;

        public HabiticaApiServiceTests(HabiticaApiServiceTests_Fixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task GetHabiticaUserAsync_returns_user_and_content_data()
        {
            var testCredentials = new UserApiAuthInfo() { ApiKey = "test-key", ApiUserId = "test-id" };

            fixture.MockApiClient.Setup(x => x.GetUserAsync()).ReturnsAsync(new Logic.Model.UserResponse.UserResponse() { success = true });

            fixture.MockApiClient.Setup(x => x.GetContentAsync()).ReturnsAsync(new Logic.Model.ContentResponse.ContentResponse() { success = true });

            var (userResult, contentresult)= await fixture.HabiticaApiService.GetHabiticaUserAsync(testCredentials);

            Assert.True(userResult.success);
            Assert.True(contentresult.success);
        }

        [Fact]
        public async Task GetHabiticaUserAsync_throws_exception_on_null_credentials()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => fixture.HabiticaApiService.GetHabiticaUserAsync(null));
        }
    }
}
