using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public class FoodService
    {
        private readonly ICommonFoodsReferenceService commonFoodsReferenceService;
        private readonly IPropertyReflector propertyReflector;

        public FoodService(ICommonFoodsReferenceService commonFoodsReferenceService, IPropertyReflector propertyReflector)
        {
            this.commonFoodsReferenceService = commonFoodsReferenceService;
            this.propertyReflector = propertyReflector;
        }

        public List<Food> ExtractFoods(UserFetchResponseDataFoods userFoods)
        {
            var userFoodPropertyInfo = propertyReflector.GetPropertyNameValuePairs(userFoods);

            return userFoodPropertyInfo.Select(ParseFoodFromPropertyInfo).ToList();
        }

        private Food ParseFoodFromPropertyInfo(KeyValuePair<string, string> propertyInfo)
        {
            var foodParts = propertyInfo.Key.Split("_");

            var name = foodParts[0];

            var type = (foodParts.Length > 1)
                ? foodParts[1]                                                      //e.g. "Cake_CottonCandyPink", "Candy_Red"
                : commonFoodsReferenceService.GetPreferringTypeForFood(name);       //e.g. "Meat" or "Milk".

            var quantity = int.Parse(propertyInfo.Value);

            return new Food(name, type, quantity);
        }
    }
}
