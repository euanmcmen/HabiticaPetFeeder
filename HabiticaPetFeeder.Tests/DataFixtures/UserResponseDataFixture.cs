using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Tests.DataFixtures;

public class UserResponseDataFixture
{
    public UserResponse UserResponse { get; }

    public UserResponseDataFixture()
    {
        UserResponse = BuildTestUserResponse();
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
                },
                auth = new UserResponseDataAuth()
                {
                    local = new UserResponseDataAuthLocal()
                    {
                        username = "DressingFrown"
                    }
                }
            }
        };
    }
}
