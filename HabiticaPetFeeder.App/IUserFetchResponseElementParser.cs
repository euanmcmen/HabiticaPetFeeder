using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IUserFetchResponseElementParser
    {
        List<T> ExtractElement<T>(object obj, IUserFetchResponseParser<T> parserStrategy);
    }
}