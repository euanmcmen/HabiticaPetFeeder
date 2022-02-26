using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Service;

public class BasicPetFoodPreferenceStrategy : IPetFoodPreferenceStrategy
{
    public int Priority => 0;

    public Dictionary<string, HashSet<string>> GetPreferences(IEnumerable<Pet> pets, IEnumerable<Food> foods)
    {
        var petFoodPreferencesResult = new Dictionary<string, HashSet<string>>();

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
                if (petFoodPreferencesResult.ContainsKey(pet.FullName))
                {
                    petFoodPreferencesResult[pet.FullName].Add(food.FullName);
                }
                else
                {
                    petFoodPreferencesResult.Add(pet.FullName, new HashSet<string>() { food.FullName });
                }
            }
        }

        return petFoodPreferencesResult;
    }
}
