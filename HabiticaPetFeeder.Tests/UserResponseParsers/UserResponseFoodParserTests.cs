using HabiticaPetFeeder.App;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace HabiticaPetFeeder.Tests.UserFetchResponseParsers
{
    public class UserResponseFoodParserTests_Fixture : IDisposable
    {
        public UserResponseFoodParser FoodParser { get; }

        public UserResponseFoodParserTests_Fixture()
        {
            FoodParser = new UserResponseFoodParser(GetMockedLogFactoryForType<UserResponseFoodParser>().Object);
        }

        private static Mock<ILoggerFactory> GetMockedLogFactoryForType<T>()
        {
            var mockLogger = new Mock<ILogger<T>>();
            var mockLoggerFactory = new Mock<ILoggerFactory>();
            mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(mockLogger.Object);

            return mockLoggerFactory;
        }

        public void Dispose()
        {
        }
    }

    public class UserResponseFoodParserTests : IClassFixture<UserResponseFoodParserTests_Fixture>
    {
        private readonly UserResponseFoodParserTests_Fixture fixture;

        public UserResponseFoodParserTests(UserResponseFoodParserTests_Fixture fixture)
        {
            this.fixture = fixture;
        }
        
        [Theory]
        [InlineData("Potatoe", "196", "Potatoe", "Desert", 196)]
        [InlineData("Cake_CottonCandyBlue", "4", "Cake", "CottonCandyBlue", 4)]
        [InlineData("CottonCandyBlue", "197", "CottonCandyBlue", "CottonCandyBlue", 197)]
        [InlineData("RottenMeat", "175", "RottenMeat", "Zombie", 175)]
        [InlineData("Saddle", "10", "Saddle", "NONE", 10)]
        public void Parse_ReturnsFoodStructure(string inputName, string inputQuantity, string outputName, string outputType, int outputQuantity)
        {
            var result = fixture.FoodParser.Parse(inputName, inputQuantity);

            Assert.True(result.Name == outputName);
            Assert.True(result.FullName == inputName);
            Assert.True(result.Type == outputType);
            Assert.True(result.Quantity == outputQuantity);
        }
    }
}
