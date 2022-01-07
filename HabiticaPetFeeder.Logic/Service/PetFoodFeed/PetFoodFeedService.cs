using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Util;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Service.PetFoodFeed
{
    public class PetFoodFeedService : IPetFoodFeedService
    {
        private readonly ILogger<PetFoodFeedService> logger;
        private const int NonPreferredFoodFeedPoints = 2;
        private const int PreferredFoodFeedPoints = 5;

        public PetFoodFeedService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<PetFoodFeedService>();
        }

        public IEnumerable<Model.PetFoodFeed> GetPreferredFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods, Model.PetFoodPreferences petFoodPreferences)
        {
            return GetFoodFeedsWithPreference(pets, foods, petFoodPreferences);
        }

        public IEnumerable<Model.PetFoodFeed> GetFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods)
        {
            return GetFoodFeedsWithPreference(pets, foods, new EmptyPetPreferences());
        }

        /// <summary>
        /// Feeds pets according to their preferences.
        /// </summary>
        /// <param name="pets"></param>
        /// <param name="foods"></param>
        /// <param name="petFoodPreferences"></param>
        /// <returns></returns>
        private static IEnumerable<Model.PetFoodFeed> GetFoodFeedsWithPreference(IEnumerable<Pet> pets, IEnumerable<Food> foods, IPetFoodPreference petFoodPreferences)
        {
            var petFeeds = new HashSet<Model.PetFoodFeed>();

            var petsWithPreferences = petFoodPreferences.GetPetsWithPreferences();

            var petsWithPreferencesToFeed = pets
                .Where(x => x.FedPoints.Value < 50)
                .Where(x => petsWithPreferences.IsEmpty() || petsWithPreferences.Contains(x.FullName))
                .ToHashSet();

            foreach (var pet in petsWithPreferencesToFeed)
            {
                var petPreferredFoods = petFoodPreferences.GetPetPreferredFoodNames(pet);

                var foodsToFeed = foods
                    .Where(x => x.Quantity.Value > 0)
                    .Where(x => petPreferredFoods.IsEmpty() || petPreferredFoods.Contains(x.FullName))
                    .OrderByDescending(x => x.Quantity.Value)
                    .ToHashSet();

                foreach (var food in foodsToFeed)
                {
                    var allocationsOfThisFoodToThisPet = 0;

                    var fedPointsAdjustment = !pet.IsBasicPet || pet.Type == food.Type
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
                        var isPetSatisfied = pet.FedPoints.Value >= 50;

                        petFeeds.Add(new Model.PetFoodFeed(pet.FullName, food.FullName, allocationsOfThisFoodToThisPet, isPetSatisfied));
                    }
                }
            }

            return petFeeds;
        }
    }
}
