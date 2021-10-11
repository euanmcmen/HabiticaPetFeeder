using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IUserResponseElementParser
    {
        List<T> ExtractElement<T>(Dictionary<string, string> input) where T : class;
    }
}