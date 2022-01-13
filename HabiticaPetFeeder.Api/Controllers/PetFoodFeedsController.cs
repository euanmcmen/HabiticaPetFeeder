using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Api.Controllers;

/*
 * The authentication header has no scheme.  The header value is the encrypted token.
 */

[Route("api/[controller]")]
[ApiController]
public class PetFoodFeedsController : ControllerBase
{
    private readonly ILogger<PetFoodFeedsController> logger;
    private readonly IHabiticaApiService habiticaApiService;
    private readonly IAuthenticationService authenticationService;
    private readonly IDataService dataService;
    private readonly IPetFoodPreferenceService petFoodPreferenceService;
    private readonly IPetFoodFeedService petFoodFeedService;

    public PetFoodFeedsController(ILoggerFactory loggerFactory,
                              IHabiticaApiService habiticaApiService,
                              IAuthenticationService authenticationService,
                              IDataService dataService,
                              IPetFoodPreferenceService petFoodPreferenceService,
                              IPetFoodFeedService petFoodFeedService)
    {
        logger = loggerFactory.CreateLogger<PetFoodFeedsController>();

        this.habiticaApiService = habiticaApiService;
        this.authenticationService = authenticationService;
        this.dataService = dataService;
        this.petFoodPreferenceService = petFoodPreferenceService;
        this.petFoodFeedService = petFoodFeedService;
    }

    [HttpGet]
    [Route("fetch")]
    public async Task<IActionResult> GetPetFeedsForUserAsync()
    {
        var userApiAuthInfo = GetUserAuthFromRequestHeader(Request);

        if (userApiAuthInfo is null)
            return Unauthorized();

        List<PetFoodFeed> feeds = await BuildPetFoodFeedsForUserAsync(userApiAuthInfo);

        logger.LogInformation($"User Id: {userApiAuthInfo.ApiUserId} | Number of pet food feeds calculated: {feeds.Count}");

        return Ok(feeds);
    }

    [HttpPost]
    [Route("feed")]
    public async Task<IActionResult> FeedUserPetAsync(PetFoodFeed petFoodFeed)
    {
        var userApiAuthInfo = GetUserAuthFromRequestHeader(Request);

        if (userApiAuthInfo is null)
            return Unauthorized();

        var feedResponse = await habiticaApiService.FeedPetFoodAsync(userApiAuthInfo, petFoodFeed);

        logger.LogInformation($"User Id: {userApiAuthInfo.ApiUserId} | Pet {petFoodFeed.PetFullName} was fed {petFoodFeed.FoodFullName} x{petFoodFeed.FeedQuantity} | PetFeed Result: {(feedResponse.success ? "Successful" : "Unsuccessful")}.  Data: {feedResponse.data}");

        return Ok(feedResponse);
    }

    private UserApiAuthInfo GetUserAuthFromRequestHeader(HttpRequest httpRequest)
    {
        if (httpRequest.Headers.Authorization.Count != 1)
            return null;

        return authenticationService.GetUserAuthFromAuthenticationToken(httpRequest.Headers.Authorization[0]);
    }

    private async Task<List<PetFoodFeed>> BuildPetFoodFeedsForUserAsync(UserApiAuthInfo userApiAuthInfo)
    {
        var (userResult, contentResult) = await habiticaApiService.GetHabiticaUserAsync(userApiAuthInfo);

        var allPets = dataService.GetPets(userResult, contentResult);

        var allFoods = dataService.GetFoods(userResult, contentResult);

        var basicPetFoodPreferences = petFoodPreferenceService.GetUserBasicPetPreferredFoods(allPets, allFoods);

        List<PetFoodFeed> feeds = new();
        feeds.AddRange(petFoodFeedService.GetPreferredFoodFeeds(allPets, allFoods, basicPetFoodPreferences));
        feeds.AddRange(petFoodFeedService.GetFoodFeeds(allPets, allFoods));
        return feeds;
    }
}