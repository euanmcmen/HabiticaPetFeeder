using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface ICommonFoodReferenceData
    {
        Dictionary<string, string> CommonFoodPreferencesByType { get; init; }

        Dictionary<string, string> CommonFoodPreferencesByName { get; init; }
    }
}
