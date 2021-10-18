﻿using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.UserResponseParser;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service
{
    public class PetServiceTests_Fixture
    {
        public Mock<IUserResponseElementParser> MockUserResponseElementParser { get; }

        public PetService PetService { get; }

        public PetServiceTests_Fixture()
        {
            MockUserResponseElementParser = new Mock<IUserResponseElementParser>();

            PetService = new PetService(TestHelpers.GetMockedLogFactoryForType<PetService>().Object, MockUserResponseElementParser.Object);
        }
    }

    public class PetServiceTests : IClassFixture<PetServiceTests_Fixture>, IDisposable
    {
        private readonly PetServiceTests_Fixture fixture;

        public PetServiceTests(PetServiceTests_Fixture fixture)
        {
            this.fixture = fixture;
        }

        public void Dispose()
        {
            fixture.MockUserResponseElementParser.Reset();
        }

        [Fact]
        public void GetUserPets_ReturnsPets()
        {
            var inputs = new Dictionary<string, string>();
            inputs.Add("LionCub-White", "20");
            inputs.Add("Wolf-Base", "10");
            inputs.Add("Dragon-RoyalPurple", "-1");
            inputs.Add("TigerCub-RoyalPurple", "5");
            inputs.Add("Orca-Base", "5");

            var pet1 = new Pet("LionCub-White", "White", new IncreasingQuantity(20), true);
            var pet2 = new Pet("Wolf-Base", "Base", new IncreasingQuantity(10), true);
            var pet3 = new Pet("Dragon-RoyalPurple", "RoyalPurple", new IncreasingQuantity(-1), false);
            var pet4 = new Pet("TigerCub-RoyalPurple", "RoyalPurple", new IncreasingQuantity(5), false);
            var pet5 = new Pet("Orca-Base", "Base", new IncreasingQuantity(5), false);

            var parserOutputs = new List<Pet>();
            parserOutputs.Add(pet1);
            parserOutputs.Add(pet2);
            parserOutputs.Add(pet3);
            parserOutputs.Add(pet4);
            parserOutputs.Add(pet5);

            var expectedOutputs = new List<Pet>();
            expectedOutputs.Add(pet1);
            expectedOutputs.Add(pet2);
            expectedOutputs.Add(pet4);
            expectedOutputs.Add(pet5);

            fixture.MockUserResponseElementParser.Setup(x => x.ExtractElement<Pet>(inputs)).Returns(parserOutputs);

            var userDataItems = new UserResponseDataItems
            {
                pets = inputs
            };

            var results = fixture.PetService.GetUserPets(userDataItems);

            Assert.Equal(4, results.Count());
            Assert.Equal(pet1.FullName, results.ElementAt(0).FullName);
            Assert.Equal(pet2.FullName, results.ElementAt(1).FullName);
            Assert.Equal(pet4.FullName, results.ElementAt(2).FullName);
            Assert.Equal(pet5.FullName, results.ElementAt(3).FullName);
        }
    }
}