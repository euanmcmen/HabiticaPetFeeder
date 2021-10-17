using HabiticaPetFeeder.App.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IPetFoodFeedService
    {
        /// <summary>
        /// Returns a list of PetFoodFeeds for each basic pet and their preferred foods from the corresponding collections.
        /// </summary>
        /// <param name="pets"></param>
        /// <param name="foods"></param>
        /// <param name="petFoodPreferences"></param>
        /// <returns></returns>
        List<PetFoodFeed> GetBasicPetPreferredFoodFeeds(List<Pet> pets, List<Food> foods, PetFoodPreferences petFoodPreferences);
    }
}