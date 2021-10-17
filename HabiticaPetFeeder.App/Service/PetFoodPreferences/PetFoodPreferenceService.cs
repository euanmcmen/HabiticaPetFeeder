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

            foreach (var pet in pets)
            {
                //Only basic pets have food preferences.  Magic potion pets (non-basic pets) can be fed anything.
                if (!pet.IsBasicPet)
                    continue;

                foreach (var food in foods)
                {
                    if (food.Type != pet.Type)
                        continue;

                    petFoodPreferencesResult.AddPetPreferredFood(pet, food);
                }
            }

            return petFoodPreferencesResult;
        }
    }
}
