﻿using HabiticaPetFeeder.App.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App.Service
{
    public interface IPetFoodFeedService
    {
        IEnumerable<PetFoodFeed> GetPreferredFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods, PetFoodPreferences petFoodPreferences);

        IEnumerable<PetFoodFeed> GetFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods);
    }
}