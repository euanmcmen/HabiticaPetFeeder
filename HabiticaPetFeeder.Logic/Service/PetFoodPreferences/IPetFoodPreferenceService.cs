using HabiticaPetFeeder.Logic.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Service.PetFoodPreferences
{
    public interface IPetFoodPreferenceService
    {
        Model.PetFoodPreferences GetUserBasicPetPreferredFoods(IEnumerable<Pet> pets, IEnumerable<Food> foods);
    }
}