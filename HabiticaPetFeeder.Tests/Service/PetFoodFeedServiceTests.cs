using FakeItEasy;
using FluentAssertions;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.PetFoodPreferenceStrategy.Abstraction;
using HabiticaPetFeeder.Tests.DataFixtures;
using System.Collections.Generic;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service;

//Reminder: XUnit ClassFixtures hold class-wide objects and are not reset per test.
//Therefore calls to A.CallTo... Fake things will not be reset per execution.
//Better to use test-wide objects, and reserve class initialization where it makes sense to do so specifically.
//i.e. population of a list of pet and food feeds which will be accessed by all tests.

public class PetFoodFeedServiceTests : IClassFixture<PetFoodDataFixture>
{
    private readonly PetFoodFeedService petFoodFeedService;
    private readonly List<IPetFoodPreferenceStrategy> petFoodPreferenceStrategies;

    private readonly PetFoodDataFixture petFoodDataFixture;

    public PetFoodFeedServiceTests(PetFoodDataFixture petFoodDataFixture)
    {
        this.petFoodDataFixture = petFoodDataFixture;

        petFoodPreferenceStrategies = new List<IPetFoodPreferenceStrategy>();

        petFoodFeedService = new PetFoodFeedService(TestHelpers.GetFakeLoggerFactoryForType<PetFoodFeedService>(), petFoodPreferenceStrategies);
    }

    [Fact]
    public void GetPetFoodFeedsWithConfiguredPreferences_ShouldOrderStrategiesByPriorityAscending()
    {
        // Arrange
        var pets = A.Dummy<IEnumerable<Pet>>();
        var foods = A.Dummy<IEnumerable<Food>>();

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

    [Fact]
    public void GetPetFoodFeedsWithConfiguredPreferences_ShouldReturnExpectedPetFoodFeeds()
    {
        // Arrange
        var basicPreferencesFakeStrategy = A.Fake<IPetFoodPreferenceStrategy>();
        A.CallTo(() => basicPreferencesFakeStrategy.Priority).Returns(0);
        A.CallTo(() => basicPreferencesFakeStrategy.GetPreferences(petFoodDataFixture.Pets, petFoodDataFixture.Foods)).Returns(petFoodDataFixture.BasicPetFoodPreferences);

        var blankFakeStrategy = A.Fake<IPetFoodPreferenceStrategy>();
        A.CallTo(() => blankFakeStrategy.Priority).Returns(99);
        A.CallTo(() => blankFakeStrategy.GetPreferences(petFoodDataFixture.Pets, petFoodDataFixture.Foods)).Returns(new Dictionary<string, HashSet<string>>());

        petFoodPreferenceStrategies.Add(basicPreferencesFakeStrategy);
        petFoodPreferenceStrategies.Add(blankFakeStrategy);

        // Act
        var result = petFoodFeedService.GetPetFoodFeedsWithConfiguredPreferences(petFoodDataFixture.Pets, petFoodDataFixture.Foods);

        // Assert

        //Lion is fed 6 milk and is satisfied.
        result.Should().Contain(x => x.PetFullName == "LionCub-White" && x.FoodFullName == "Milk" && x.FeedQuantity == 6 && x.WillSatisfyPet);

        //Wolf is fed 5 meat but is not yet satisfied.
        result.Should().Contain(x => x.PetFullName == "Wolf-Base" && x.FoodFullName == "Meat" && x.FeedQuantity == 5 && !x.WillSatisfyPet);

        //Wolf is then fed 3 cake and is satisfied.
        result.Should().Contain(x => x.PetFullName == "Wolf-Base" && x.FoodFullName == "Cake_Base" && x.FeedQuantity == 3 && x.WillSatisfyPet);

        //Tiger should be included here and should be fully fed something...
        result.Should().Contain(x => x.PetFullName == "TigerCub-RoyalPurple" && x.FeedQuantity == 9 && x.WillSatisfyPet);
    }
}