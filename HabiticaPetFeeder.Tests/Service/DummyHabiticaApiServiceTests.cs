using FakeItEasy;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using HabiticaPetFeeder.Logic.Util;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service;

public class DummyHabiticaApiServiceTests
{
    private readonly DummyHabiticaApiService dummyHabiticaApiService;
    private readonly IMongoDbService mongoDbService;
    private readonly IRateLimitingService rateLimitingService;

    public DummyHabiticaApiServiceTests()
    {
        mongoDbService = A.Fake<IMongoDbService>();
        rateLimitingService = A.Fake<IRateLimitingService>();

        dummyHabiticaApiService =
            new DummyHabiticaApiService(TestHelpers.GetFakeLoggerFactoryForType<HabiticaApiService>(), rateLimitingService, mongoDbService);
    }

    [Fact]
    public async Task GetHabiticaUserAsync_ReturnsUserAndContentData()
    {
        var request = new AuthenticatedApiRequest()
        {
            UserApiAuthInfo = new UserApiAuthInfo("test-key", "test-id")
        };

        A.CallTo(() => mongoDbService.GetDummyRecordByFriendlyNameAsync<UserResponse>("UserResponse")).Returns(new UserResponse() { success = true });

        A.CallTo(() => mongoDbService.GetDummyRecordByFriendlyNameAsync<ContentResponse>("ContentResponse")).Returns(new ContentResponse() { success = true });

        var result = await dummyHabiticaApiService.GetHabiticaUserAsync(request);

        Assert.True(result.Body.User.success);
        Assert.True(result.Body.Content.success);
        Assert.Equal(28, result.RateLimitInfo.RateLimitRemaining);
    }

    public class FeedPetFoodAsyncTests : DummyHabiticaApiServiceTests
    {
        private readonly PetFoodFeed petFoodFeed;
        private readonly UserApiAuthInfo userApiAuthInfo;

        public FeedPetFoodAsyncTests()
        {
            petFoodFeed = new PetFoodFeed("test-pet-name", "test-food-name", 1, false);
            userApiAuthInfo = new UserApiAuthInfo("test-key", "test-id");
        }

        [Fact]
        public async Task FeedPetFoodAsync_ShouldCallRateLimiting()
        {
            var input = new RateLimitInfo()
            {
                RateLimitRemaining = 25,
                RateLimitReset = DateTimeHelper.DateToString(DateTime.UtcNow.AddSeconds(30))
            };

            var response = await GetTestResultAsync(input);

            A.CallTo(() => rateLimitingService.WaitForRateLimitDelayAsync(input)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task FeedPetFoodAsync_WithPastResetDate_ReturnsFeedResult_AndResetsRateLimitRemaining()
        {
            var input = new RateLimitInfo()
            {
                RateLimitRemaining = 21,
                RateLimitReset = DateTimeHelper.DateToString(DateTime.UtcNow.AddSeconds(-30))
            };

            var response = await GetTestResultAsync(input);

            Assert.Equal(29, response.RateLimitInfo.RateLimitRemaining);
        }

        [Fact]
        public async Task FeedPetFoodAsync_WithFutureResetDate_ReturnsFeedResult()
        {
            var input = new RateLimitInfo()
            {
                RateLimitRemaining = 25,
                RateLimitReset = DateTimeHelper.DateToString(DateTime.UtcNow.AddSeconds(30))
            };

            var response = await GetTestResultAsync(input);

            Assert.Equal(24, response.RateLimitInfo.RateLimitRemaining);
        }

        private async Task<RateLimitedApiResponse> GetTestResultAsync(RateLimitInfo rateLimitInfo)
        {
            var request = new AuthenticatedRateLimitedApiRequest<PetFoodFeed>
            {
                RateLimitInfo = rateLimitInfo,
                Body = petFoodFeed,
                UserApiAuthInfo = userApiAuthInfo
            };

            return await dummyHabiticaApiService.FeedPetFoodAsync(request);
        }
    }
}
