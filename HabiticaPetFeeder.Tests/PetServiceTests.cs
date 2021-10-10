using HabiticaPetFeeder.App;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HabiticaPetFeeder.Tests
{
    public class PetServiceTests
    {
        [Fact]
        public void WhenPetServiceIsCalled_ReturnsPetStructures()
        {
            var testInput = new UserFetchResponseDataPets();

            var testOutput = new Dictionary<string, string>()
            {
                { "LionCub-White", "7" },
                { "Dragon-Skeleton", "5" },
                { "FlyingPig-Base", "5" }
            };

            var mockPropertyReflector = new Mock<IPropertyReflector>();
            mockPropertyReflector.Setup(x => x.GetPropertyNameValuePairs(testInput)).Returns(testOutput);

            var petService = new PetService(mockPropertyReflector.Object);

            var result = petService.ExtractPets(testInput);

            Assert.Equal(3, result.Count);

            Assert.True(result[0].Name == "LionCub");
            Assert.True(result[0].Type == "White");
            Assert.True(result[0].FedPoints == 7);
        }
    }
}
