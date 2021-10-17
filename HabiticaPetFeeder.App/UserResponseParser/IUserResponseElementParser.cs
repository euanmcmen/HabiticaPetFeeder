using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IUserResponseElementParser
    {
        IEnumerable<T> ExtractElement<T>(Dictionary<string, string> input) where T : class;
    }
}