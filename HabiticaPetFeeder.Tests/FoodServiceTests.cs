using HabiticaPetFeeder.App;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace HabiticaPetFeeder.Tests
{
    public class FoodServiceTests
    {
        [Fact]
        public void WhenFoodServiceIsCalled_ReturnsFoodStructures()
        {
            var testInput = new UserFetchResponseDataFoods();

            var testOutput = new Dictionary<string, string>()
            {
                { "Potatoe", "196" },
                { "Cake_CottonCandyBlue", "4" },
                { "Pie_Base", "1" }
            };

            var mockPropertyReflector = new Mock<IPropertyReflector>();
            mockPropertyReflector.Setup(x => x.GetPropertyNameValuePairs(testInput)).Returns(testOutput);

            var commonFoodReferenceData = new CommonFoodReferenceData();
            var commonFoodReferenceDataService = new CommonFoodReferenceService(commonFoodReferenceData);

            var foodService = new FoodService(commonFoodReferenceDataService, mockPropertyReflector.Object);

            var result = foodService.ExtractFoods(testInput);

            Assert.Equal(3, result.Count);

            Assert.True(result[0].Name == "Potatoe");
            Assert.True(result[0].Type == "Desert");
            Assert.True(result[0].Quantity == 196);

            Assert.True(result[1].Name == "Cake");
            Assert.True(result[1].Type == "CottonCandyBlue");
            Assert.True(result[1].Quantity == 4);

            Assert.True(result[2].Name == "Pie");
            Assert.True(result[2].Type == "Base");
            Assert.True(result[2].Quantity == 1);
        }
    }
}
