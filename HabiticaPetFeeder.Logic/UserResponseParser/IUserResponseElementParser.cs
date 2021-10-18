using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.UserResponseParser
{
    public interface IUserResponseElementParser
    {
        IEnumerable<T> ExtractElement<T>(Dictionary<string, string> input) where T : class;
    }
}