using HabiticaPetFeeder.Logic.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Service
{
    public class PetFoodPreferenceService : IPetFoodPreferenceService
    {
        private readonly ILogger<PetFoodPreferenceService> logger;
        private readonly IPetService petService;
        private readonly IFoodService foodService;

        public PetFoodPreferenceService(ILoggerFactory loggerFactory, IPetService petService, IFoodService foodService)
        {
            logger = loggerFactory.CreateLogger<PetFoodPreferenceService>();
            this.petService = petService;
            this.foodService = foodService;
        }

        public PetFoodPreferences GetUserBasicPetPreferredFoods(IEnumerable<Pet> pets, IEnumerable<Food> foods)
        {
            var petFoodPreferencesResult = new PetFoodPreferences();

            var basicPets = petService.FilterForBasicPets(pets);

            foreach (var pet in basicPets)
            {
                var matchingFoods = foodService.FilterForFeedableFoodsByType(foods, pet.Type);

                foreach (var food in matchingFoods)
                {
                    petFoodPreferencesResult.AddPetPreferredFood(pet, food);
                }
            }

            return petFoodPreferencesResult;
        }
    }
}
