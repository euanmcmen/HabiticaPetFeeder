using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.App
{
    public class UserResponseElementParser : IUserResponseElementParser
    {
        private readonly IUserResponseParserFactory userResponseParserFactory;

        public UserResponseElementParser(IUserResponseParserFactory userResponseParserFactory)
        {
            this.userResponseParserFactory = userResponseParserFactory;
        }

        public List<T> ExtractElement<T>(Dictionary<string, string> input) where T: class
        {
            var strategy = userResponseParserFactory.GetUserResponseParser<T>();

            return input.Select(keyValuePair => strategy.Parse(keyValuePair.Key, keyValuePair.Value)).ToList();
        }
    }
}
