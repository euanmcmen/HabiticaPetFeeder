using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Service;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public class PetFeederOperation
    {
        private readonly ILogger<PetFeederOperation> logger;
        private readonly IDataService dataService;
        private readonly IPetFoodPreferenceService petFoodPreferenceService;
        private readonly IPetFoodFeedService petFoodFeedService;
        private readonly IHabiticaApiClient habiticaApiClient;

        public PetFeederOperation(ILoggerFactory loggerFactory,
            IDataService dataService,
            IPetFoodPreferenceService petFoodPreferenceService,
            IPetFoodFeedService petFoodFeedService,
            IHabiticaApiClient habiticaApiClient)
        {
            logger = loggerFactory.CreateLogger<PetFeederOperation>();
            this.dataService = dataService;
            this.petFoodPreferenceService = petFoodPreferenceService;
            this.petFoodFeedService = petFoodFeedService;
            this.habiticaApiClient = habiticaApiClient;
        }

        public async Task RunOperationAsync()
        {
            logger.LogInformation("Starting...");

            var userResult = await habiticaApiClient.GetUserAsync();

            var contentResult = await habiticaApiClient.GetContentAsync();

            var allPets = dataService.GetPets(userResult, contentResult);

            var allFoods = dataService.GetFoods(userResult, contentResult);

            var basicPetFoodPreferences = petFoodPreferenceService.GetUserBasicPetPreferredFoods(allPets, allFoods);

            var basicPetFeeds = petFoodFeedService.GetPreferredFoodFeeds(allPets, allFoods, basicPetFoodPreferences);

            foreach (var feed in basicPetFeeds)
            {
                logger.LogInformation($"[BASIC] Pet {feed.PetFullName} fed {feed.FoodFullName} x{feed.FeedQuantity}.");
            }

            if (allPets.Where(x => x.IsBasicPet).All(x => x.FedPoints.Value >= 50))
            {
                logger.LogInformation("All basic pets have been fed.");
            }
            else
            {
                logger.LogInformation("Some basic pets were not fed.");
            }

            var remainingFeeds = petFoodFeedService.GetFoodFeeds(allPets, allFoods);

            foreach (var feed in remainingFeeds)
            {
                logger.LogInformation($"[GENERAL] Pet {feed.PetFullName} fed {feed.FoodFullName} x{feed.FeedQuantity}.");
            }

            if (allPets.All(x => x.FedPoints.Value >= 50))
            {
                logger.LogInformation("All pets have been fed.");
            }
            else
            {
                logger.LogInformation("Some pets were not fed.");
            }

            logger.LogInformation("Finished.");
        }
    }
}
