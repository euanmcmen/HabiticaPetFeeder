using HabiticaPetFeeder.App.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IPetFoodPreferenceService
    {
        PetFoodPreferences GetUserBasicPetPreferredFoods(IEnumerable<Pet> pets, IEnumerable<Food> foods);
    }
}