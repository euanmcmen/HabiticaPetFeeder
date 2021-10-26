using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Model
{
    public interface IPetFoodPreference
    {
        HashSet<string> GetPetPreferredFoodNames(Pet pet);

        HashSet<string> GetPetsWithPreferences();
    }

    public class EmptyPetPreferences : IPetFoodPreference
    {
        public HashSet<string> GetPetPreferredFoodNames(Pet pet)
        {
            return new HashSet<string>();
        }

        public HashSet<string> GetPetsWithPreferences()
        {
            return new HashSet<string>();
        }
    }

    public class PetFoodPreferences : IPetFoodPreference
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

        public HashSet<string> GetPetsWithPreferences()
        {
            return petFoodPreferences.Keys
                .Select(x => x.FullName)
                .ToHashSet();
        }

        public HashSet<string> GetPetPreferredFoodNames(Pet pet)
        {
            return petFoodPreferences.TryGetValue(pet, out var preferredFoods) 
                ? preferredFoods
                : new HashSet<string>();
        }
    }
}
