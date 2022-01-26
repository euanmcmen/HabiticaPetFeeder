using HabiticaPetFeeder.Logic.Client;
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

    public async Task<RateLimitedApiResponse<UserPetFoodInfo>> GetHabiticaUserAsync(AuthenticatedApiRequest apiRequest)
    {
        await habiticaApiClient.AuthenticateAsync(apiRequest.UserApiAuthInfo);

        //if (apiRequest.RateLimitInfo.RateLimitRemaining < 20)
        //{
        //    await Task.Delay(3000);
        //}

        var userResponse = await habiticaApiClient.GetUserAsync();
        var contentResponse = await habiticaApiClient.GetContentAsync();
        
        var userPetFoodInfo = new UserPetFoodInfo() { User = userResponse.Body, Content = contentResponse.Body };

        var minRateLimitInfo = userResponse.RateLimitInfo.RateLimitRemaining < contentResponse.RateLimitInfo.RateLimitRemaining 
            ? userResponse.RateLimitInfo 
            : contentResponse.RateLimitInfo;

        var rateLimitedResponse = new RateLimitedApiResponse<UserPetFoodInfo> {  RateLimitInfo = minRateLimitInfo, Body = userPetFoodInfo };

        return rateLimitedResponse;
    }

    public async Task<RateLimitedApiResponse> FeedPetFoodAsync(AuthenticatedRateLimitedApiRequest<PetFoodFeed> apiPetFoodFeedRequest)
    {
        throw new NotImplementedException("Not ready for live.");

        //await habiticaApiClient.AuthenticateAsync(apiPetFoodFeedRequest.UserApiAuthInfo);

        //if (apiPetFoodFeedRequest.RateLimitInfo.RateLimitRemaining < 20)
        //{
        //    await Task.Delay(3000);
        //}

        //var resetDate = DateTimeHelper.StringToDate(apiPetFoodFeedRequest.RateLimitInfo.RateLimitReset);
        //var responseRateLimitInfo = resetDate < DateTime.UtcNow
        //    ? new RateLimitInfo()
        //    {
        //        RateLimitRemaining = 29,
        //        RateLimitReset = DateTimeHelper.DateToString(DateTime.UtcNow.AddMinutes(1))
        //    }
        //    : new RateLimitInfo()
        //    {
        //        RateLimitRemaining = apiPetFoodFeedRequest.RateLimitInfo.RateLimitRemaining - 1,
        //        RateLimitReset = apiPetFoodFeedRequest.RateLimitInfo.RateLimitReset
        //    };

        //var rateLimitedResponse = new RateLimitedApiResponse() { RateLimitInfo = responseRateLimitInfo };

        //return rateLimitedResponse;
    }
}
