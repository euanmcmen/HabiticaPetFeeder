using HabiticaPetFeeder.Logic.UserResponseParser;
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
        [InlineData("LionCub-White", "7", "White", 7, true)]
        [InlineData("FlyingPig-Skeleton", "5", "Skeleton", 5, true)]
        [InlineData("LionCub-RoyalPurple", "5", "RoyalPurple", 5, false)]
        [InlineData("Orca-Base", "5", "Base", 5, false)]
        public void Parse_ReturnsPetStructure(string inputName, string inputFedPoints, string outputType, int outputFedPoints, bool outputIsBasicPet)
        {
            var result = fixture.PetParser.Parse(inputName, inputFedPoints);

            Assert.True(result.FullName == inputName);
            Assert.True(result.Type == outputType);
            Assert.True(result.FedPoints.Value == outputFedPoints);
            Assert.True(result.IsBasicPet == outputIsBasicPet);
        }
    }
}
