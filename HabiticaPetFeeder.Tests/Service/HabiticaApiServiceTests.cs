using HabiticaPetFeeder.Logic.Client.Interface;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service;
using Microsoft.Extensions.Options;
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

        HabiticaApiService = new HabiticaApiService(
            TestHelpers.GetMockedLogFactoryForType<HabiticaApiService>().Object, 
            MockApiClient.Object, 
            Options.Create(new HabiticaApiSettings() { RateLimitThrottleThreshold = 20, UseLiveEndpoint = false, RateLimitThrottleDurationSeconds = 3 })
        );
    }
}

public class HabiticaApiServiceTests : IClassFixture<HabiticaApiServiceTests_Fixture>
{
    protected readonly HabiticaApiServiceTests_Fixture fixture;

    public HabiticaApiServiceTests(HabiticaApiServiceTests_Fixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task GetHabiticaUserAsync_ReturnsUserAndContentData()
    {
        var request = new AuthenticatedApiRequest()
        {
            UserApiAuthInfo = new UserApiAuthInfo("test-key", "test-id")
        };

        fixture.MockApiClient.Setup(x => x.GetUserAsync())
            .ReturnsAsync(new RateLimitedApiResponse<UserResponse>()
            {
                Body = new UserResponse() { success = true },
                RateLimitInfo = new RateLimitInfo() { RateLimitRemaining = 30 }
            });

        fixture.MockApiClient.Setup(x => x.GetContentAsync())
            .ReturnsAsync(new RateLimitedApiResponse<ContentResponse>
            {
                Body = new ContentResponse() { success = true },
                RateLimitInfo = new RateLimitInfo()
                {
                    RateLimitRemaining = 29
                }
            });

        var result = await fixture.HabiticaApiService.GetHabiticaUserAsync(request);

        Assert.True(result.Body.User.success);
        Assert.True(result.Body.Content.success);
        Assert.Equal(29, result.RateLimitInfo.RateLimitRemaining);
    }

    [Fact]
    public async Task FeedPetFoodAsync_ThrowsNotImplementedException()
    {
        await Assert.ThrowsAsync<NotImplementedException>(() => fixture.HabiticaApiService.FeedPetFoodAsync(null));
    }
}
