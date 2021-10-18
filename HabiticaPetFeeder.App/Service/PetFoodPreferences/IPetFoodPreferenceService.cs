﻿using HabiticaPetFeeder.App.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App.Service
{
    public interface IPetFoodPreferenceService
    {
        PetFoodPreferences GetUserBasicPetPreferredFoods(IEnumerable<Pet> pets, IEnumerable<Food> foods);
    }
}