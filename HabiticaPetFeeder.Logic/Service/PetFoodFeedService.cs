using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using HabiticaPetFeeder.Logic.Service.PetFoodPreferenceStrategy.Interfaces;
using HabiticaPetFeeder.Logic.Util;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Service
{
    public class PetFoodFeedService : IPetFoodFeedService
    {
        private readonly ILogger<PetFoodFeedService> logger;
        private readonly IEnumerable<IPetFoodPreferenceStrategy> petFoodPreferenceStrategies;
        private const int NonPreferredFoodFeedPoints = 2;
        private const int PreferredFoodFeedPoints = 5;

        public PetFoodFeedService(ILoggerFactory loggerFactory, IEnumerable<IPetFoodPreferenceStrategy> petFoodPreferenceStrategies)
        {
            logger = loggerFactory.CreateLogger<PetFoodFeedService>();
            this.petFoodPreferenceStrategies = petFoodPreferenceStrategies;
        }

        public List<PetFoodFeed> GetPetFoodFeedsWithConfiguredPreferences(IEnumerable<Pet> pets, IEnumerable<Food> foods)
        {
            var petFeeds = new List<Model.PetFoodFeed>();

            var strategies = petFoodPreferenceStrategies
                .OrderBy(x => x.Priority)
                .ToList();

            foreach (var currentStrategy in strategies)
            {
                var preferenceResult = GetFoodFeedsWithPreference(pets, foods, currentStrategy);
                petFeeds.AddRange(preferenceResult);
            }

            return petFeeds;
        }

        //public IEnumerable<Model.PetFoodFeed> GetPreferredFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods, IPetFoodPreferenceStrategy preferenceStrategy)
        //{
        //    return GetFoodFeedsWithPreference(pets, foods, preferenceStrategy);
        //}

        //public IEnumerable<Model.PetFoodFeed> GetFoodFeeds(IEnumerable<Pet> pets, IEnumerable<Food> foods)
        //{
        //    return GetFoodFeedsWithPreference(pets, foods, null);
        //}

        private static IEnumerable<Model.PetFoodFeed> GetFoodFeedsWithPreference(IEnumerable<Pet> pets, IEnumerable<Food> foods, IPetFoodPreferenceStrategy petFoodPreferenceStrategy)
        {
            var petFeeds = new List<Model.PetFoodFeed>();

            var preferences = petFoodPreferenceStrategy.GetPreferences(pets, foods);

            foreach (var pet in GetPetsToFeed(pets, preferences))
            {
                foreach (var food in GetFoodsToFeedPet(foods, pet, preferences))
                {
                    var allocationsOfThisFoodToThisPet = 0;

                    int fedPointsAdjustment = CalculateFedPointAdjustment(pet, food);

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

        private static int CalculateFedPointAdjustment(Pet pet, Food food)
        {
            return !pet.IsBasicPet || pet.Type == food.Type
                ? PreferredFoodFeedPoints
                : NonPreferredFoodFeedPoints;
        }

        private static HashSet<Food> GetFoodsToFeedPet(IEnumerable<Food> foods, Pet pet, Dictionary<string, HashSet<string>> preferences)
        {
            var petPreferredFoods = preferences.GetValueOrDefault(pet.FullName);

            var foodsToFeed = foods
                .Where(x => x.Quantity.Value > 0)
                .Where(x => petPreferredFoods == null || petPreferredFoods.Contains(x.FullName))
                .OrderByDescending(x => x.Quantity.Value)
                .ToHashSet();

            return foodsToFeed;
        }

        private static HashSet<Pet> GetPetsToFeed(IEnumerable<Pet> pets, Dictionary<string, HashSet<string>> preferences)
        {
            var petsWithPreferences = preferences.Keys.ToHashSet();

            var petsWithPreferencesToFeed = pets
                .Where(x => x.FedPoints.Value < 50)
                .Where(x => petsWithPreferences.IsEmpty() || petsWithPreferences.Contains(x.FullName))
                .ToHashSet();

            return petsWithPreferencesToFeed;
        }
    }
}
