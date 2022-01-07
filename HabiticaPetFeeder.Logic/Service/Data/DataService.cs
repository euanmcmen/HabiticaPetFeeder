using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ContentResponse;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Service.Data
{
    public class DataService : IDataService
    {
        private readonly ILogger<DataService> logger;

        public DataService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<DataService>();
        }

        public IEnumerable<Pet> GetPets(UserResponse userResponse, ContentResponse contentResponse)
        {
            var basicPetNames = contentResponse.data.pets.Select(x => x.Key).ToHashSet();

            var feedablePetNames = basicPetNames.Union(contentResponse.data.premiumPets.Select(x => x.Key)).ToHashSet();

            var mountNames = userResponse.data.items.mounts.Select(x => x.Key).ToHashSet();

            return userResponse.data.items.pets
                .Where(x => feedablePetNames.Contains(x.Key))
                .Where(x => !mountNames.Contains(x.Key))
                .Where(x => x.Value > 0)
                .Select(x =>
                {
                    return new Pet(x.Key, x.Key.Split("-")[1], new IncreasingQuantity(x.Value), basicPetNames.Contains(x.Key));
                })
                .ToHashSet();
        }

        public IEnumerable<Food> GetFoods(UserResponse userResponse, ContentResponse contentResponse)
        {
            var foodNameTypePairs = contentResponse.data.food.ToDictionary(x => x.Key, x => x.Value.target);

            return userResponse.data.items.food
                .Where(x => x.Key != "Saddle")
                .Select(x =>
                {
                    return new Food(x.Key, foodNameTypePairs[x.Key], new DecreasingQuantity(x.Value));
                })
                .ToHashSet();
        }
    }
}
