using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using HabiticaPetFeeder.Logic.UserResponseParser;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Service
{
    public class FoodService : IFoodService
    {
        private readonly ILogger<FoodService> logger;
        private readonly IUserResponseElementParser userResponseElementParser;

        public FoodService(ILoggerFactory loggerFactory, IUserResponseElementParser userResponseElementParser)
        {
            logger = loggerFactory.CreateLogger<FoodService>();
            this.userResponseElementParser = userResponseElementParser;
        }

        public IEnumerable<Food> GetUserFoods(UserResponseDataItems data)
        {
            return userResponseElementParser
                .ExtractElement<Food>(data.food)
                .Where(x => x.FullName != "Saddle")
                .ToHashSet();
        }

        public IEnumerable<Food> FilterForFeedableFoodsByPreference(IEnumerable<Food> foods, HashSet<string> preferenceNames)
        {
            var result = foods;

            if (preferenceNames != null)
            {
                result = result.Where(x => preferenceNames.Contains(x.FullName));
            }

            return ToSortedQuantity(result);

        }

        public IEnumerable<Food> FilterForFeedableFoodsByType(IEnumerable<Food> foods, string type)
        {
            return ToSortedQuantity(foods.Where(x => x.Type == type));
        }

        private static IEnumerable<Food> ToSortedQuantity(IEnumerable<Food> foods)
        {
            return foods.Where(x => x.Quantity.Value > 0)
                .OrderByDescending(x => x.Quantity.Value)
                .ToHashSet();
        }
    }
}
