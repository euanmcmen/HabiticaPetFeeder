using HabiticaPetFeeder.Logic.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace HabiticaPetFeeder.Tests.Service
{
    public class PetFoodFeedServiceTests_Fixture
    {
        public PetFoodFeedService PetFoodFeedService { get; private set; }

        public PetFoodFeedServiceTests_Fixture()
        {
            PetFoodFeedService = new PetFoodFeedService(TestHelpers.GetMockedLogFactoryForType<PetFoodFeedService>().Object);
        }
    }

    public class PreferredFeedsBeforeNonPreferredFeedsOrderer : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
                where TTestCase : ITestCase
        {
            var result = new List<TTestCase>
            {
                testCases.Single(x => x.TestMethod.Method.Name == "GetPreferredFoodFeeds_GetsBasicPetFeedsWithPreferences"),
                testCases.Single(x => x.TestMethod.Method.Name == "GetFoodFeeds_GetsNonBasicPetFeed")
            };

            return result;
        }
    }

    [TestCaseOrderer("HabiticaPetFeeder.Tests.Service.PreferredFeedsBeforeNonPreferredFeedsOrderer", "HabiticaPetFeeder.Tests")]
    public class OrderedPetFoodFeedServiceTests : IClassFixture<PetFoodFeedServiceTests_Fixture>, IClassFixture<TestData_Fixture>
    {
        private readonly PetFoodFeedServiceTests_Fixture fixture;
        private readonly TestData_Fixture testData;

        public OrderedPetFoodFeedServiceTests(PetFoodFeedServiceTests_Fixture fixture, TestData_Fixture testData)
        {
            this.fixture = fixture;
            this.testData = testData;
        }

        [Fact]
        public void GetPreferredFoodFeeds_GetsBasicPetFeedsWithPreferences()
        {
            var result = fixture.PetFoodFeedService.GetPreferredFoodFeeds(testData.Pets, testData.Foods, testData.BasicPetFoodPreferences);

            //Lion is fed 6 milk.
            Assert.Contains(result, x => x.PetFullName == "LionCub-White" && x.FoodFullName == "Milk" && x.FeedQuantity == 6);
            
            //Wolf is fed 5 meat.
            Assert.Contains(result, x => x.PetFullName == "Wolf-Base" && x.FoodFullName == "Meat" && x.FeedQuantity == 5);

            //Wolf is then fed 3 cake.
            Assert.Contains(result, x => x.PetFullName == "Wolf-Base" && x.FoodFullName == "Cake_Base" && x.FeedQuantity == 3);

            //Tiger should not be fed due to basic food preferences.
            Assert.DoesNotContain(result, x => x.PetFullName == "TigerCub-RoyalPurple");
        }

        [Fact]
        public void GetFoodFeeds_GetsNonBasicPetFeed()
        {
            var result = fixture.PetFoodFeedService.GetFoodFeeds(testData.Pets, testData.Foods);

            //Tiger should be included here and should be fully fed something...
            Assert.Single(result, x => x.PetFullName == "TigerCub-RoyalPurple" && x.FeedQuantity == 9);

            //Lion and Wolf should not be contained here.
            Assert.DoesNotContain(result, x => x.PetFullName == "LionCub-White");
            Assert.DoesNotContain(result, x => x.PetFullName == "Wolf-Base");
        }
    }
}
