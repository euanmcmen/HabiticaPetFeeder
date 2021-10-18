namespace HabiticaPetFeeder.Logic.UserResponseParser.Factory
{
    public interface IUserResponseParserFactory
    {
        IUserResponseParser<T> GetUserResponseParser<T>() where T : class;
    }
}