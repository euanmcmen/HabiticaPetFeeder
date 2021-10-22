using HabiticaPetFeeder.Logic.Model.ContentResponse;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using HabiticaPetFeeder.Logic.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service
{
    public class DataServiceTests_Fixture : IDisposable
    {
        public DataService DataService { get; }

        public UserResponse TestUserResponse { get; }

        public ContentResponse TestContentResponse { get; }

        public DataServiceTests_Fixture()
        {
            //TestHelpers.GetMockedLogFactoryForType<DataService>().Object

            TestUserResponse = BuildTestUserResponse();

            TestContentResponse = BuildTestContentResponse();

            DataService = new DataService();
        }

        private static ContentResponse BuildTestContentResponse()
        {
            return new ContentResponse()
            {
                data = new ContentResponseData()
                {
                    food = new Dictionary<string, ContentResponseFoodInfo>()
                    {
                        {"", new ContentResponseFoodInfo() { target = "" } },
                        {"", new ContentResponseFoodInfo() { target = "" } },
                        {"", new ContentResponseFoodInfo() { target = "" } },
                        {"", new ContentResponseFoodInfo() { target = "" } },
                        {"", new ContentResponseFoodInfo() { target = "" } }
                    },
                    petInfo = new Dictionary<string, ContentResponsePetInfo>
                    {

                    },
                    pets = new Dictionary<string, string>
                    {
                        { "", "" },
                        { "", "" },
                        { "", "" },
                        { "", "" },
                        { "", "" },
                    },
                    premiumPets = new Dictionary<string, string>
                    {
                        { "", "" },
                        { "", "" },
                        { "", "" },
                        { "", "" },
                        { "", "" },
                    },
                    specialPets = new Dictionary<string, string>
                    {
                        { "", "" },
                        { "", "" },
                        { "", "" },
                        { "", "" },
                        { "", "" },
                    },
                    wackyPets = new Dictionary<string, string>
                    {

                    }                    
                }
            };
        }

        private static UserResponse BuildTestUserResponse()
        {
            return new UserResponse
            {
                data = new UserResponseData
                {
                    items = new UserResponseDataItems()
                    {
                        pets = new Dictionary<string, int>
                        {
                            { "LionCub-White", 20 },            //Basic & Feedable
                            { "Wolf-Base", 10 },                //Basic & Feedable 
                            { "Dragon-Skeleton", 5 },           //Basic & Feedable & Owned Mount
                            { "TigerCub-RoyalPurple", 5 },      //Non-Basic & Feedable
                            { "Dragon-RoyalPurple", -1 },       //Non-Basic & Not Feedable
                            { "FlyingPig-RoyalPurple", -1 },    //Non-Basic & Not Feedable 
                            { "Orca-Base", 5 }                  //Pet Type Not Feedable & Owned Mount
                        },
                        food = new Dictionary<string, int>()
                        {
                            { "Potatoe", 207 },
                            { "Meat", 175 },
                            { "Saddle", 10 },
                            { "CottonCandyBlue", 199 },
                            { "Cake_Base", 4 },
                            { "Cake_CottonCandyBlue", 4 },
                            { "Candy_Base", 1 },
                            { "Pie_Base", 1 },

                        },
                        mounts = new Dictionary<string, bool>()
                        {
                            { "Dragon-Skeleton", true },
                            { "Dragon-White", true },
                            { "Dragon-RoyalPurple", true },
                            { "Orca-Base", true },
                            { "Gryphon-RoyalPurple", true },
                            { "FlyingPig-RoyalPurple", true },
                            { "Aether-Invisible", true }
                        }
                    }
                }
            };
        }

        public void Dispose()
        {
        }
    }

    public class DataServiceTests : IClassFixture<DataServiceTests_Fixture>
    {
        private readonly DataServiceTests_Fixture fixture;

        public DataServiceTests(DataServiceTests_Fixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void GetPets_ReturnsPets()
        {
            var result = fixture.DataService.GetPets(fixture.TestUserResponse, fixture.TestContentResponse);
        }

        [Fact]
        public void GetFood_ReturnsFood()
        {

        }
    }
}
