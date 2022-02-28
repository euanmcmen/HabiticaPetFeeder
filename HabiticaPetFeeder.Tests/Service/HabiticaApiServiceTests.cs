using FakeItEasy;
using HabiticaPetFeeder.Logic.Client.Interface;
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

public class HabiticaApiServiceTests_Fixture
{
    public HabiticaApiService HabiticaApiService { get; private set; }

    public IHabiticaApiClient HabiticaApiClient { get; private set; }

    public HabiticaApiServiceTests_Fixture()
    {
        HabiticaApiClient = A.Fake<IHabiticaApiClient>();

        var habiticaApiSettings = new HabiticaApiSettings() { RateLimitThrottleThreshold = 20, UseLiveEndpoint = false, RateLimitThrottleDurationSeconds = 3 };

        HabiticaApiService = new HabiticaApiService(TestHelpers.GetFakeLoggerFactoryForType<HabiticaApiService>(), HabiticaApiClient, Options.Create(habiticaApiSettings));
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

        A.CallTo(() => fixture.HabiticaApiClient.GetUserAsync()).Returns(new RateLimitedApiResponse<UserResponse>()
        {
            Body = new UserResponse() { success = true },
            RateLimitInfo = new RateLimitInfo() { RateLimitRemaining = 30 }
        });

        A.CallTo(() => fixture.HabiticaApiClient.GetContentAsync()).Returns(new RateLimitedApiResponse<ContentResponse>
        {
            Body = new ContentResponse() { success = true },
            RateLimitInfo = new RateLimitInfo() { RateLimitRemaining = 29 }
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
