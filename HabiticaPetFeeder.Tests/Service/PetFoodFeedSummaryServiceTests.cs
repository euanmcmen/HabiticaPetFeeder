using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.PetFoodFeedSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service
{
    public class PetFoodFeedSummaryServiceTests_Fixture
    {
        public PetFoodFeedSummaryService PetFoodFeedSummaryService { get; private set; }

        public PetFoodFeedSummaryServiceTests_Fixture()
        {
            PetFoodFeedSummaryService = new PetFoodFeedSummaryService(TestHelpers.GetMockedLogFactoryForType<PetFoodFeedSummaryService>().Object);
        }
    }

    public class PetFoodFeedSummaryServiceTests_PetFoodFeedInput_Fixture
    {
        public List<PetFoodFeed> PetFoodFeeds { get; private set; }

        public PetFoodFeedSummaryServiceTests_PetFoodFeedInput_Fixture()
        {
            PetFoodFeeds = new List<PetFoodFeed>()
            {
                new PetFoodFeed("LionCub-White", "Milk", 6, true),
                new PetFoodFeed("Wolf-Base", "Meat", 5, false),
                new PetFoodFeed("Wolf-Base", "Cake_Base", 3, true),
                new PetFoodFeed("TigerCub-Base", "Meat", 1, false)
            };

            //Wolf is fed 5 meat but is not yet satisfied.
            //Assert.Contains(result, x => x.PetFullName == "Wolf-Base" && x.FoodFullName == "Meat" && x.FeedQuantity == 5 && !x.WillSatisfyPet);

            //Wolf is then fed 3 cake and is satisfied.
            //Assert.Contains(result, x => x.PetFullName == "Wolf-Base" && x.FoodFullName == "Cake_Base" && x.FeedQuantity == 3 && x.WillSatisfyPet);
        }
    }

    public class PetFoodFeedSummaryServiceTests : IClassFixture<PetFoodFeedSummaryServiceTests_Fixture>, IClassFixture<PetFoodFeedSummaryServiceTests_PetFoodFeedInput_Fixture>
    {
        private readonly PetFoodFeedSummaryServiceTests_Fixture fixture;
        private readonly PetFoodFeedSummaryServiceTests_PetFoodFeedInput_Fixture inputFixture;

        public PetFoodFeedSummaryServiceTests(PetFoodFeedSummaryServiceTests_Fixture fixture, PetFoodFeedSummaryServiceTests_PetFoodFeedInput_Fixture inputFixture)
        {
            this.fixture = fixture;
            this.inputFixture = inputFixture;
        }

        //GetNumberOfPetsFed counts unique number of Pet fed in list of PetFoodFeeds
        //

        [Fact]
        public void GetNumberOfPetsFed_returns_count_of_Pets()
        {
            var result = fixture.PetFoodFeedSummaryService.GetNumberOfPetsFed(inputFixture.PetFoodFeeds);
            Assert.Equal(3, result);
        }

        [Fact]
        public void GetNumberOfSatisfiedPets_returns_count_of_satisfied_Pets()
        {
            var result = fixture.PetFoodFeedSummaryService.GetNumberOfSatisfiedPets(inputFixture.PetFoodFeeds);
            Assert.Equal(2, result);
        }

        [Fact]
        public void GetNumberOfFoodsFed_returns_total_count_of_Foods()
        {
            //Milkx6 + Meatx5+1 + Cake_Basex3 = 15

            var result = fixture.PetFoodFeedSummaryService.GetNumberOfFoodsFed(inputFixture.PetFoodFeeds);
            Assert.Equal(15, result);
        }
    }
}
