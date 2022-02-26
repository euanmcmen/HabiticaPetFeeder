using HabiticaPetFeeder.Logic.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Service.Interfaces;

public interface IPetFoodFeedService
{
    List<PetFoodFeed> GetPetFoodFeedsWithConfiguredPreferences(IEnumerable<Pet> pets, IEnumerable<Food> foods);

    //IEnumerable<PetFoodFeed> GetPreferredFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods, PetFoodPreferences petFoodPreferences);

    //IEnumerable<PetFoodFeed> GetFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods);
}
