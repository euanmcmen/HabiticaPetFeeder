using HabiticaPetFeeder.App;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HabiticaPetFeeder.Tests.UserFetchResponseParsers
{
    public class UserFetchResponseFoodParserTests_Fixture : IDisposable
    {
        public UserFetchResponseFoodParser FoodParser { get; }

        public UserFetchResponseFoodParserTests_Fixture()
        {
            var commonFoodService = new CommonFoodReferenceService(new CommonFoodReferenceData());

            FoodParser = new UserFetchResponseFoodParser(commonFoodService);
        }

        public void Dispose()
        {
        }
    }

    public class UserFetchResponseFoodParserTests : IClassFixture<UserFetchResponseFoodParserTests_Fixture>
    {
        private readonly UserFetchResponseFoodParserTests_Fixture fixture;

        public UserFetchResponseFoodParserTests(UserFetchResponseFoodParserTests_Fixture fixture)
        {
            this.fixture = fixture;
        }
        
        [Theory]
        [InlineData("Potatoe", "196", "Potatoe", "Desert", 196)]
        [InlineData("Cake_CottonCandyBlue", "4", "Cake", "CottonCandyBlue", 4)]
        public void Parse_ReturnsFoodStructure(string inputName, string inputQuantity, string outputName, string outputType, int outputQuantity)
        {
            var result = fixture.FoodParser.Parse(inputName, inputQuantity);

            Assert.True(result.Name == outputName);
            Assert.True(result.Type == outputType);
            Assert.True(result.Quantity == outputQuantity);
        }
    }
}
