using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IUserFetchResponseParser<T>
    {
        public T Parse(string propertyName, string propertyValue);
    }
}
