using HabiticaPetFeeder.App.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IPetFoodPreferenceService
    {
        PetFoodPreferences GetUserBasicPetPreferredFoods(List<Pet> pets, List<Food> foods);
    }
}