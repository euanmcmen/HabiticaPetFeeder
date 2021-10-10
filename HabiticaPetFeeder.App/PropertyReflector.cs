using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HabiticaPetFeeder.App
{
    public class PropertyReflector : IPropertyReflector
    {
        public Dictionary<string, string> GetPropertyNameValuePairs(object obj)
        {
            return obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(key => key.Name, value => value.GetValue(obj).ToString());
        }
    }
}
