using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;

namespace HabiticaPetFeeder.Logic.Model;

public class UserContentPair
{
    public ContentResponse Content { get; set; }

    public UserResponse User { get; set; }
}
