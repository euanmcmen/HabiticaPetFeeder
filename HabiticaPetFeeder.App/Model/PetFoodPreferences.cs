using System.Collections.Generic;

namespace HabiticaPetFeeder.App.Model
{
    public class PetFoodPreferences
    {
        private readonly Dictionary<Pet, List<Food>> petFoodPreferences;

        public PetFoodPreferences()
        {
            petFoodPreferences = new Dictionary<Pet, List<Food>>();
        }

        public void AddPetPreferredFood(Pet pet, Food food)
        {
            if (petFoodPreferences.ContainsKey(pet))
            {
                petFoodPreferences[pet].Add(food);
            }
            else
            {
                petFoodPreferences.Add(pet, new List<Food>() { food });
            }

            petFoodPreferences[pet].Sort((x, y) => ByDescending(x, y));
        }

        public List<Food> GetPetPreferredFood(Pet pet) => petFoodPreferences.TryGetValue(pet, out var result) ? result : new List<Food>();

        private static int ByDescending(Food x, Food y) => y.Quantity.Value.CompareTo(x.Quantity.Value);
    }
}
