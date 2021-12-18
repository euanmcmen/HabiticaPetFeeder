﻿using HabiticaPetFeeder.Logic.Model;
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

        [Fact]
        public void GetNumberOfPetsFed_ReturnsCountOfPets()
        {
            var result = fixture.PetFoodFeedSummaryService.GetNumberOfPetsFed(inputFixture.PetFoodFeeds);
            Assert.Equal(3, result);
        }

        [Fact]
        public void GetNumberOfSatisfiedPets_ReturnsCountOfSatisfiedPets()
        {
            var result = fixture.PetFoodFeedSummaryService.GetNumberOfSatisfiedPets(inputFixture.PetFoodFeeds);
            Assert.Equal(2, result);
        }

        [Fact]
        public void GetNumberOfFoodsFed_ReturnsTotalCountOfFoods()
        {
            //Milkx6 + Meatx5+1 + Cake_Basex3 = 15

            var result = fixture.PetFoodFeedSummaryService.GetNumberOfFoodsFed(inputFixture.PetFoodFeeds);
            Assert.Equal(15, result);
        }
    }
}
