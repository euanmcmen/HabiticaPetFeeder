using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.UserResponseParser;
using Moq;
using System;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service
{
    public class FoodServiceTests_Fixture : IDisposable
    {
        public FoodService FoodService { get; }

        public FoodServiceTests_Fixture()
        {
            var userResponseElementParser = new Mock<IUserResponseElementParser>();

            FoodService = new FoodService(TestHelpers.GetMockedLogFactoryForType<FoodService>().Object, userResponseElementParser.Object);
        }

        public void Dispose()
        {
        }
    }

    class FoodServiceTests : IClassFixture<FoodServiceTests_Fixture>
    {
        private readonly FoodServiceTests_Fixture fixture;

        public FoodServiceTests(FoodServiceTests_Fixture fixture)
        {
            this.fixture = fixture;
        }
    }
}
