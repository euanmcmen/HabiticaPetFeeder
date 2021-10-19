using HabiticaPetFeeder.Logic.Model.ContentResponse;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.ContentResponseParser
{
    public interface IContentResponseElementParser
    {
        HashSet<string> GetBasicPetNames(ContentResponse contentResponse);

        HashSet<string> GetFeedablePetNames(ContentResponse contentResponse);

        public Dictionary<string, string> GetFoodNameTypePairs(ContentResponse contentResponse);
    }
}