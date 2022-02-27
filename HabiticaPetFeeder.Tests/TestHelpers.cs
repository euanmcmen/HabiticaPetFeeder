using FakeItEasy;
using Microsoft.Extensions.Logging;
using Moq;

namespace HabiticaPetFeeder.Tests
{
    public static class TestHelpers
    {
        //public static Mock<ILoggerFactory> GetMockedLogFactoryForType<T>()
        //{
        //    var mockLogger = new Mock<ILogger<T>>();
        //    var mockLoggerFactory = new Mock<ILoggerFactory>();
        //    mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(mockLogger.Object);

        //    return mockLoggerFactory;
        //}

        public static ILoggerFactory GetFakeLoggerFactoryForType<T>()
        {
            var logger = A.Fake<ILogger<T>>();
            var loggerFactory = A.Fake<ILoggerFactory>();

            A.CallTo(() => loggerFactory.CreateLogger(A.Dummy<string>())).Returns(logger);

            return loggerFactory;
        }
    }
}
