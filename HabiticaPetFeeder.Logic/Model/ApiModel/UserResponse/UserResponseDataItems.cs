using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;

public class UserResponseDataItems
{
    public Dictionary<string, int> pets { get; set; }
    public Dictionary<string, int> food { get; set; }
    public Dictionary<string, bool> mounts { get; set; }
}
