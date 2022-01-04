using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ContentResponse;
using HabiticaPetFeeder.Logic.Model.FeedResponse;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Client;

public class HabiticaApiClient : IHabiticaApiClient
{
    private readonly HttpClient httpClient;

    private const string MyApiUserId = "5f10718c-957a-47dc-bdf8-3c90053ca248";
    private const string MyAppName = "HabiticaPetFeeder";

    private const string userEndpoint = @"https://habitica.com/api/v3/user?userFields=items.pets,items.mounts,items.food";
    private const string contentEndpoint = @"https://habitica.com/api/v3/content";

    //https: //habitica.com/api/v3/user/feed/Armadillo-Shade/Chocolate?amount=9

    public HabiticaApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public Task AuthenticateAsync(UserApiAuthInfo userApiAuthInfo)
    {
        if (userApiAuthInfo is null) throw new ArgumentNullException(nameof(userApiAuthInfo));

        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("x-client", $"{MyApiUserId}-{MyAppName}");
        httpClient.DefaultRequestHeaders.Add("x-api-user", userApiAuthInfo.ApiUserId);
        httpClient.DefaultRequestHeaders.Add("x-api-key", userApiAuthInfo.ApiUserKey);

        return Task.CompletedTask;
    }

    public async Task<ContentResponse> GetContentAsync()
    {
        return await GetData<ContentResponse>(contentEndpoint);
    }

    public async Task<UserResponse> GetUserAsync()
    {
        return await GetData<UserResponse>(userEndpoint);
    }

    public async Task<FeedResponse> FeedPetFoodAsync(PetFoodFeed petFoodFeed)
    {
        throw new NotImplementedException();
    }

    private async Task<T> GetData<T>(string url)
    {
        var response = await httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var responseText = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<T>(responseText);

        return result;
    }
}
