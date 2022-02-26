using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using HabiticaPetFeeder.Logic.Util;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service;

public class DummyHabiticaApiServiceTests_Fixture
{
    public DummyHabiticaApiService DummyHabiticaApiService { get; private set; }

    public Mock<IMongoDbService> MockMongoDbService { get; private set; }

    public Mock<IRateLimitingService> MockRateLimitingService { get; private set; }

    public DummyHabiticaApiServiceTests_Fixture()
    {
        MockMongoDbService = new Mock<IMongoDbService>();

        MockRateLimitingService = new Mock<IRateLimitingService>();

        DummyHabiticaApiService = 
            new DummyHabiticaApiService(TestHelpers.GetMockedLogFactoryForType<HabiticaApiService>().Object, 
                MockRateLimitingService.Object, 
                MockMongoDbService.Object);
    }
}

public class DummyHabiticaApiServiceTests : IClassFixture<DummyHabiticaApiServiceTests_Fixture>
{
    protected readonly DummyHabiticaApiServiceTests_Fixture fixture;

    public DummyHabiticaApiServiceTests(DummyHabiticaApiServiceTests_Fixture fixture)
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

        fixture.MockMongoDbService.Setup(x => x.GetDummyRecordByFriendlyNameAsync<UserResponse>("UserResponse"))
            .ReturnsAsync(new UserResponse() { success = true });

        fixture.MockMongoDbService.Setup(x => x.GetDummyRecordByFriendlyNameAsync<ContentResponse>("ContentResponse"))
            .ReturnsAsync(new ContentResponse() { success = true });

        var result = await fixture.DummyHabiticaApiService.GetHabiticaUserAsync(request);

        Assert.True(result.Body.User.success);
        Assert.True(result.Body.Content.success);
        Assert.Equal(28, result.RateLimitInfo.RateLimitRemaining);
    }

    public class FeedPetFoodAsyncTests : DummyHabiticaApiServiceTests, IClassFixture<DummyHabiticaApiServiceTests_Fixture>
    {
        private readonly PetFoodFeed petFoodFeed;
        private readonly UserApiAuthInfo userApiAuthInfo;

        public FeedPetFoodAsyncTests(DummyHabiticaApiServiceTests_Fixture fixture) : base(fixture)
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

            fixture.MockRateLimitingService.Verify(x => x.WaitForRateLimitDelayAsync(input), Times.Once());
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

            return await fixture.DummyHabiticaApiService.FeedPetFoodAsync(request);
        }
    }
}
