using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HabiticaPetFeeder.App
{
    public class UserFetchResponseElementParser : IUserFetchResponseElementParser
    {
        public UserFetchResponseElementParser()
        {
        }

        public List<T> ExtractElement<T>(object obj, IUserFetchResponseParser<T> parserStrategy)
        {
            return GetPropertyNameValuePairs(obj).Select(x => ParseToType(x, parserStrategy)).ToList();
        }

        private static Dictionary<string, string> GetPropertyNameValuePairs(object obj)
        {
            return obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(key => key.Name, value => value.GetValue(obj).ToString());
        }

        private static T ParseToType<T>(KeyValuePair<string, string> input, IUserFetchResponseParser<T> parserStrategy)
        {
            return parserStrategy.Parse(input.Key, input.Value);
        }
    }
}
