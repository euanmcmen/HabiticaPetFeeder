using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service.ApiService.Feed.Abstraction;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.ApiService.Feed;

public class FeedApiService : IFeedApiService
{
    private readonly ILogger<FeedApiService> logger;
    private readonly HabiticaApiClient habiticaApiClient;
    private readonly IRateLimitingService rateLimitingService;

    public FeedApiService(ILoggerFactory loggerFactory, HabiticaApiClient habiticaApiClient, IRateLimitingService rateLimitingService)
    {
        this.logger = loggerFactory.CreateLogger<FeedApiService>();
        this.habiticaApiClient = habiticaApiClient;
        this.rateLimitingService = rateLimitingService;
    }

    public async Task<RateLimitedApiResponse> FeedPetFoodAsync(AuthenticatedRateLimitedApiRequest<PetFoodFeed> apiPetFoodFeedRequest)
    {
        await rateLimitingService.WaitForRateLimitDelayAsync(apiPetFoodFeedRequest.RateLimitInfo); 

        var apiResponse = await habiticaApiClient.FeedPetFoodAsync(apiPetFoodFeedRequest.Body);

        return apiResponse;
    }
}
