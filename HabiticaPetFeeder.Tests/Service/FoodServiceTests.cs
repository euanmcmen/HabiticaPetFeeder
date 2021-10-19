using HabiticaPetFeeder.Logic.Service;
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
            FoodService = new FoodService(TestHelpers.GetMockedLogFactoryForType<FoodService>().Object);
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
