using HabiticaPetFeeder.Logic.Model.ContentResponse;
using HabiticaPetFeeder.Logic.Util;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.ContentResponseParser
{
    public class ContentResponseElementParser : IContentResponseElementParser
    {
        public HashSet<string> GetBasicPetNames(ContentResponse contentResponse)
        {
            return contentResponse.data.pets.GetKeyUnion();
        }

        public HashSet<string> GetFeedablePetNames(ContentResponse contentResponse)
        {
            return contentResponse.data.pets.GetKeyUnion(contentResponse.data.premiumPets);
        }

        public Dictionary<string, string> GetFoodNameTypePairs(ContentResponse contentResponse)
        {
            return contentResponse.data.food.ToDictionary(x => x.Key, x => x.Value.target);
        }
    }
}
