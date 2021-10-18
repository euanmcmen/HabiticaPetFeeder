using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Model
{
    public class PetFoodPreferences
    {
        private readonly Dictionary<Pet, HashSet<string>> petFoodPreferences;

        public PetFoodPreferences()
        {
            petFoodPreferences = new Dictionary<Pet, HashSet<string>>();
        }

        public void AddPetPreferredFood(Pet pet, Food food)
        {
            if (petFoodPreferences.ContainsKey(pet))
            {
                petFoodPreferences[pet].Add(food.FullName);
            }
            else
            {
                petFoodPreferences.Add(pet, new HashSet<string>() { food.FullName });
            }
        }

        public HashSet<string> GetPetPreferredFoodNames(Pet pet)
        {
            return petFoodPreferences.TryGetValue(pet, out var preferredFoods) 
                ? preferredFoods
                : new HashSet<string>();
        }
    }
}
