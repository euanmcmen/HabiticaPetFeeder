using Microsoft.Extensions.Logging;

namespace HabiticaPetFeeder.App
{
    public class UserResponseFoodParser : IUserResponseParser<Food>
    {
        private readonly ILogger<UserResponseFoodParser> logger;
        private readonly ICommonFoodReferenceData commonFoodReferenceData;

        public UserResponseFoodParser(ILoggerFactory loggerFactory, ICommonFoodReferenceData commonFoodReferenceData)
        {
            logger = loggerFactory.CreateLogger<UserResponseFoodParser>();
            this.commonFoodReferenceData = commonFoodReferenceData;
        }

        public Food Parse(string propertyName, string propertyValue)
        {
            var foodParts = propertyName.Split("_");

            return new Food(propertyName, foodParts[0], GetFoodTypeOrDefault(foodParts), int.Parse(propertyValue));
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

            if (commonFoodReferenceData.CommonFoodPreferencesByName.TryGetValue(foodParts[0], out var type))
            {
                return type;
            }

            logger.LogWarning($"Food {foodParts[0]} has no corresponding type in the {nameof(CommonFoodReferenceData)} collection.");

            return "NONE";
        }
    }
}
