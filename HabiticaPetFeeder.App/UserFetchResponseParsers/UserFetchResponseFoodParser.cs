using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public class UserFetchResponseFoodParser : IUserFetchResponseParser<Food>
    {
        private readonly ICommonFoodsReferenceService commonFoodsReferenceService;

        public UserFetchResponseFoodParser(ICommonFoodsReferenceService commonFoodsReferenceService)
        {
            this.commonFoodsReferenceService = commonFoodsReferenceService;
        }

        public Food Parse(string propertyName, string propertyValue)
        {
            var foodParts = propertyName.Split("_");

            var name = foodParts[0];

            var type = (foodParts.Length > 1)
                ? foodParts[1]                                                      //e.g. "Cake_CottonCandyPink", "Candy_Red"
                : commonFoodsReferenceService.GetPreferringTypeForFood(name);       //e.g. "Meat" or "Milk".

            var quantity = int.Parse(propertyValue);

            return new Food(name, type, quantity);
        }
    }
}
