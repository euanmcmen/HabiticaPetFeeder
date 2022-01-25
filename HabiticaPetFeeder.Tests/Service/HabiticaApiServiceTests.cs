using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Model.FeedResponse;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Util;
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
    
    public class FeedPetFoodAsyncTests : HabiticaApiServiceTests, IClassFixture<HabiticaApiServiceTests_Fixture>
    {
        private readonly PetFoodFeed petFoodFeed;
        private readonly UserApiAuthInfo userApiAuthInfo;

        public FeedPetFoodAsyncTests(HabiticaApiServiceTests_Fixture fixture) : base(fixture)
        {
            petFoodFeed = new PetFoodFeed("test-pet-name", "test-food-name", 1, false);
            userApiAuthInfo = new UserApiAuthInfo("test-key", "test-id");
        }

        [Fact]
        public async Task FeedPetFoodAsync_WithPastResetDate_ReturnsFeedResult_AndResetsRateLimitRemaining()
        {
            //fixture.MockApiClient.Setup(x => x.FeedPetFoodAsync(It.IsAny<PetFoodFeed>()))
            //    .ReturnsAsync(new RateLimitedApiResponse<FeedResponse>()
            //    {
            //        Response = new FeedResponse() { success = true },
            //        RateLimitInfo = new RateLimitInfo() { RateLimitRemaining = 24 }
            //    });

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
            //fixture.MockApiClient.Setup(x => x.FeedPetFoodAsync(It.IsAny<PetFoodFeed>()))
            //    .ReturnsAsync(new RateLimitedApiResponse<FeedResponse>()
            //    {
            //        Response = new FeedResponse() { success = true },
            //        RateLimitInfo = new RateLimitInfo() { RateLimitRemaining = 24 }
            //    });

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

            fixture.MockApiClient.Verify(x => x.FeedPetFoodAsync(It.IsAny<PetFoodFeed>()), Times.Never());

            return await fixture.HabiticaApiService.FeedPetFoodAsync(request);
        }
    }

    
}
