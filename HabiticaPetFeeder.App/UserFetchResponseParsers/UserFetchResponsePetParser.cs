using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public class UserFetchResponsePetParser : IUserFetchResponseParser<Pet>
    {
        public Pet Parse(string propertyName, string propertyValue)
        {
            var petParts = propertyName.Split("-");

            return new Pet(petParts[0], petParts[1], int.Parse(propertyValue));
        }
    }
}
