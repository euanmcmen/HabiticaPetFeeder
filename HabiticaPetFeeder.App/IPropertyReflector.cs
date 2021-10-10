using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IPropertyReflector
    {
        Dictionary<string, string> GetPropertyNameValuePairs(object obj);
    }
}