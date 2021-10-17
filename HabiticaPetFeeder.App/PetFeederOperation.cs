using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public class PetFeederOperation
    {
        private readonly ILogger<PetFeederOperation> logger;
        private readonly IPetService petService;
        private readonly IFoodService foodService;
        private readonly IPetFoodPreferenceService petFoodPreferenceService;
        private readonly IPetFoodFeedService petFoodFeedService;
        private readonly IHabiticaApiClient habiticaApiClient;

        public PetFeederOperation(ILoggerFactory loggerFactory,
            IPetService petService,
            IFoodService foodService,
            IPetFoodPreferenceService petFoodPreferenceService,
            IPetFoodFeedService petFoodFeedService,
            IHabiticaApiClient habiticaApiClient)
        {
            logger = loggerFactory.CreateLogger<PetFeederOperation>();
            this.petService = petService;
            this.foodService = foodService;
            this.petFoodPreferenceService = petFoodPreferenceService;
            this.petFoodFeedService = petFoodFeedService;
            this.habiticaApiClient = habiticaApiClient;
        }

        public async Task RunOperationAsync()
        {
            //I guess this operation will focus on the initial basic pet & preferred food feeds.

            logger.LogInformation("Starting...");

            var userResult = await habiticaApiClient.GetUserAsync();

            var allPets = petService.GetUserPets(userResult.data.items);
            var allFoods = foodService.GetUserFoods(userResult.data.items);
            var basicPetFoodPreferences = petFoodPreferenceService.GetUserBasicPetPreferredFoods(allPets, allFoods);

            //#####
            //BASIC FEED OPERATION
            //#####

            var basicPetFeeds = petFoodFeedService.GetBasicPetPreferredFoodFeeds(allPets, allFoods, basicPetFoodPreferences);

            //Filter all-data lists for basic pets & non-saddle foods
            //var basicPets = petService.FilterPets(allPets, PetFilter.Basic);
            //var userFoodsNoSaddle = foodService.FilterFoods(allFoods, FoodFilter.NoSaddle);

            //Build a list of feeds for each pet and their preferred foods.

            ////Get feeds for each basic pet with each basic food.
            //var basicPetFeeds = petFoodService.GetPetFoodFeeds(basicPetFoodPreferences);

            //#####
            //END OF BASIC FEED OPERATION.
            //#####

            foreach (var petFeed in basicPetFeeds)
            {
                logger.LogInformation($"Pet {petFeed.PetFullName} will be fed {petFeed.FoodFullName} {petFeed.FeedQuantity} times.");
            }

            if (allPets.Where(x => x.IsBasicPet).All(x => x.FedPoints.Value >= 50))
            {
                logger.LogInformation("All basic pets have been fed.");
            }

            logger.LogInformation("Finished.");
        }
    }
}
