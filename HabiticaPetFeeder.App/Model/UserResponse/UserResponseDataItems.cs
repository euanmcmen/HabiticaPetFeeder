using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public class UserResponseDataItems
    {
        public Dictionary<string, string> pets { get; set; }
        public Dictionary<string, string> food { get; set; }
    }
}