namespace HabiticaPetFeeder.App
{
    public interface IUserResponseParserFactory
    {
        IUserResponseParser<T> GetUserResponseParser<T>() where T : class;
    }
}