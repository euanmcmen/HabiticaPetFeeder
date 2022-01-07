using HabiticaPetFeeder.Logic.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Service.PetFoodPreferences
{
    public class PetFoodPreferenceService : IPetFoodPreferenceService
    {
        private readonly ILogger<PetFoodPreferenceService> logger;

        public PetFoodPreferenceService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<PetFoodPreferenceService>();
        }

        public Model.PetFoodPreferences GetUserBasicPetPreferredFoods(IEnumerable<Pet> pets, IEnumerable<Food> foods)
        {
            var petFoodPreferencesResult = new Model.PetFoodPreferences();

            var basicPets = pets
                .Where(x => x.IsBasicPet)
                .ToHashSet();

            foreach (var pet in basicPets)
            {
                var matchingFoods = foods
                    .Where(x => x.Quantity.Value > 0)
                    .Where(x => x.Type == pet.Type)
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
