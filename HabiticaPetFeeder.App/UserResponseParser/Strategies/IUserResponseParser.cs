namespace HabiticaPetFeeder.App
{
    public interface IUserResponseParser<T> where T: class
    {
        public T Parse(string propertyName, string propertyValue);
    }
}
