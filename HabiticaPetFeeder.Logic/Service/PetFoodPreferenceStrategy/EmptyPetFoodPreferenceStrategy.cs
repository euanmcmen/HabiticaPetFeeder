using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.PetFoodPreferenceStrategy.Abstraction;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Service.PetFoodPreferenceStrategy;

public class EmptyPetFoodPreferenceStrategy : IPetFoodPreferenceStrategy
{
    public int Priority => 10;

    public Dictionary<string, HashSet<string>> GetPreferences(IEnumerable<Pet> pets, IEnumerable<Food> foods)
    {
        return new Dictionary<string, HashSet<string>>();
    }
}
