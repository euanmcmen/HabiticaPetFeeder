using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Util;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HabiticaPetFeeder.Tests.Integration;

public class PetFoodFeedsControllerTests : IClassFixture<WebApplicationFactory<Api.Startup>>
{
    private readonly HttpClient _client;
    private const string authHeader = @"INSERT FROM SECRETS";


    /*
     * I've changed the auth header so the previous value won't work.
     * Going forwards, I'd like to move the new auth value into a secrets file to protect myself.
     */

    public PetFoodFeedsControllerTests(WebApplicationFactory<Api.Startup> fixture)
    {
        _client = fixture.CreateClient();
    }

    public async Task GetPetFeedsForUserAsync_RejectsRequestWithoutAuthHeader()
    {
        var response = await _client.GetAsync("/api/petfoodfeeds/fetch");
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    public async Task GetPetFeedsForUserAsync_ReturnsPetFoodFeeds()
    {
        _client.DefaultRequestHeaders.Add("X-Auth-Token", authHeader);

        var response = await _client.GetAsync("/api/petfoodfeeds/fetch");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var responseContent = JsonConvert.DeserializeObject<RateLimitedApiResponse<List<PetFoodFeed>>>(await response.Content.ReadAsStringAsync());

        Assert.True(responseContent.Body.Count > 0);

        Assert.True(responseContent.RateLimitInfo.RateLimitRemaining > 0);
    }

    public async Task FeedUserPetAsync_FeedsPet()
    {
        const int requestRateLimit = 15;

        _client.DefaultRequestHeaders.Add("X-Auth-Token", authHeader);
        _client.DefaultRequestHeaders.Add("X-Rate-Remaining", requestRateLimit.ToString());
        _client.DefaultRequestHeaders.Add("X-Rate-Reset", DateTimeHelper.DateToString(DateTime.UtcNow.AddSeconds(30)));

        var response = await _client.PostAsync("/api/petfoodfeeds/feed", 
            new StringContent(JsonConvert.SerializeObject(new PetFoodFeed("Base_TestPet", "TestFood", 1, false)), Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var responseContent = JsonConvert.DeserializeObject<RateLimitedApiResponse>(await response.Content.ReadAsStringAsync());

        Assert.True(responseContent.RateLimitInfo.RateLimitRemaining == requestRateLimit - 1);
    }

    //Test the auth controller with a different test.

    //https://timdeschryver.dev/blog/how-to-test-your-csharp-web-api#a-simple-test

}
