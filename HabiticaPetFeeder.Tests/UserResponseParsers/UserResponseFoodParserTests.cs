using HabiticaPetFeeder.Logic.UserResponseParser;
using System;
using Xunit;

namespace HabiticaPetFeeder.Tests.UserFetchResponseParsers
{
    public class UserResponseFoodParserTests_Fixture : IDisposable
    {
        public UserResponseFoodParser FoodParser { get; }

        public UserResponseFoodParserTests_Fixture()
        {
            FoodParser = new UserResponseFoodParser(TestHelpers.GetMockedLogFactoryForType<UserResponseFoodParser>().Object);
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
        [InlineData("Potatoe", "196", "Desert", 196)]
        [InlineData("Cake_CottonCandyBlue", "4", "CottonCandyBlue", 4)]
        [InlineData("CottonCandyBlue", "197", "CottonCandyBlue", 197)]
        [InlineData("RottenMeat", "175", "Zombie", 175)]
        public void Parse_ReturnsFoodStructure(string inputName, string inputQuantity, string outputType, int outputQuantity)
        {
            var result = fixture.FoodParser.Parse(inputName, inputQuantity);

            Assert.True(result.FullName == inputName);
            Assert.True(result.Type == outputType);
            Assert.True(result.Quantity.Value == outputQuantity);
        }
    }
}
