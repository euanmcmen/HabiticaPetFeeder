using HabiticaPetFeeder.Logic.ContentResponseParser;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ContentResponse;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Service.Data
{
    public class DataService : IDataService
    {
        private readonly IContentResponseElementParser contentResponseElementParser;

        public DataService(IContentResponseElementParser contentResponseElementParser)
        {
            this.contentResponseElementParser = contentResponseElementParser;
        }

        public IEnumerable<Pet> GetPets(UserResponse userResponse, ContentResponse contentResponse)
        {
            var basicPets = contentResponseElementParser.GetBasicPetNames(contentResponse);
            var feedablePets = contentResponseElementParser.GetFeedablePetNames(contentResponse);

            return userResponse.data.items.pets
                .Where(x => feedablePets.Contains(x.Key))
                .Where(x => x.Value > 0)
                .Select(x =>
                {
                    return new Pet(x.Key, x.Key.Split("-")[1], new IncreasingQuantity(x.Value), basicPets.Contains(x.Key));
                })
                .ToHashSet();
        }

        public IEnumerable<Food> GetFoods(UserResponse userResponse, ContentResponse contentResponse)
        {
            var foodNameTypePairs = contentResponseElementParser.GetFoodNameTypePairs(contentResponse);

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
