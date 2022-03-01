using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Tests.DataFixtures;

public class ContentResponseDataFixture
{
    public ContentResponse ContentResponse { get; }

    public ContentResponseDataFixture()
    {
        ContentResponse = BuildTestContentResponse();
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
}
