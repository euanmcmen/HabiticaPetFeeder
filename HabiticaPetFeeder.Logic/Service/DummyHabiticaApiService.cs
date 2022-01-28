using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using HabiticaPetFeeder.Logic.Util;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service;

public class DummyHabiticaApiService : IHabiticaApiService
{
    private readonly ILogger<DummyHabiticaApiService> logger;
    private readonly HabiticaApiSettings habiticaApiSettings;
    private readonly IMongoDbService mongoDbService;

    public DummyHabiticaApiService(ILoggerFactory loggerFactory, IMongoDbService mongoDbService, IOptions<HabiticaApiSettings> habiticaApiSettingsOptions)
    {
        logger = loggerFactory.CreateLogger<DummyHabiticaApiService>();
        habiticaApiSettings = habiticaApiSettingsOptions.Value;
        this.mongoDbService = mongoDbService;
    }

    public async Task<RateLimitedApiResponse<UserContentPair>> GetHabiticaUserAsync(AuthenticatedApiRequest apiRequest)
    {
        var userResponse = await mongoDbService.GetDummyRecordByFriendlyNameAsync<UserResponse>("UserResponse");

        var contentResponse = await mongoDbService.GetDummyRecordByFriendlyNameAsync<ContentResponse>("ContentResponse");

        var userPetFoodInfo = new UserContentPair() { User = userResponse, Content = contentResponse };

        var responseRateInfo = new RateLimitInfo { RateLimitReset = DateTimeHelper.DateToString(DateTime.UtcNow), RateLimitRemaining = 28 };

        var rateLimitedResponse = new RateLimitedApiResponse<UserContentPair> { RateLimitInfo = responseRateInfo, Body = userPetFoodInfo };

        return rateLimitedResponse;
    }

    public async Task<RateLimitedApiResponse> FeedPetFoodAsync(AuthenticatedRateLimitedApiRequest<PetFoodFeed> apiPetFoodFeedRequest)
    {
        if (apiPetFoodFeedRequest.RateLimitInfo.RateLimitRemaining < habiticaApiSettings.RateLimitThrottleThreshold)
        {
            await Task.Delay(habiticaApiSettings.RateLimitThrottleDurationSeconds * 1000);
        }

        var resetDate = DateTimeHelper.StringToDate(apiPetFoodFeedRequest.RateLimitInfo.RateLimitReset);
        var responseRateLimitInfo = resetDate < DateTime.UtcNow
            ? new RateLimitInfo()
            {
                RateLimitRemaining = 29,
                RateLimitReset = DateTimeHelper.DateToString(DateTime.UtcNow.AddMinutes(1))
            }
            : new RateLimitInfo()
            {
                RateLimitRemaining = apiPetFoodFeedRequest.RateLimitInfo.RateLimitRemaining - 1,
                RateLimitReset = apiPetFoodFeedRequest.RateLimitInfo.RateLimitReset
            };

        var rateLimitedResponse = new RateLimitedApiResponse() { RateLimitInfo = responseRateLimitInfo };

        return rateLimitedResponse;
    }
}