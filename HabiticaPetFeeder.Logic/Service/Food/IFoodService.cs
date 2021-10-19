using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Service
{
    public interface IFoodService
    {
        //IEnumerable<Food> GetUserFoods(UserResponseDataItems data);

        public IEnumerable<Food> FilterForFeedableFoodsByPreference(IEnumerable<Food> input, HashSet<string> preferenceNames);

        public IEnumerable<Food> FilterForFeedableFoodsByType(IEnumerable<Food> foods, string type);
    }
}