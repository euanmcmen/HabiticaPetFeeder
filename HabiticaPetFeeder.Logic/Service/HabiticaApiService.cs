using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service;

public class HabiticaApiService : IHabiticaApiService
{
    private readonly ILogger<HabiticaApiService> logger;
    private readonly IHabiticaApiClient habiticaApiClient;

    public HabiticaApiService(ILoggerFactory loggerFactory, IHabiticaApiClient habiticaApiClient)
    {
        logger = loggerFactory.CreateLogger<HabiticaApiService>();
        this.habiticaApiClient = habiticaApiClient;
    }

    public async Task<RateLimitedApiResponse<UserPetFoodInfo>> GetHabiticaUserAsync(AuthenticatedRateLimitedApiRequest apiRequest)
    {
        await habiticaApiClient.AuthenticateAsync(apiRequest.UserApiAuthInfo);

        await AllowForRateLimitingAsync(apiRequest);

        var userResponse = await habiticaApiClient.GetUserAsync();
        var contentResponse = await habiticaApiClient.GetContentAsync();
        
        var userPetFoodInfo = new UserPetFoodInfo() { User = userResponse.Response, Content = contentResponse.Response };

        var newMinRateLimit = Math.Min(userResponse.RateLimitRemaining.Value, contentResponse.RateLimitRemaining.Value);

        var rateLimitedResponse = new RateLimitedApiResponse<UserPetFoodInfo> {  RateLimitRemaining = newMinRateLimit, Response = userPetFoodInfo };

        return rateLimitedResponse;
    }

    public async Task<RateLimitedApiResponse> FeedPetFoodAsync(AuthenticatedRateLimitedApiRequest<PetFoodFeed> apiPetFoodFeedRequest)
    {
        await habiticaApiClient.AuthenticateAsync(apiPetFoodFeedRequest.UserApiAuthInfo);

        await AllowForRateLimitingAsync(apiPetFoodFeedRequest);

        var feedResponse = await habiticaApiClient.FeedPetFoodAsync(apiPetFoodFeedRequest.Request);

        var newRateLimit = feedResponse.RateLimitRemaining;

        var rateLimitedResponse = new RateLimitedApiResponse() { RateLimitRemaining = newRateLimit };

        return rateLimitedResponse;
    }

    private async Task AllowForRateLimitingAsync(RateLimitedApiOperation apiOperation)
    {
        if (apiOperation.RateLimitRemaining > 20)
        {
            return;
        }

        await Task.Delay(3000);
    }
}
