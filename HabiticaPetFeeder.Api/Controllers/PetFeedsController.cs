using HabiticaPetFeeder.Api.Model;
using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.PetFoodFeedSummary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetFeedsController : ControllerBase
    {
        private readonly ILogger<PetFeedsController> logger;

        private readonly IDataService dataService;
        private readonly IPetFoodPreferenceService petFoodPreferenceService;
        private readonly IPetFoodFeedService petFoodFeedService;
        private readonly IPetFoodFeedSummaryService petFoodFeedSummaryService;
        private readonly IHabiticaApiClient habiticaApiClient;

        public PetFeedsController(ILoggerFactory loggerFactory,
                                  IDataService dataService,
                                  IPetFoodPreferenceService petFoodPreferenceService,
                                  IPetFoodFeedService petFoodFeedService,
                                  IPetFoodFeedSummaryService petFoodFeedSummaryService,
                                  IHabiticaApiClient habiticaApiClient)
        {
            this.dataService = dataService;
            this.petFoodPreferenceService = petFoodPreferenceService;
            this.petFoodFeedService = petFoodFeedService;
            this.petFoodFeedSummaryService = petFoodFeedSummaryService;
            this.habiticaApiClient = habiticaApiClient;

            logger = loggerFactory.CreateLogger<PetFeedsController>();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetPetFeedsAsync()
        {
            await Task.CompletedTask;

            var userResult = await habiticaApiClient.GetUserAsync();
            var contentResult = await habiticaApiClient.GetContentAsync();

            var allPets = dataService.GetPets(userResult, contentResult);
            var allFoods = dataService.GetFoods(userResult, contentResult);

            var basicPetFoodPreferences = petFoodPreferenceService.GetUserBasicPetPreferredFoods(allPets, allFoods);

            var feeds = new List<PetFoodFeed>();
            feeds.AddRange(petFoodFeedService.GetPreferredFoodFeeds(allPets, allFoods, basicPetFoodPreferences));
            feeds.AddRange(petFoodFeedService.GetFoodFeeds(allPets, allFoods));

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
    }
}