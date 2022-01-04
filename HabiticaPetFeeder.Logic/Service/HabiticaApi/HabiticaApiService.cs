using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ContentResponse;
using HabiticaPetFeeder.Logic.Model.FeedResponse;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.HabiticaApi;

public class HabiticaApiService : IHabiticaApiService
{
    private readonly ILogger<HabiticaApiService> logger;
    private readonly IHabiticaApiClient habiticaApiClient;

    public HabiticaApiService(ILoggerFactory loggerFactory, IHabiticaApiClient habiticaApiClient)
    {
        logger = loggerFactory.CreateLogger<HabiticaApiService>();
        this.habiticaApiClient = habiticaApiClient;
    }

    public async Task<(UserResponse userResponse, ContentResponse contentResponse)> GetHabiticaUserAsync(UserApiAuthInfo userApiAuthInfo)
    {
        await AuthenticateWithUserAuthInfo(userApiAuthInfo);

        var userResponse = await habiticaApiClient.GetUserAsync();

        var contentResponse = await habiticaApiClient.GetContentAsync();

        return (userResponse, contentResponse);
    }

    public async Task<FeedResponse> FeedPetFoodAsync(UserApiAuthInfo userApiAuthInfo, PetFoodFeed petFoodFeed)
    {
        if (petFoodFeed is null) 
            throw new ArgumentNullException(nameof(petFoodFeed));

        await AuthenticateWithUserAuthInfo(userApiAuthInfo);

        return await habiticaApiClient.FeedPetFoodAsync(petFoodFeed);
    }

    private async Task AuthenticateWithUserAuthInfo(UserApiAuthInfo userApiAuthInfo)
    {
        if (userApiAuthInfo is null || string.IsNullOrEmpty(userApiAuthInfo.ApiUserId) || string.IsNullOrEmpty(userApiAuthInfo.ApiUserKey))
            throw new ArgumentNullException(nameof(userApiAuthInfo));

        await habiticaApiClient.AuthenticateAsync(userApiAuthInfo);
    }
}
