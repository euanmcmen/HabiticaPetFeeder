﻿using FakeItEasy;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.PetFoodPreferenceStrategy.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service;

//Reminder: XUnit ClassFixtures hold class-wide objects and are not reset per test.
//Therefore calls to A.CallTo... Fake things will not be reset per execution.
//Better to use test-wide objects, and reserve class initialization where it makes sense to do so specifically.
//i.e. population of a list of pet and food feeds which will be accessed by all tests.

public class PetFoodFeedServiceTests
{
    private readonly PetFoodFeedService petFoodFeedService;
    private readonly List<IPetFoodPreferenceStrategy> petFoodPreferenceStrategies;

    public PetFoodFeedServiceTests()
    {
        petFoodPreferenceStrategies = new List<IPetFoodPreferenceStrategy>();

        petFoodFeedService = new PetFoodFeedService(TestHelpers.GetFakeLoggerFactoryForType<PetFoodFeedService>(), petFoodPreferenceStrategies);
    }

    [Fact]
    public void GetPetFoodFeedsWithConfiguredPreferences_ShouldOrderStrategiesByPriorityAscending()
    {
        // Arrange
        var pets = new List<Pet>();
        var foods = new List<Food>();

        var strategyA = A.Fake<IPetFoodPreferenceStrategy>();
        A.CallTo(() => strategyA.Priority).Returns(10);
        A.CallTo(() => strategyA.GetPreferences(pets, foods)).Returns(new Dictionary<string, HashSet<string>>());

        var strategyB = A.Fake<IPetFoodPreferenceStrategy>();
        A.CallTo(() => strategyB.Priority).Returns(5);
        A.CallTo(() => strategyB.GetPreferences(pets, foods)).Returns(new Dictionary<string, HashSet<string>>());

        petFoodPreferenceStrategies.Add(strategyA);
        petFoodPreferenceStrategies.Add(strategyB);

        // Act
        petFoodFeedService.GetPetFoodFeedsWithConfiguredPreferences(pets, foods);

        // Assert
        A.CallTo(() => strategyB.GetPreferences(pets, foods)).MustHaveHappened()
            .Then(A.CallTo(() => strategyA.GetPreferences(pets, foods)).MustHaveHappened());
    }
}



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
