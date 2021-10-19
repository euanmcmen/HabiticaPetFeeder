using HabiticaPetFeeder.Logic.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Service
{
    public class FoodService : IFoodService
    {
        private readonly ILogger<FoodService> logger;

        public FoodService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<FoodService>();
        }

        //public IEnumerable<Food> GetUserFoods(UserResponseDataItems data)
        //{
        //    throw new NotImplementedException();
        //    //return userResponseElementParser
        //    //    .ExtractElement<Food>(data.food)
        //    //    .Where(x => x.FullName != "Saddle")
        //    //    .ToHashSet();
        //}

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
