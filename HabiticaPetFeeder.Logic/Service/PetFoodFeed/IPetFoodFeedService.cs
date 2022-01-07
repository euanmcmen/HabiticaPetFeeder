using HabiticaPetFeeder.Logic.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Service.PetFoodFeed
{
    public interface IPetFoodFeedService
    {
        IEnumerable<Model.PetFoodFeed> GetPreferredFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods, Model.PetFoodPreferences petFoodPreferences);

        IEnumerable<Model.PetFoodFeed> GetFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods);
    }
}