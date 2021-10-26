using HabiticaPetFeeder.Logic.Model;
using Microsoft.Extensions.Logging;
using System;
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
            throw new NotImplementedException();
            //return ToSortedQuantity(foods.Where(x => preferenceNames.Contains(x.FullName)));
        }

        //public IEnumerable<Food> FilterForFeedableFoodsByPreference(IEnumerable<Food> foods, Pet pet, preference)
        //{
        //    petFoodPreferences.GetPetPreferredFoodNames(pet)
        //    return ToSortedQuantity(foods.Where(x => preferenceNames.Contains(x.FullName)));
        //}

        public IEnumerable<Food> FilterForFeedableFoodsByType(IEnumerable<Food> foods, string type)
        {
            throw new NotImplementedException();
            //return ToSortedQuantity(foods.Where(x => x.Type == type));
        }


    }
}
