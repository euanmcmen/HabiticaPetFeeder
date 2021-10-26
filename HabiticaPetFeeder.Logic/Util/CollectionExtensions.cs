using HabiticaPetFeeder.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Util
{
    public static class CollectionExtensions
    {
        //public static HashSet<string> KeyHashset<TSource>(this Dictionary<string, TSource> source, params Dictionary<string, string>[] dictionaries)
        //{
        //    if (source == null) 
        //        throw new ArgumentNullException(nameof(source));

        //    if (dictionaries == null || dictionaries.Length == 0) 
        //        return source.Keys.ToHashSet();

        //    var result = new HashSet<string>();

        //    result.UnionWith(source.Keys);

        //    foreach (var dictionary in dictionaries)
        //    {
        //        result.UnionWith(dictionary.Keys);
        //    }

        //    return result;
        //}

        //public static IEnumerable<Food> SortByQuantityDescending(this IEnumerable<Food> foods)
        //{
        //    return foods.Where(x => x.Quantity.Value > 0).OrderByDescending(x => x.Quantity.Value);
        //}

        public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();
    }
}
