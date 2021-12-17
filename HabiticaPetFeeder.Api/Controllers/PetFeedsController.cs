using HabiticaPetFeeder.Api.Model;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.HabiticaApi;
using HabiticaPetFeeder.Logic.Service.PetFoodFeedSummary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetFeedsController : ControllerBase
{
    private readonly ILogger<PetFeedsController> logger;
    private readonly IHabiticaApiService habiticaApiService;
    private readonly IDataService dataService;
    private readonly IPetFoodPreferenceService petFoodPreferenceService;
    private readonly IPetFoodFeedService petFoodFeedService;
    private readonly IPetFoodFeedSummaryService petFoodFeedSummaryService;

    public PetFeedsController(ILoggerFactory loggerFactory,
                              IHabiticaApiService habiticaApiService,
                              IDataService dataService,
                              IPetFoodPreferenceService petFoodPreferenceService,
                              IPetFoodFeedService petFoodFeedService,
                              IPetFoodFeedSummaryService petFoodFeedSummaryService)
    {
        logger = loggerFactory.CreateLogger<PetFeedsController>();

        this.habiticaApiService = habiticaApiService;
        this.dataService = dataService;
        this.petFoodPreferenceService = petFoodPreferenceService;
        this.petFoodFeedService = petFoodFeedService;
        this.petFoodFeedSummaryService = petFoodFeedSummaryService;
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> GetPetFeedsForUserAsync(UserApiAuthInfo userApiAuthInfo)
    {
        if (userApiAuthInfo is null) 
            throw new ArgumentNullException(nameof(userApiAuthInfo));

        if (string.IsNullOrEmpty(userApiAuthInfo.ApiUserId) || string.IsNullOrEmpty(userApiAuthInfo.ApiKey)) 
            throw new ArgumentException("ApiUserId and ApiKey cannot be null.");

        List<PetFoodFeed> feeds = await BuildPetFeedsForUserAsync(userApiAuthInfo);

        var summary = new PetFoodFeedSummary()
        {
            TotalNumberOfPetsFed = petFoodFeedSummaryService.GetNumberOfPetsFed(feeds),
            TotalNumberOfFoodsFed = petFoodFeedSummaryService.GetNumberOfFoodsFed(feeds),
            TotalNumberOfSatisfiedPets = petFoodFeedSummaryService.GetNumberOfSatisfiedPets(feeds)
        };

        var petFeedsResult = new PetFoodFeedResult()
        {
            PetFoodFeeds = feeds,
            PetFoodFeedSummary = summary
        };

        return Ok(petFeedsResult);
    }

    private async Task<List<PetFoodFeed>> BuildPetFeedsForUserAsync(UserApiAuthInfo userApiAuthInfo)
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