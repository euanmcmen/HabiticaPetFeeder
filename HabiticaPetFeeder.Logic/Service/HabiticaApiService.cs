using HabiticaPetFeeder.Logic.Client.Interface;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service;

public class HabiticaApiService : IHabiticaApiService
{
    private readonly ILogger<HabiticaApiService> logger;
    private readonly IHabiticaApiClient habiticaApiClient;
    private readonly HabiticaApiSettings habiticaApiSettings;

    public HabiticaApiService(ILoggerFactory loggerFactory, IHabiticaApiClient habiticaApiClient, IOptions<HabiticaApiSettings> habiticaApiSettingsOptions)
    {
        logger = loggerFactory.CreateLogger<HabiticaApiService>();
        this.habiticaApiClient = habiticaApiClient;
        habiticaApiSettings = habiticaApiSettingsOptions.Value;
    }

    public async Task<RateLimitedApiResponse<UserContentPair>> GetHabiticaUserAsync(AuthenticatedApiRequest apiRequest)
    {
        await habiticaApiClient.AuthenticateAsync(apiRequest.UserApiAuthInfo);

        var userResponse = await habiticaApiClient.GetUserAsync();
        var contentResponse = await habiticaApiClient.GetContentAsync();
        
        var userPetFoodInfo = new UserContentPair() { User = userResponse.Body, Content = contentResponse.Body };

        var minRateLimitInfo = userResponse.RateLimitInfo.RateLimitRemaining < contentResponse.RateLimitInfo.RateLimitRemaining 
            ? userResponse.RateLimitInfo 
            : contentResponse.RateLimitInfo;

        var rateLimitedResponse = new RateLimitedApiResponse<UserContentPair> {  RateLimitInfo = minRateLimitInfo, Body = userPetFoodInfo };

        return rateLimitedResponse;
    }

    public async Task<RateLimitedApiResponse> FeedPetFoodAsync(AuthenticatedRateLimitedApiRequest<PetFoodFeed> apiPetFoodFeedRequest)
    {
        throw new NotImplementedException("Not ready for live.");
    }
}
