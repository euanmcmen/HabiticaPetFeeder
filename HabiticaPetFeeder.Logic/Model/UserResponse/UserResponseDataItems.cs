using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Model.UserResponse
{
    public class UserResponseDataItems
    {
        public Dictionary<string, string> pets { get; set; }
        public Dictionary<string, string> food { get; set; }
    }
}