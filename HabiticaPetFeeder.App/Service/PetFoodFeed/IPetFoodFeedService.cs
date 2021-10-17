using HabiticaPetFeeder.App.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IPetFoodFeedService
    {
        /// <summary>
        /// Returns a list of PetFoodFeeds for each pet for their preferred foods.
        /// </summary>
        /// <param name="pets"></param>
        /// <param name="foods"></param>
        /// <param name="petFoodPreferences"></param>
        /// <returns></returns>
        List<PetFoodFeed> GetPreferredFoodFeeds(List<Pet> pets, List<Food> foods, PetFoodPreferences petFoodPreferences);

        /// <summary>
        /// Returns a list of PetFoodFeeds for each pet.
        /// </summary>
        /// <param name="pets"></param>
        /// <param name="foods"></param>
        /// <returns></returns>
        List<PetFoodFeed> GetFoodFeeds(List<Pet> pets, List<Food> foods);
    }
}