using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public class PetFeederOperation
    {
        private readonly ILogger<PetFeederOperation> logger;
        private readonly IPetService petService;
        private readonly IFoodService foodService;
        private readonly IPetFoodService petFoodService;
        private readonly IHabiticaApiClient habiticaApiClient;

        public PetFeederOperation(ILoggerFactory loggerFactory,
            IPetService petService,
            IFoodService foodService,
            IPetFoodService petFoodService,
            IHabiticaApiClient habiticaApiClient)
        {
            logger = loggerFactory.CreateLogger<PetFeederOperation>();
            this.petService = petService;
            this.foodService = foodService;
            this.petFoodService = petFoodService;
            this.habiticaApiClient = habiticaApiClient;
        }

        public async Task RunOperationAsync()
        {
            //I guess this operation will focus on the initial basic pet & preferred food feeds.

            logger.LogInformation("Starting...");

            var userResult = await habiticaApiClient.GetUserAsync();

            //Build a list of basic pets.
            var basicUserPets = petService.GetUserPets(userResult.data.items, PetService.PetFilter.Basic);

            //Build a list of non-saddle foods.
            var userFoodsNoSaddle = foodService.GetUserFoods(userResult.data.items, FoodService.FoodFilter.NoSaddle);

            //Build a list of feeds for each pet and their preferred foods.
            //var basicPetFeeds = GetPetFoodFeeds(GetPetFoodPreferences(basicUserPets, userFoodsNoSaddle));
            var basicPetFoodPreferences = petFoodService.GetPetFoodPreferences(basicUserPets, userFoodsNoSaddle);
            var basicPetFeeds = petFoodService.GetPetFoodFeeds(basicPetFoodPreferences);

            foreach (var petFeed in basicPetFeeds)
            {
                logger.LogInformation($"Pet {petFeed.PetFullName} will be fed {petFeed.FoodFullName} {petFeed.FeedQuantity} times.");
            }

            logger.LogInformation("Finished.");
        }
    }
}
