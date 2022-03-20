using HabiticaPetFeeder.Logic.Client.Abstraction;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service.ApiService.Fetch.Abstraction;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.ApiService.Fetch;

public class FetchApiService : IFetchApiService
{
    private readonly ILogger<FetchApiService> logger;
    private readonly IHabiticaApiClient habiticaApiClient;

    public FetchApiService(ILoggerFactory loggerFactory, IHabiticaApiClient habiticaApiClient)
    {
        logger = loggerFactory.CreateLogger<FetchApiService>();
        this.habiticaApiClient = habiticaApiClient;
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

        var rateLimitedResponse = new RateLimitedApiResponse<UserContentPair> { RateLimitInfo = minRateLimitInfo, Body = userPetFoodInfo };

        return rateLimitedResponse;
    }
}
