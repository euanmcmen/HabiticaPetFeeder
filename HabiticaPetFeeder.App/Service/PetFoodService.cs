using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.App
{
    public class PetFoodService : IPetFoodService
    {
        private readonly ILogger<PetFoodService> logger;

        public PetFoodService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<PetFoodService>();
        }

        //TODO - this list is affecting the parameter.  This is bad design.
        public List<PetFoodFeed> GetPetFoodFeeds(Dictionary<Pet, List<Food>> petFoodPreferences)
        {
            //Build a list of Basic Pet Food Feeds
            var basicPetFeeds = new List<PetFoodFeed>();

            foreach (var petFoodPreference in petFoodPreferences)
            {
                //Calculate how many portions of the pet's preferred food are required to reach 50.
                //Each preferred food feed is worth 5 points.
                var requiredNumberOfFeeds = (int)(10 - MathF.Floor(petFoodPreference.Key.FedPoints / 5));

                var allocatedFeedsForThisPet = 0;

                foreach (var preferredFood in petFoodPreference.Value)
                {
                    var allocationsOfThisFood = 0;

                    while (preferredFood.Quantity > 0 && allocatedFeedsForThisPet < requiredNumberOfFeeds)
                    {
                        //Move onto the next preferred food after exhausting this one.
                        if (preferredFood.Quantity == 0)
                            break;

                        //Stop allocating feeds to this pet.
                        if (allocatedFeedsForThisPet >= requiredNumberOfFeeds)
                            break;

                        preferredFood.Quantity--;

                        allocatedFeedsForThisPet++;

                        allocationsOfThisFood++;
                    }

                    if (allocationsOfThisFood > 0)
                    {
                        var petFeed = new PetFoodFeed(petFoodPreference.Key.FullName, preferredFood.FullName, allocationsOfThisFood);

                        basicPetFeeds.Add(petFeed);

                        logger.LogInformation($"Pet {petFeed.PetFullName} will be fed {petFeed.FoodFullName} {petFeed.FeedQuantity} times.");
                    }
                }
            }

            return basicPetFeeds;
        }

        public Dictionary<Pet, List<Food>> GetPetFoodPreferences(List<Pet> pets, List<Food> foods)
        {
            //Create the preferred pet foods collection.
            var petFoodPreferencesResult = new Dictionary<Pet, List<Food>>();

            foreach (var pet in pets)
            {
                foreach (var food in foods)
                {
                    if (food.Type != pet.Type)
                        continue;

                    if (petFoodPreferencesResult.ContainsKey(pet))
                    {
                        petFoodPreferencesResult[pet].Add(food);
                    }
                    else
                    {
                        petFoodPreferencesResult.Add(pet, new List<Food>() { food });
                    }

                    //NOTES
                    //If the pet is a Magic Potion pet, it will have no "favourites" because pets hatched with Magic Potions prefer everything.
                    //I'm leaving those for now.
                }
            }

            foreach (var petFoodPreference in petFoodPreferencesResult)
            {
                //Sort each pet's food by descending quantity.
                petFoodPreference.Value.Sort((x, y) => y.Quantity.CompareTo(x.Quantity));

                logger.LogInformation($"Pet {petFoodPreference.Key.FullName} really likes {string.Join(" & ", petFoodPreference.Value.Select(x => x.FullName))}");
            }

            return petFoodPreferencesResult;
        }
    }
}
