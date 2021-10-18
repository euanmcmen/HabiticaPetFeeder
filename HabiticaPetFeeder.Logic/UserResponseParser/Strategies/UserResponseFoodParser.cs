﻿using HabiticaPetFeeder.Logic.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.UserResponseParser
{
    public class UserResponseFoodParser : IUserResponseParser<Food>
    {
        private readonly static Dictionary<string, string> commonFoodPreferencesByName = new()
        {
                {"Meat", "Base" },
                {"Milk", "White" },
                { "Potatoe", "Desert" },
                { "Strawberry", "Red" },
                { "Chocolate", "Shade" },
                { "Fish", "Skeleton" },
                { "RottenMeat", "Zombie" },
                { "CottonCandyPink", "CottonCandyPink" },
                { "CottonCandyBlue", "CottonCandyBlue"},
                { "Honey", "Golden" }
        };

        private readonly ILogger<UserResponseFoodParser> logger;

        public UserResponseFoodParser(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<UserResponseFoodParser>();
        }

        public Food Parse(string propertyName, string propertyValue)
        {
            var foodParts = propertyName.Split("_");

            var food = new Food(propertyName, GetFoodTypeOrDefault(foodParts), new DecreasingQuantity(int.Parse(propertyValue)));

            return food;
        }

        private string GetFoodTypeOrDefault(string[] foodParts)
        {
            //FOODS
            //Common foods resolve their type through the common food reference data.
            //Meat is the name and, through the cfrd, can resolve that "Base" is the type.

            //Complex foods follow the convention {varient}_{type} e.g. Cake_CottonCandyPink where CottonCandyPink is the type.

            if (foodParts.Length > 1)
            {
                //e.g. {Type}: "Cake_CottonCandyPink", "Candy_Red"

                return foodParts[1];
            }

            //e.g. {Name} with type to resolve: "Meat", "Milk", "CottonCandyPink"

            if (commonFoodPreferencesByName.TryGetValue(foodParts[0], out var type))
            {
                return type;
            }

            logger.LogWarning($"Food {foodParts[0]} has no resolvable type.");

            return "NONE";
        }
    }
}
