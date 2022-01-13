using HabiticaPetFeeder.Logic.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Service.Interfaces;

public interface IPetFoodPreferenceService
{
    PetFoodPreferences GetUserBasicPetPreferredFoods(IEnumerable<Pet> pets, IEnumerable<Food> foods);
}
