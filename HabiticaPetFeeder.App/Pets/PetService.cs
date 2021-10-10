using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.App
{
    public class PetService
    {
        private readonly IPropertyReflector propertyReflector;

        public PetService(IPropertyReflector propertyReflector)
        {
            this.propertyReflector = propertyReflector;
        }

        public List<Pet> ExtractPets(UserFetchResponseDataPets userPets)
        {
            var userPetPropertyInfo = propertyReflector.GetPropertyNameValuePairs(userPets);

            return userPetPropertyInfo.Select(ParsePetFromPropertyInfo).ToList();
        }

        private Pet ParsePetFromPropertyInfo(KeyValuePair<string, string> propertyInfo)
        {
            var petParts = propertyInfo.Key.Split("-");

            return new Pet(petParts[0], petParts[1], int.Parse(propertyInfo.Value));
        }
    }
}
