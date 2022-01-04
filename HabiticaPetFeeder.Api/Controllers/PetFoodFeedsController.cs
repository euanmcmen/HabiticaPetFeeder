using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.HabiticaApi;
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
    [Route("")]
    public async Task<IActionResult> GetPetFeedsForUserAsync(UserApiAuthInfo userApiAuthInfo)
    {
        if (userApiAuthInfo is null) 
            throw new ArgumentNullException(nameof(userApiAuthInfo));

        if (string.IsNullOrEmpty(userApiAuthInfo.ApiUserId) || string.IsNullOrEmpty(userApiAuthInfo.ApiUserKey)) 
            throw new ArgumentException("ApiUserId and ApiUserKey cannot be null.");

        List<PetFoodFeed> feeds = await BuildPetFoodFeedsForUserAsync(userApiAuthInfo);

        logger.LogInformation($"User Id: {userApiAuthInfo.ApiUserId} | Number of pet food feeds calculated: {feeds.Count}");

        return Ok(feeds);
    }

    [HttpPost]
    [Route("feed")]
    public async Task<IActionResult> FeedUserPetAsync(UserApiAuthInfo userApiAuthInfo, PetFoodFeed petFoodFeed)
    {
        if (userApiAuthInfo is null)
            throw new ArgumentNullException(nameof(userApiAuthInfo));

        if (petFoodFeed is null)
            throw new ArgumentNullException(nameof(petFoodFeed));

        if (string.IsNullOrEmpty(userApiAuthInfo.ApiUserId) || string.IsNullOrEmpty(userApiAuthInfo.ApiUserKey))
            throw new ArgumentException("ApiUserId and ApiUserKey cannot be null.");

        var feedResponse = await habiticaApiService.FeedPetFoodAsync(userApiAuthInfo, petFoodFeed);

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