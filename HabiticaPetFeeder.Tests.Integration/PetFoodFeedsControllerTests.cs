using HabiticaPetFeeder.Logic.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HabiticaPetFeeder.Tests.Integration;

public class PetFoodFeedsControllerTests : IClassFixture<WebApplicationFactory<Api.Startup>>
{
    private readonly HttpClient _client;
    private const string authHeader = 
        @"bmlZWVJKNTBYcTJuSzljb2hhSDBsZz09SUcwWWpRRFExN2dLRUd0eC9sVWI3RzNtSGFQc2hXUStwSXhCMEdhQlZIZzlmMWpDbzQrdndQUDNDUzQyaStSYXBOaDNoQUo0WC9iSGZwM21JQUVTeDdnQm5BOG5GcTVZQTRWNmZzem8yalk9";
    public PetFoodFeedsControllerTests(WebApplicationFactory<Api.Startup> fixture)
    {
        _client = fixture.CreateClient();
    }

    [Fact]
    public async Task GetPetFeedsForUserAsync_RejectsRequestWithoutAuthHeader()
    {
        var response = await _client.GetAsync("/api/petfoodfeeds/fetch");
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetPetFeedsForUserAsync_ReturnsPetFoodFeeds()
    {
        _client.DefaultRequestHeaders.Add("Authorization", authHeader);

        var response = await _client.GetAsync("/api/petfoodfeeds/fetch");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var petFoodFeeds = JsonConvert.DeserializeObject<PetFoodFeed[]>(await response.Content.ReadAsStringAsync());

        Assert.True(petFoodFeeds.Length > 0);
    }

    //Test the auth controller with a different test.

    //https://timdeschryver.dev/blog/how-to-test-your-csharp-web-api#a-simple-test

}
