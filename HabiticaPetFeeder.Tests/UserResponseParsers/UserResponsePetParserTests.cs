using HabiticaPetFeeder.App;
using System;
using Xunit;

namespace HabiticaPetFeeder.Tests.UserFetchResponseParsers
{
    public class UserResponsePetParserTests_Fixture : IDisposable
    {
        public UserResponsePetParser PetParser { get; }

        public UserResponsePetParserTests_Fixture()
        {
            PetParser = new UserResponsePetParser(TestHelpers.GetMockedLogFactoryForType<UserResponsePetParser>().Object);
        }

        public void Dispose()
        {
        }
    }

    public class UserResponsePetParserTests : IClassFixture<UserResponsePetParserTests_Fixture>
    {
        private readonly UserResponsePetParserTests_Fixture fixture;

        public UserResponsePetParserTests(UserResponsePetParserTests_Fixture fixture)
        {
            this.fixture = fixture;
        }

        [Theory]
        [InlineData("LionCub-White", "7", "LionCub", "White", 7)]
        [InlineData("FlyingPig-Skeleton", "5", "FlyingPig", "Skeleton", 5)]
        public void Parse_ReturnsPetStructure(string inputName, string inputFedPoints, string outputName, string outputType, int outputFedPoints)
        {
            var result = fixture.PetParser.Parse(inputName, inputFedPoints);

            Assert.True(result.FullName == inputName);
            Assert.True(result.Name == outputName);
            Assert.True(result.Type == outputType);
            Assert.True(result.FedPoints.Value == outputFedPoints);
        }
    }
}
