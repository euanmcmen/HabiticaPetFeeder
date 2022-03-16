using FakeItEasy;
using HabiticaPetFeeder.Logic.Client.Abstraction;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service;

public class HabiticaApiServiceTests
{
    private readonly HabiticaApiService habiticaApiService;
    private readonly IHabiticaApiClient habiticaApiClient;

    public HabiticaApiServiceTests()
    {
        habiticaApiClient = A.Fake<IHabiticaApiClient>();

        var habiticaApiSettings = new HabiticaApiSettings() { RateLimitThrottleThreshold = 20, UseLiveEndpoint = false, RateLimitThrottleDurationSeconds = 3 };

        habiticaApiService = new HabiticaApiService(TestHelpers.GetFakeLoggerFactoryForType<HabiticaApiService>(), habiticaApiClient, Options.Create(habiticaApiSettings));
    }

    [Fact]
    public async Task GetHabiticaUserAsync_ReturnsUserAndContentData()
    {
        var request = new AuthenticatedApiRequest()
        {
            UserApiAuthInfo = new UserApiAuthInfo("test-key", "test-id")
        };

        A.CallTo(() => habiticaApiClient.GetUserAsync()).Returns(new RateLimitedApiResponse<UserResponse>()
        {
            Body = new UserResponse() { success = true },
            RateLimitInfo = new RateLimitInfo() { RateLimitRemaining = 30 }
        });

        A.CallTo(() => habiticaApiClient.GetContentAsync()).Returns(new RateLimitedApiResponse<ContentResponse>
        {
            Body = new ContentResponse() { success = true },
            RateLimitInfo = new RateLimitInfo() { RateLimitRemaining = 29 }
        });

        var result = await habiticaApiService.GetHabiticaUserAsync(request);

        Assert.True(result.Body.User.success);
        Assert.True(result.Body.Content.success);
        Assert.Equal(29, result.RateLimitInfo.RateLimitRemaining);
    }

    [Fact]
    public async Task FeedPetFoodAsync_ThrowsNotImplementedException()
    {
        await Assert.ThrowsAsync<NotImplementedException>(() => habiticaApiService.FeedPetFoodAsync(null));
    }
}
