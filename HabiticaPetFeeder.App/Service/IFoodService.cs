using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IFoodService
    {
        List<Food> GetUserFoods(UserResponseDataItems data, FoodService.FoodFilter foodFilter);
    }
}