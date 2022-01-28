using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Util
{
    public static class CollectionExtensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();
    }
}
