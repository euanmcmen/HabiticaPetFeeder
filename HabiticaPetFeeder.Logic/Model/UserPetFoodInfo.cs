using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;

namespace HabiticaPetFeeder.Logic.Model;

public class UserPetFoodInfo
{
    public ContentResponse Content { get; set; }

    public UserResponse User { get; set; }
}
