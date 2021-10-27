using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IHabiticaApiClient habiticaApiClient;

        public PetFeedsController(ILoggerFactory loggerFactory,IDataService dataService,IPetFoodPreferenceService petFoodPreferenceService,IPetFoodFeedService petFoodFeedService,
            IHabiticaApiClient habiticaApiClient)
        {
            this.dataService = dataService;
            this.petFoodPreferenceService = petFoodPreferenceService;
            this.petFoodFeedService = petFoodFeedService;
            this.habiticaApiClient = habiticaApiClient;

            logger = loggerFactory.CreateLogger<PetFeedsController>();
        }

        [HttpPost]
        public async Task<IActionResult> GetPetFeeds()
        {
            await Task.CompletedTask;

            var userResult = await habiticaApiClient.GetUserAsync();
            var contentResult = await habiticaApiClient.GetContentAsync();

            var allPets = dataService.GetPets(userResult, contentResult);
            var allFoods = dataService.GetFoods(userResult, contentResult);

            var basicPetFoodPreferences = petFoodPreferenceService.GetUserBasicPetPreferredFoods(allPets, allFoods);

            var basicPetFeeds = petFoodFeedService.GetPreferredFoodFeeds(allPets, allFoods, basicPetFoodPreferences);

            var remainingFeeds = petFoodFeedService.GetFoodFeeds(allPets, allFoods);

            var combinedFeeds = new List<IEnumerable<PetFoodFeed>>
            {
                basicPetFeeds,
                remainingFeeds
            };

            return Ok(combinedFeeds);
        }
    }
}
