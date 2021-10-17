using HabiticaPetFeeder.App.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public class PetFoodFeedService : IPetFoodFeedService
    {
        private readonly ILogger<PetFoodFeedService> logger;
        private readonly IPetService petService;
        private readonly IFoodService foodService;
        private const int NonPreferredFoodFeedPoints = 2;
        private const int PreferredFoodFeedPoints = 5;

        public PetFoodFeedService(ILoggerFactory loggerFactory, IPetService petService, IFoodService foodService)
        {
            logger = loggerFactory.CreateLogger<PetFoodFeedService>();
            this.petService = petService;
            this.foodService = foodService;
        }

        public IEnumerable<PetFoodFeed> GetPreferredFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods, PetFoodPreferences petFoodPreferences)
        {
            return GetFoodFeedsWithPreference(pets, foods, petFoodPreferences);
        }

        public IEnumerable<PetFoodFeed> GetFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods)
        {
            return GetFoodFeedsWithPreference(pets, foods, null);
        }

        private IEnumerable<PetFoodFeed> GetFoodFeedsWithPreference(IEnumerable<Pet> pets, IEnumerable<Food> foods, PetFoodPreferences petFoodPreferences = null)
        {
            var petFeeds = new HashSet<PetFoodFeed>();

            var petsToFeed = petService.FilterForFeedablePets(pets);

            foreach (var pet in petsToFeed)
            {
                var preferredFoodNames = petFoodPreferences?.GetPetPreferredFoodNames(pet) ?? null;

                var foodsToFeed = foodService.FilterForFeedableFoodsByPreference(foods, preferredFoodNames);

                foreach (var food in foodsToFeed)
                {
                    var allocationsOfThisFoodToThisPet = 0;

                    var fedPointsAdjustment = (!pet.IsBasicPet || pet.Type == food.Type)
                        ? PreferredFoodFeedPoints
                        : NonPreferredFoodFeedPoints;

                    while (food.Quantity.Value > 0 && pet.FedPoints.Value < 50)
                    {
                        //Allocate an instance of this food to this pet.
                        allocationsOfThisFoodToThisPet++;

                        //Ajust the pet and food quantities.
                        food.Quantity.Adjust(1);
                        pet.FedPoints.Adjust(fedPointsAdjustment);
                    }

                    if (allocationsOfThisFoodToThisPet > 0)
                    {
                        petFeeds.Add(new PetFoodFeed(pet.FullName, food.FullName, allocationsOfThisFoodToThisPet));
                    }
                }
            }

            return petFeeds;
        }
    }
}
