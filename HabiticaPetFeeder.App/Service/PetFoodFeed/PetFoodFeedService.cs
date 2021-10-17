using HabiticaPetFeeder.App.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.App
{
    public class PetFoodFeedService : IPetFoodFeedService
    {
        private readonly ILogger<PetFoodFeedService> logger;

        private const int NonPreferredFoodFeedPoints = 3;
        private const int PreferredFoodFeedPoints = 5;

        public PetFoodFeedService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<PetFoodFeedService>();
        }

        public List<PetFoodFeed> GetPreferredFoodFeeds(List<Pet> pets, List<Food> foods, PetFoodPreferences petFoodPreferences)
        {
            return GetFoodFeedsWithPreference(pets, foods, petFoodPreferences);
        }

        public List<PetFoodFeed> GetFoodFeeds(List<Pet> pets, List<Food> foods)
        {
            return GetFoodFeedsWithPreference(pets, foods, null);
        }

        private List<PetFoodFeed> GetFoodFeedsWithPreference(List<Pet> pets, List<Food> foods, PetFoodPreferences petFoodPreferences)
        {
            var petFeeds = new List<PetFoodFeed>();

            var petsToFeed = GetPetsToFeed(pets);

            foreach (var pet in petsToFeed)
            {
                var foodsToFeed = GetFoodsToFeed(foods);

                if (petFoodPreferences != null)
                {
                    var preferredFoodNames = petFoodPreferences.GetPetPreferredFoodNames(pet);

                    foodsToFeed = foodsToFeed
                        .Where(x => preferredFoodNames.Contains(x.FullName))
                        .ToHashSet();
                }

                foreach (var food in foodsToFeed)
                {
                    var allocationsOfThisFoodToThisPet = 0;

                    var fedPointsAdjustment = (!pet.IsBasicPet || pet.Type == food.Type)
                        ? PreferredFoodFeedPoints
                        : NonPreferredFoodFeedPoints;

                    while (food.Quantity.Value > 0 && pet.FedPoints.Value < 50)
                    {
                        //Allocate an instance of this food to this pet.
                        allocationsOfThisFoodToThisPet++;

                        //Ajust the pet and food quantities.
                        food.Quantity.Adjust(1);
                        pet.FedPoints.Adjust(fedPointsAdjustment);
                    }

                    if (allocationsOfThisFoodToThisPet > 0)
                    {
                        petFeeds.Add(new PetFoodFeed(pet.FullName, food.FullName, allocationsOfThisFoodToThisPet));
                    }
                }
            }

            return petFeeds;
        }

        private static HashSet<Pet> GetPetsToFeed(List<Pet> pets)
        {
            return pets
                .Where(x => x.FedPoints.Value < 50)
                .ToHashSet();
        }

        private static HashSet<Food> GetFoodsToFeed(List<Food> foods)
        {
            return foods
                .Where(x => x.Quantity.Value > 0)
                .Where(x => x.FullName != "Saddle")
                .OrderByDescending(x => x.Quantity.Value)
                .ToHashSet();
        }
    }
}
