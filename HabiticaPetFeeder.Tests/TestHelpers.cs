using FakeItEasy;
using Microsoft.Extensions.Logging;

namespace HabiticaPetFeeder.Tests
{
    public static class TestHelpers
    {
        public static ILoggerFactory GetFakeLoggerFactoryForType<T>()
        {
            var logger = A.Fake<ILogger<T>>();
            var loggerFactory = A.Fake<ILoggerFactory>();

            A.CallTo(() => loggerFactory.CreateLogger(A.Dummy<string>())).Returns(logger);

            return loggerFactory;
        }
    }
}
