using HabiticaPetFeeder.App.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.App
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

        public List<Food> GetUserFoods(UserResponseDataItems data)
        {
            return userResponseElementParser.ExtractElement<Food>(data.food).ToList();
        }
    }
}
