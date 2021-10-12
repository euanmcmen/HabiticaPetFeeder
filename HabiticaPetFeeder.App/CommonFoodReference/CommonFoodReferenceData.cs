using System;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public class CommonFoodReferenceData
    {
        //public Dictionary<string, string> CommonFoodPreferencesByType { get; init; }

        public Dictionary<string, string> CommonFoodPreferencesByName { get; init; }

        public CommonFoodReferenceData()
        {
            //var collection = new List<Tuple<string, string>>()
            //{
            //    new ("Base", "Meat"),
            //    new ("White", "Milk"),
            //    new ("Desert", "Potatoe"),
            //    new ("Red", "Strawberry"),
            //    new ("Shade", "Chocolate"),
            //    new ("Skeleton", "Fish"),
            //    new ("Zombie", "RottenMeat"),
            //    new ("CottonCandyPink", "CottonCandyPink"),
            //    new ("CottonCandyBlue", "CottonCandyBlue"),
            //    new ("Golden", "Honey")
            //};

            CommonFoodPreferencesByName = new Dictionary<string, string>
            {
                {"Meat", "Base" },
                {"Milk", "White" },
                {"Potatoe", "Desert" },
                {"Strawberry", "Red" },
                {"Chocolate", "Shade" },
                {"Fish", "Skeleton" },
                {"RottenMeat", "Zombie" },
                {"CottonCandyPink", "CottonCandyPink" },
                {"CottonCandyBlue", "CottonCandyBlue"},
                {"Honey", "Golden" }
            };

            //CommonFoodPreferencesByType = new Dictionary<string, string>();

            //CommonFoodPreferencesByName = new Dictionary<string, string>();

            //foreach (var item in collection)
            //{
            //    CommonFoodPreferencesByType.Add(item.Item1, item.Item2);
            //    CommonFoodPreferencesByName.Add(item.Item2, item.Item1);
            //}
        }
    }
}
