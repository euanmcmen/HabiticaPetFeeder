using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service.ApiService.Feed.Abstraction;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using HabiticaPetFeeder.Logic.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.ApiService.Feed;

public class DummyFeedApiService : IFeedApiService
{
    private readonly ILogger<DummyFeedApiService> logger;
    private readonly IRateLimitingService rateLimitingService;

    public DummyFeedApiService(ILoggerFactory loggerFactory, IRateLimitingService rateLimitingService)
    {
        logger = loggerFactory.CreateLogger<DummyFeedApiService>();
        this.rateLimitingService = rateLimitingService;
    }

    public async Task<RateLimitedApiResponse> FeedPetFoodAsync(AuthenticatedRateLimitedApiRequest<PetFoodFeed> apiPetFoodFeedRequest)
    {
        await rateLimitingService.WaitForRateLimitDelayAsync(apiPetFoodFeedRequest.RateLimitInfo);

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

        var rateLimitedResponse = new RateLimitedApiResponse() { RateLimitInfo = responseRateLimitInfo, HttpStatus = System.Net.HttpStatusCode.OK };

        return rateLimitedResponse;
    }
}
