using HabiticaPetFeeder.Logic.Client.Abstraction;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Model.FeedResponse;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Client;

public class HabiticaApiClient : IHabiticaApiClient
{
    private readonly HabiticaApiClientHeaderSettings habiticaApiClientHeaderSettings;
    private readonly HttpClient httpClient;

    private const string userEndpoint = @"https://habitica.com/api/v3/user?userFields=items.pets,items.mounts,items.food";
    private const string contentEndpoint = @"https://habitica.com/api/v3/content";
    private const string feedPetEndpoint = @"https://habitica.com/api/v3/user/feed/{0}/{1}?amount={2}";

    public HabiticaApiClient(HttpClient httpClient, IOptions<HabiticaApiClientHeaderSettings> clientHeaderSettingsOptions)
    {
        this.habiticaApiClientHeaderSettings = clientHeaderSettingsOptions.Value;
        this.httpClient = httpClient;
    }

    public Task AuthenticateAsync(UserApiAuthInfo userApiAuthInfo)
    {
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("x-client", $"{habiticaApiClientHeaderSettings.MyUserId}-{habiticaApiClientHeaderSettings.MyAppName}");
        httpClient.DefaultRequestHeaders.Add("x-api-user", userApiAuthInfo.ApiUserId);
        httpClient.DefaultRequestHeaders.Add("x-api-key", userApiAuthInfo.ApiUserKey);

        return Task.CompletedTask;
    }

    public async Task<RateLimitedApiResponse<ContentResponse>> GetContentAsync()
    {
        return await GetData<ContentResponse>(contentEndpoint);
    }

    public async Task<RateLimitedApiResponse<UserResponse>> GetUserAsync()
    {
        return await GetData<UserResponse>(userEndpoint);
    }

    public async Task<RateLimitedApiResponse<FeedResponse>> FeedPetFoodAsync(PetFoodFeed petFoodFeed)
    {
        var petFoodFeedObjectArray = new object[] { petFoodFeed.PetFullName, petFoodFeed.FoodFullName, petFoodFeed.FeedQuantity };

        return await PostData<FeedResponse>(feedPetEndpoint, petFoodFeedObjectArray);
    }

    private async Task<RateLimitedApiResponse<T>> GetData<T>(string url)
    {
        var response = await httpClient.GetAsync(url);

        return await ParseResponse<T>(response);
    }

    private async Task<RateLimitedApiResponse<T>> PostData<T>(string patternUrl, object[] urlParameters)
    {
        var url = string.Format(patternUrl, urlParameters);        

        var response = await httpClient.PostAsync(url, null);

        return await ParseResponse<T>(response);
    }

    private async static Task<RateLimitedApiResponse<T>> ParseResponse<T>(HttpResponseMessage response)
    {
        var rateLimitedResponse = new RateLimitedApiResponse<T> { RateLimitInfo = new RateLimitInfo(), HttpStatus = response.StatusCode };

        if (response.IsSuccessStatusCode)
        {
            rateLimitedResponse.Body = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        if (response.Headers.TryGetValues("X-RateLimit-Remaining", out IEnumerable<string> rateLimitRemainingHeader))
        {
            rateLimitedResponse.RateLimitInfo.RateLimitRemaining = int.Parse(rateLimitRemainingHeader.Single());
        }

        if (response.Headers.TryGetValues("X-RateLimit-Reset", out IEnumerable<string> rateLimitResetHeader))
        {
            //"Wed Jan 19 2022 08:01:54 GMT+0000 (Coordinated Universal Time)";
            rateLimitedResponse.RateLimitInfo.RateLimitReset = rateLimitResetHeader.Single();
        }

        return rateLimitedResponse;
    }
}
