using HabiticaPetFeeder.Logic.Model.ContentResponse;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using HabiticaPetFeeder.Logic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service
{
    public class DataServiceTests_Fixture //: IDisposable
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
                        {"Meat", new ContentResponseFoodInfo() { target = "Base" } },
                        {"Potatoe", new ContentResponseFoodInfo() { target = "Desert" } },
                        {"Milk", new ContentResponseFoodInfo() { target = "White" } },
                        {"Fish", new ContentResponseFoodInfo() { target = "Skeleton" } },
                        {"RottenMeat", new ContentResponseFoodInfo() { target = "Zombie" } },
                        {"CottonCandyBlue", new ContentResponseFoodInfo() { target = "CottonCandyBlue" } },
                        {"Cake_Skeleton", new ContentResponseFoodInfo() { target = "Skeleton" } },
                        {"Cake_Base", new ContentResponseFoodInfo() { target = "Base" } },
                        {"Cake_CottonCandyPink", new ContentResponseFoodInfo() { target = "CottonCandyPink" } },
                        {"Cake_CottonCandyBlue", new ContentResponseFoodInfo() { target = "CottonCandyBlue" } },
                        {"Cake_Golden", new ContentResponseFoodInfo() { target = "Golden" } },
                        {"Candy_Skeleton", new ContentResponseFoodInfo() { target = "Skeleton" } },
                        {"Candy_Base", new ContentResponseFoodInfo() { target = "Base" } },
                        {"Pie_Base", new ContentResponseFoodInfo() { target = "Base" } },
                        {"Saddle", new ContentResponseFoodInfo() { target = null } }
                    },
                    petInfo = new Dictionary<string, ContentResponsePetInfo>
                    {

                    },
                    pets = new Dictionary<string, string>
                    {
                        { "Wolf-Base", "true" },
                        { "Wolf-White", "true" },
                        { "Wolf-Desert", "true" },
                        { "TigerCub-Base", "true" },
                        { "TigerCub-Shade", "true" },
                        { "LionCub-Base", "true" },
                        { "LionCub-White", "true" },
                        { "Fox-CottonCandyPink", "true" },
                        { "Dragon-Skeleton", "true" },
                        { "BearCub-Golden", "true" },
                    },
                    premiumPets = new Dictionary<string, string>
                    {
                        { "Wolf-RoyalPurple", "true" },
                        { "Wolf-Cupid", "true" },
                        { "TigerCub-RoyalPurple", "true" },
                        { "PandaCub-RoyalPurple", "true" },
                        { "LionCub-RoyalPurple", "true" },
                        { "Fox-RoyalPurple", "true" },
                        { "FlyingPig-RoyalPurple", "true" },
                        { "Dragon-RoyalPurple", "true" },
                        { "BearCub-RoyalPurple", "true" },
                    },
                    questPets = new Dictionary<string, string>
                    {
                        { "Gryphon-Base", "true" },
                        { "Owl-Skeleton", "true" },
                        { "Robot-Golden", "true" },
                    },
                    specialPets = new Dictionary<string, string>
                    {
                        { "Wolf-Veteran", "veteranWolf" },
                        { "JackOLantern-Base", "jackolantern" },
                        { "Turkey-Base", "turkey" },
                        { "Orca-Base", "orca" },
                        { "BearCub-Polar", "polarBearPup" },
                    },
                    wackyPets = new Dictionary<string, string>
                    {
                        { "Wolf-Veggie", "true" },
                        { "Dragon-Dessert", "true" },
                        { "BearCub-Veggie", "true" },
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
                            { "LionCub-White", 20 },
                            { "Wolf-Base", 10 },
                            { "Dragon-Skeleton", 5 },
                            { "TigerCub-RoyalPurple", 5 },
                            { "Dragon-RoyalPurple", -1 },
                            { "FlyingPig-RoyalPurple", -1 },
                            { "Orca-Base", 5 }
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
        public void GetPets_ReturnsFeedablePets()
        {
            var result = fixture.DataService.GetPets(fixture.TestUserResponse, fixture.TestContentResponse);

            //The LionCub White and the Wolf Base are basic pets which have not been raised to a mount.
            Assert.Equal("LionCub-White", result.ElementAt(0).FullName);
            Assert.Equal("Wolf-Base", result.ElementAt(1).FullName);

            //The Tiger Royal Purple is a premium pet which has not been raised into a mount.
            Assert.Equal("TigerCub-RoyalPurple", result.ElementAt(2).FullName);
        }

        [Fact]
        public void GetPets_ExcludesNonFeedablePets()
        {
            var result = fixture.DataService.GetPets(fixture.TestUserResponse, fixture.TestContentResponse);

            //The Dragon Skeleton, while also being a basic pet with a positive fed points value, has been turned into a mount and cannot be fed.
            Assert.DoesNotContain(result, x => x.FullName == "Dragon-Skeleton");

            //The Dragon RoyalPurple has not been hatched and cannot be fed.  It is also a mount.
            Assert.DoesNotContain(result, x => x.FullName == "Dragon-RoyalPurple");

            //The Orca is a special pet and cannot be fed.
            Assert.DoesNotContain(result, x => x.FullName == "Orca-Base");
        }

        [Fact]
        public void GetFood_ReturnsUsableFood()
        {
            var result = fixture.DataService.GetFoods(fixture.TestUserResponse, fixture.TestContentResponse);

            Assert.Equal(7, result.Count());
        }

        [Fact]
        public void GetFood_ExcludesSaddle()
        {
            var result = fixture.DataService.GetFoods(fixture.TestUserResponse, fixture.TestContentResponse);

            Assert.DoesNotContain(result, x => x.FullName == "Saddle");
        }
    }
}
