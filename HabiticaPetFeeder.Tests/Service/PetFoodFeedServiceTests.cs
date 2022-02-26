using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace HabiticaPetFeeder.Tests.Service;

public class PetFoodFeedServiceTests_Fixture
{
    public PetFoodFeedService PetFoodFeedService { get; private set; }

    public List<IPetFoodPreferenceStrategy> PetFoodPreferenceStrategies { get; private set; }

    public PetFoodFeedServiceTests_Fixture()
    {
        PetFoodPreferenceStrategies = new List<IPetFoodPreferenceStrategy>();

        //TODO - Mock a stragegy.

        PetFoodFeedService = new PetFoodFeedService(TestHelpers.GetMockedLogFactoryForType<PetFoodFeedService>().Object, PetFoodPreferenceStrategies);
    }
}

//TODO - Write a test class for the method.  I don't need to use the whole ordering thing anymore now that ordering is part of the test.










///////////////////////////////////////////////////////

//public class PreferredFeedsBeforeNonPreferredFeedsOrderer : ITestCaseOrderer
//{
//    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
//            where TTestCase : ITestCase
//    {
//        var result = new List<TTestCase>
//            {
//                testCases.Single(x => x.TestMethod.Method.Name == "GetPreferredFoodFeeds_GetsBasicPetFeedsWithPreferences"),
//                testCases.Single(x => x.TestMethod.Method.Name == "GetFoodFeeds_GetsNonBasicPetFeed")
//            };

//        return result;
//    }
//}

//[TestCaseOrderer("HabiticaPetFeeder.Tests.Service.PreferredFeedsBeforeNonPreferredFeedsOrderer", "HabiticaPetFeeder.Tests")]
//public class OrderedPetFoodFeedServiceTests : IClassFixture<PetFoodFeedServiceTests_Fixture>, IClassFixture<TestData_Fixture>
//{
//    private readonly PetFoodFeedServiceTests_Fixture fixture;
//    private readonly TestData_Fixture testData;

//    public OrderedPetFoodFeedServiceTests(PetFoodFeedServiceTests_Fixture fixture, TestData_Fixture testData)
//    {
//        this.fixture = fixture;
//        this.testData = testData;
//    }

//    [Fact]
//    public void GetPreferredFoodFeeds_GetsBasicPetFeedsWithPreferences()
//    {
//        var result = fixture.PetFoodFeedService.GetPreferredFoodFeeds(testData.Pets, testData.Foods, testData.BasicPetFoodPreferences);

//        //Lion is fed 6 milk and is satisfied.
//        Assert.Contains(result, x => x.PetFullName == "LionCub-White" && x.FoodFullName == "Milk" && x.FeedQuantity == 6 && x.WillSatisfyPet);

//        //Wolf is fed 5 meat but is not yet satisfied.
//        Assert.Contains(result, x => x.PetFullName == "Wolf-Base" && x.FoodFullName == "Meat" && x.FeedQuantity == 5 && !x.WillSatisfyPet);

//        //Wolf is then fed 3 cake and is satisfied.
//        Assert.Contains(result, x => x.PetFullName == "Wolf-Base" && x.FoodFullName == "Cake_Base" && x.FeedQuantity == 3 && x.WillSatisfyPet);

//        //Tiger should not be fed due to basic food preferences.
//        Assert.DoesNotContain(result, x => x.PetFullName == "TigerCub-RoyalPurple");
//    }

//    [Fact]
//    public void GetFoodFeeds_GetsNonBasicPetFeed()
//    {
//        var result = fixture.PetFoodFeedService.GetFoodFeeds(testData.Pets, testData.Foods);

//        //Tiger should be included here and should be fully fed something...
//        Assert.Single(result, x => x.PetFullName == "TigerCub-RoyalPurple" && x.FeedQuantity == 9 && x.WillSatisfyPet);

//        //Lion and Wolf should not be contained here.
//        Assert.DoesNotContain(result, x => x.PetFullName == "LionCub-White");
//        Assert.DoesNotContain(result, x => x.PetFullName == "Wolf-Base");
//    }
//}
