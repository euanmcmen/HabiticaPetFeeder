using HabiticaPetFeeder.App.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.App
{
    public class PetFoodPreferenceService : IPetFoodPreferenceService
    {
        private readonly ILogger<PetFoodPreferenceService> logger;

        public PetFoodPreferenceService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<PetFoodPreferenceService>();
        }

        public PetFoodPreferences GetUserBasicPetPreferredFoods(List<Pet> pets, List<Food> foods)
        {
            //Create the preferred pet foods collection.
            var petFoodPreferencesResult = new PetFoodPreferences();

            var basicPets = pets
                .Where(x => x.IsBasicPet)
                .ToHashSet();

            foreach (var pet in basicPets)
            {
                var matchingFoods = foods
                    .Where(x => x.Type == pet.Type && x.Quantity.Value > 0)
                    .OrderByDescending(x => x.Quantity.Value)
                    .ToHashSet();

                foreach (var food in matchingFoods)
                {
                    petFoodPreferencesResult.AddPetPreferredFood(pet, food);
                }
            }

            return petFoodPreferencesResult;
        }
    }
}
