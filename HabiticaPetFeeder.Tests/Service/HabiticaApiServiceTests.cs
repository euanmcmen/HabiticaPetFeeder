using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.FeedResponse;
using HabiticaPetFeeder.Logic.Service;
using Moq;
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
        var request = new AuthenticatedRateLimitedApiRequest() { RateLimitRemaining = 30, UserApiAuthInfo = new UserApiAuthInfo("test-key", "test-id") };

        fixture.MockApiClient.Setup(x => x.GetUserAsync())
            .ReturnsAsync(new RateLimitedApiResponse<UserResponse>() { Response = new UserResponse() { success = true }, RateLimitRemaining = 30 });

        fixture.MockApiClient.Setup(x => x.GetContentAsync())
            .ReturnsAsync(new RateLimitedApiResponse<ContentResponse> { Response = new ContentResponse() { success = true }, RateLimitRemaining = 29 });

        var result = await fixture.HabiticaApiService.GetHabiticaUserAsync(request);

        Assert.True(result.Response.User.success);
        Assert.True(result.Response.Content.success);
        Assert.Equal(29, result.RateLimitRemaining.Value);
    }

    [Fact]
    public async Task FeedPetFoodAsync_ReturnsFeedResult()
    {
        var request = new AuthenticatedRateLimitedApiRequest<PetFoodFeed>
        {
            RateLimitRemaining = 25,
            Request = new PetFoodFeed("test-pet-name", "test-food-name", 1, false),
            UserApiAuthInfo = new UserApiAuthInfo("test-key", "test-id")
        };

        fixture.MockApiClient.Setup(x => x.FeedPetFoodAsync(It.IsAny<PetFoodFeed>()))
            .ReturnsAsync(new RateLimitedApiResponse<FeedResponse>() { Response = new FeedResponse() { success = true }, RateLimitRemaining = 24 });

        var response = await fixture.HabiticaApiService.FeedPetFoodAsync(request);

        Assert.Equal(24, response.RateLimitRemaining);
    }
}
