using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public class PropertyReflector : IPropertyReflector
    {
        public Dictionary<string, string> GetPropertyNameValuePairs(object obj)
        {
            return obj.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .ToDictionary(key => key.Name, value => value.GetValue(obj).ToString());
        }
    }
}
