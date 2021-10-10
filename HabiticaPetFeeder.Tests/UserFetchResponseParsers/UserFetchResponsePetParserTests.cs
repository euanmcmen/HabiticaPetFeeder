using HabiticaPetFeeder.App;
using System;
using Xunit;

namespace HabiticaPetFeeder.Tests.UserFetchResponseParsers
{
    public class UserFetchResponsePetParserTests_Fixture : IDisposable
    {
        public UserFetchResponsePetParser PetParser { get; }

        public UserFetchResponsePetParserTests_Fixture()
        {
            PetParser = new UserFetchResponsePetParser();
        }

        public void Dispose()
        {
        }
    }

    public class UserFetchResponsePetParserTests : IClassFixture<UserFetchResponsePetParserTests_Fixture>
    {
        private readonly UserFetchResponsePetParserTests_Fixture fixture;

        public UserFetchResponsePetParserTests(UserFetchResponsePetParserTests_Fixture fixture)
        {
            this.fixture = fixture;
        }

        [Theory]
        [InlineData("LionCub-White", "7", "LionCub", "White", 7)]
        [InlineData("FlyingPig-Skeleton", "5", "FlyingPig", "Skeleton", 5)]
        public void Parse_ReturnsPetStructure(string inputName, string inputFedPoints, string outputName, string outputType, int outputFedPoints)
        {
            var result = fixture.PetParser.Parse(inputName, inputFedPoints);

            Assert.True(result.Name == outputName);
            Assert.True(result.Type == outputType);
            Assert.True(result.FedPoints == outputFedPoints);
        }
    }
}
