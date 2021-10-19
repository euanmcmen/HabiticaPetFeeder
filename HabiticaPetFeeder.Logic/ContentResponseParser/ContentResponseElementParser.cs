using HabiticaPetFeeder.Logic.Model.ContentResponse;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.ContentResponseParser
{
    public class ContentResponseElementParser : IContentResponseElementParser
    {
        public HashSet<string> GetBasicPetNames(ContentResponse contentResponse)
        {
            return GetKeyUnion(contentResponse.data.pets);
        }

        public HashSet<string> GetFeedablePetNames(ContentResponse contentResponse)
        {
            return GetKeyUnion(contentResponse.data.pets, contentResponse.data.premiumPets);
        }

        public Dictionary<string, string> GetFoodNameTypePairs(ContentResponse contentResponse)
        {
            return contentResponse.data.food.ToDictionary(x => x.Key, x => x.Value.target);
        }

        private static HashSet<string> GetKeyUnion(params Dictionary<string, string>[] dictionaries)
        {
            var result = new HashSet<string>();

            foreach (var dictionary in dictionaries)
            {
                result.UnionWith(dictionary.Keys);
            }

            return result;
        }
    }
}
