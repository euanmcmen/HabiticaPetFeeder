using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using HabiticaPetFeeder.Logic.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service;

public class DummyHabiticaApiService : IHabiticaApiService
{
    private readonly ILogger<DummyHabiticaApiService> logger;
    private readonly IRateLimitingService rateLimitingService;
    private readonly IMongoDbService mongoDbService;

    public DummyHabiticaApiService(ILoggerFactory loggerFactory, IRateLimitingService rateLimitingService, IMongoDbService mongoDbService)
    {
        logger = loggerFactory.CreateLogger<DummyHabiticaApiService>();
        this.rateLimitingService = rateLimitingService;
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
        await rateLimitingService.WaitForRateLimitDelay(apiPetFoodFeedRequest.RateLimitInfo);

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