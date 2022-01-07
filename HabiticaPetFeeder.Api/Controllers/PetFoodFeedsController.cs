using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Data;
using HabiticaPetFeeder.Logic.Service.HabiticaApi;
using HabiticaPetFeeder.Logic.Service.PetFoodFeed;
using HabiticaPetFeeder.Logic.Service.PetFoodPreferences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetFoodFeedsController : ControllerBase
{
    private readonly ILogger<PetFoodFeedsController> logger;
    private readonly IHabiticaApiService habiticaApiService;
    private readonly IDataService dataService;
    private readonly IPetFoodPreferenceService petFoodPreferenceService;
    private readonly IPetFoodFeedService petFoodFeedService;

    public PetFoodFeedsController(ILoggerFactory loggerFactory,
                              IHabiticaApiService habiticaApiService,
                              IDataService dataService,
                              IPetFoodPreferenceService petFoodPreferenceService,
                              IPetFoodFeedService petFoodFeedService)
    {
        logger = loggerFactory.CreateLogger<PetFoodFeedsController>();

        this.habiticaApiService = habiticaApiService;
        this.dataService = dataService;
        this.petFoodPreferenceService = petFoodPreferenceService;
        this.petFoodFeedService = petFoodFeedService;
    }

    [HttpPost]
    [Route("fetch")]
    public async Task<IActionResult> GetPetFeedsForUserAsync(UserApiAuthInfo userApiAuthInfo)
    {
        if (userApiAuthInfo is null) 
            throw new ArgumentNullException(nameof(userApiAuthInfo));

        List<PetFoodFeed> feeds = await BuildPetFoodFeedsForUserAsync(userApiAuthInfo);

        logger.LogInformation($"User Id: {userApiAuthInfo.ApiUserId} | Number of pet food feeds calculated: {feeds.Count}");

        return Ok(feeds);
    }

    [HttpPost]
    [Route("feed")]
    public async Task<IActionResult> FeedUserPetAsync(Model.FeedUserPetRequest feedUserPetRequest)
    {
        if (feedUserPetRequest is null)
            throw new ArgumentNullException(nameof(feedUserPetRequest));

        var userApiAuthInfo = feedUserPetRequest.UserApiAuthInfo;
        var petFoodFeed = feedUserPetRequest.PetFoodFeed;

        var feedResponse = await habiticaApiService.FeedPetFoodAsync(userApiAuthInfo, petFoodFeed);

        logger.LogInformation($"User Id: {userApiAuthInfo.ApiUserId} | Pet {petFoodFeed.PetFullName} was fed {petFoodFeed.FoodFullName} x{petFoodFeed.FeedQuantity} | PetFeed Result: {(feedResponse.success ? "Successful" : "Unsuccessful")}.  Data: {feedResponse.data}");

        return Ok(feedResponse);
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