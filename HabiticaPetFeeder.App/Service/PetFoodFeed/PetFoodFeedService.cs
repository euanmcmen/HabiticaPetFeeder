using HabiticaPetFeeder.App.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public class PetFoodFeedService : IPetFoodFeedService
    {
        private readonly ILogger<PetFoodFeedService> logger;

        private const int PreferredFoodFeedPoints = 5;

        public PetFoodFeedService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<PetFoodFeedService>();
        }

        public List<PetFoodFeed> GetBasicPetPreferredFoodFeeds(List<Pet> pets, List<Food> foods, PetFoodPreferences petFoodPreferences)
        {
            var basicPetFeeds = new List<PetFoodFeed>();

            var fedPets = new List<Pet>();
            var allocatedFood = new List<Food>();

            foreach (var pet in pets)
            {
                //Only process basic pets
                if (!pet.IsBasicPet)
                    continue;

                //Only feed pets which have not been fed.
                if (pet.FedPoints.Value >= 50)
                    continue;

                var requiredNumberOfFeeds = (int)(10 - MathF.Floor(pet.FedPoints.Value / PreferredFoodFeedPoints));

                //If the pet exists in the pet-food preferences collection:
                //For that pet's preferred foods

                foreach (var preferredFood in petFoodPreferences.GetPetPreferredFood(pet))
                {
                    //Find the food in the foods collection.
                    //If it exists, start allocating feeds for the pet.

                    var food = foods.Find(x => x.FullName == preferredFood.FullName);

                    if (food != null)
                    {
                        var allocationsOfThisFood = 0;

                        for (int foodQuantity = food.Quantity.Value; foodQuantity > 0; foodQuantity--)
                        {
                            if (requiredNumberOfFeeds == 0)
                                break;

                            //Allocate an instance of this food.
                            allocationsOfThisFood++;

                            //Decrease the number of allocations required for this pet.
                            requiredNumberOfFeeds--;

                            //Ajust the pet and food quantities.
                            food.Quantity.Adjust(1);
                            pet.FedPoints.Adjust(PreferredFoodFeedPoints);
                        }

                        if (allocationsOfThisFood > 0)
                        {
                            var petFeed = new PetFoodFeed(pet.FullName, preferredFood.FullName, allocationsOfThisFood);

                            basicPetFeeds.Add(petFeed);

                            logger.LogInformation($"Pet {petFeed.PetFullName} will be fed {petFeed.FoodFullName} {petFeed.FeedQuantity} times.");
                        }
                    }
                }

            }

            return basicPetFeeds;
        }
    }

    //TODO - this list is affecting the parameter.  This is bad design.
    //public List<PetFoodFeed> GetPetFoodFeeds(Dictionary<Pet, List<Food>> petFoodPreferences)
    //{
    //    //Build a list of Basic Pet Food Feeds
    //    var basicPetFeeds = new List<PetFoodFeed>();

    //    foreach (var petFoodPreference in petFoodPreferences)
    //    {
    //        //Calculate how many portions of the pet's preferred food are required to reach 50.
    //        //Each preferred food feed is worth 5 points.
    //        var requiredNumberOfFeeds = (int)(10 - MathF.Floor(petFoodPreference.Key.FedPoints / 5));

    //        var allocatedFeedsForThisPet = 0;

    //        foreach (var preferredFood in petFoodPreference.Value)
    //        {
    //            var allocationsOfThisFood = 0;

    //            while (preferredFood.Quantity > 0 && allocatedFeedsForThisPet < requiredNumberOfFeeds)
    //            {
    //                //Move onto the next preferred food after exhausting this one.
    //                if (preferredFood.Quantity == 0)
    //                    break;

    //                //Stop allocating feeds to this pet.
    //                if (allocatedFeedsForThisPet >= requiredNumberOfFeeds)
    //                    break;

    //                preferredFood.Quantity--;

    //                petFoodPreference.Key.FedPoints += 5;

    //                allocatedFeedsForThisPet++;

    //                allocationsOfThisFood++;
    //            }

    //            if (allocationsOfThisFood > 0)
    //            {
    //                var petFeed = new PetFoodFeed(petFoodPreference.Key.FullName, preferredFood.FullName, allocationsOfThisFood);

    //                basicPetFeeds.Add(petFeed);

    //                logger.LogInformation($"Pet {petFeed.PetFullName} will be fed {petFeed.FoodFullName} {petFeed.FeedQuantity} times.");
    //            }
    //        }
    //    }

    //    return basicPetFeeds;
    //}
}
