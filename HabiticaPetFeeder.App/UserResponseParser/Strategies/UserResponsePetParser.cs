namespace HabiticaPetFeeder.App
{
    public class UserResponsePetParser : IUserResponseParser<Pet>
    {
        public Pet Parse(string propertyName, string propertyValue)
        {
            var petParts = propertyName.Split("-");

            return new Pet(propertyName, petParts[0], petParts[1], int.Parse(propertyValue));
        }
    }
}
