using HabiticaPetFeeder.Logic.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Service.PetFoodPreferenceStrategy.Interfaces;

public interface IPetFoodPreferenceStrategy
{
    int Priority { get; }

    Dictionary<string, HashSet<string>> GetPreferences(IEnumerable<Pet> pets, IEnumerable<Food> foods);
}
