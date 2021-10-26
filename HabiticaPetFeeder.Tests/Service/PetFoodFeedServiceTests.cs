using HabiticaPetFeeder.Logic.Service;
using Moq;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service
{
    public class PetFoodFeedServiceTests_Fixture
    {
        public PetFoodFeedService PetFoodFeedService { get; private set; }

        public PetFoodFeedServiceTests_Fixture()
        {
            var petService = new Mock<IPetService>();
            var foodService = new Mock<IFoodService>();

            PetFoodFeedService = new PetFoodFeedService(TestHelpers.GetMockedLogFactoryForType<PetFoodFeedService>().Object, petService.Object, foodService.Object);
        }
    }

    public class PetFoodFeedServiceTests : IClassFixture<PetFoodFeedServiceTests_Fixture>
    {
        private readonly PetFoodFeedServiceTests_Fixture fixture;

        public PetFoodFeedServiceTests(PetFoodFeedServiceTests_Fixture fixture)
        {
            this.fixture = fixture;
        }


        [Fact]
        public void GetPreferredFoodFeeds_GetsBasicPetFeedsWithPreferences()
        {

        }
    }
}
