using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.HabiticaApi;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service;

public class HabiticaApiServiceTests_Fixture
{
    public HabiticaApiService HabiticaApiService { get; private set; }

    public Mock<IHabiticaApiClient> MockApiClient { get; private set; }

    public HabiticaApiServiceTests_Fixture()
    {
        MockApiClient = new Mock<IHabiticaApiClient>();

        HabiticaApiService = new HabiticaApiService(TestHelpers.GetMockedLogFactoryForType<HabiticaApiService>().Object, MockApiClient.Object);
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
    public async Task GetHabiticaUserAsync_ReturnsUserAndContentData()
    {
        fixture.MockApiClient.Setup(x => x.GetUserAsync()).ReturnsAsync(new Logic.Model.UserResponse.UserResponse() { success = true });

        fixture.MockApiClient.Setup(x => x.GetContentAsync()).ReturnsAsync(new Logic.Model.ContentResponse.ContentResponse() { success = true });

        var (userResult, contentresult) = 
            await fixture.HabiticaApiService.GetHabiticaUserAsync(new UserApiAuthInfo() { ApiUserKey = "test-key", ApiUserId = "test-id" });

        Assert.True(userResult.success);
        Assert.True(contentresult.success);
    }

    [Fact]
    public async Task FeedPetFoodAsync_ReturnsFeedResult()
    {
        fixture.MockApiClient.Setup(x => x.FeedPetFoodAsync(It.IsAny<PetFoodFeed>())).ReturnsAsync(new Logic.Model.FeedResponse.FeedResponse() { success = true });

        var feedResult = await fixture.HabiticaApiService.FeedPetFoodAsync(
            new UserApiAuthInfo() { ApiUserKey = "test-key", ApiUserId = "test-id" },
            new PetFoodFeed("test-pet-name", "test-food-name", 1, false));

        Assert.True(feedResult.success);
    }

    [Fact]
    public async Task GetHabiticaUserAsync_ThrowsExceptionOnNullCredentials()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => fixture.HabiticaApiService.GetHabiticaUserAsync(null));
    }

    [Fact]
    public async Task FeedPetFoodAsync_ThrowsExceptionOnNullCredentials()
    {

        await Assert.ThrowsAsync<ArgumentNullException>(() => 
        fixture.HabiticaApiService.FeedPetFoodAsync(null, new PetFoodFeed("test-pet-name", "test-food-name", 1, false)));
    }

    [Fact]
    public async Task FeedPetFoodAsync_ThrowsExceptionOnNullPetFoodFeed()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => 
        fixture.HabiticaApiService.FeedPetFoodAsync(new UserApiAuthInfo() { ApiUserKey = "test-key", ApiUserId = "test-id" }, null));
    }
}
