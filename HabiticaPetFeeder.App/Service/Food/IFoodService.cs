using HabiticaPetFeeder.App.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IFoodService
    {
        IEnumerable<Food> GetUserFoods(UserResponseDataItems data);

        public IEnumerable<Food> FilterForFeedableFoodsByPreference(IEnumerable<Food> input, HashSet<string> preferenceNames);

        public IEnumerable<Food> FilterForFeedableFoodsByType(IEnumerable<Food> foods, string type);
    }
}