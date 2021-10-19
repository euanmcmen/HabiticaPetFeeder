using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Model.UserResponse
{
    public class UserResponseDataItems
    {
        public Dictionary<string, int> pets { get; set; }
        public Dictionary<string, int> food { get; set; }
    }
}