namespace HabiticaPetFeeder.Logic.UserResponseParser
{
    public interface IUserResponseParser<T> where T: class
    {
        public T Parse(string propertyName, string propertyValue);
    }
}
