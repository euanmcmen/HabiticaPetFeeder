using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.App
{
    public class FoodService : IFoodService
    {
        public enum FoodFilter
        {
            All,
            NoSaddle
        }

        private readonly ILogger<FoodService> logger;
        private readonly IUserResponseElementParser userResponseElementParser;
        public FoodService(ILoggerFactory loggerFactory, IUserResponseElementParser userResponseElementParser)
        {
            logger = loggerFactory.CreateLogger<FoodService>();
            this.userResponseElementParser = userResponseElementParser;
        }

        public List<Food> GetUserFoods(UserResponseDataItems data, FoodFilter foodFilter)
        {
            var allUserFoods = userResponseElementParser.ExtractElement<Food>(data.food);

            var result = new List<Food>();

            foreach (var food in allUserFoods)
            {
                //Apply filter.
                if (foodFilter == FoodFilter.NoSaddle)
                {
                    if(food.FullName == "Saddle")
                    {
                        continue;
                    }
                }

                result.Add(food);
            }

            return result;
        }
    }
}
