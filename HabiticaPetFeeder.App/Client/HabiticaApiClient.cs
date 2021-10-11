using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public class HabiticaApiClient : IHabiticaApiClient
    {
        public async Task<UserResponse> GetUserAsync()
        {
            await Task.CompletedTask;

            var result = JsonConvert.DeserializeObject<UserResponse>(TestResponse);

            return result;

            //return JsonConvert.DeserializeObject<UserResponse>(TestResponse, new JsonSerializerSettings
            //{
            //    ContractResolver = new DefaultContractResolver
            //    {
            //        NamingStrategy = new KebabCaseNamingStrategy()
            //    }
            //});
        }

        private static string TestResponse =
@"

{
  'success': true,
  'data': {
      'items': {
          'pets': {
              'LionCub-White': 20,
              'Dragon-RoyalPurple': -1,
              'Cactus-Desert': 5,
              'Dragon-Skeleton': 5,
              'Wolf-Base': 10,
              'TigerCub-Base': 5,
              'PandaCub-Base': 5,
              'LionCub-Base': 5,
              'Fox-Base': 5,
              'FlyingPig-Base': 5,
              'Dragon-Base': 5,
              'Cactus-Base': 5,
              'BearCub-Base': 5,
              'Wolf-RoyalPurple': 5,
              'TigerCub-RoyalPurple': 5,
              'PandaCub-RoyalPurple': 5,
              'LionCub-RoyalPurple': 5,
              'Fox-RoyalPurple': 5,
              'FlyingPig-RoyalPurple': -1,
              'Cactus-RoyalPurple': 5,
              'BearCub-RoyalPurple': 5,
              'Dragon-White': 5,
              'Dragon-Desert': 5,
              'Dragon-Red': 5,
              'Dragon-Shade': 5,
              'Dragon-Zombie': 5,
              'Dragon-CottonCandyPink': 5,
              'Dragon-CottonCandyBlue': 5,
              'Dragon-Golden': 5,
              'JackOLantern-Base': 5,
              'Wolf-White': 5,
              'Wolf-Desert': 5,
              'Wolf-Red': 5,
              'Wolf-Shade': 5,
              'Wolf-Skeleton': 5,
              'Wolf-Zombie': 5,
              'Wolf-CottonCandyPink': 5,
              'Wolf-CottonCandyBlue': 5,
              'Wolf-Golden': 5,
              'Cactus-White': 5,
              'Cactus-Red': 5,
              'Cactus-Shade': 5,
              'Cactus-Skeleton': 5,
              'Cactus-Zombie': 5,
              'Cactus-CottonCandyPink': 5,
              'Cactus-CottonCandyBlue': 5,
              'Cactus-Golden': 5,
              'BearCub-Skeleton': 5,
              'FlyingPig-Skeleton': 5,
              'Fox-Skeleton': 5,
              'LionCub-Skeleton': 5,
              'PandaCub-Skeleton': 5,
              'TigerCub-Skeleton': 5,
              'TigerCub-White': 5,
              'TigerCub-Desert': 5,
              'TigerCub-Red': 5,
              'TigerCub-Shade': 5,
              'TigerCub-CottonCandyPink': 5,
              'TigerCub-Zombie': 5,
              'TigerCub-CottonCandyBlue': 5,
              'TigerCub-Golden': 5,
              'PandaCub-White': 5,
              'PandaCub-Desert': 5,
              'PandaCub-Red': 5,
              'PandaCub-Shade': 5,
              'PandaCub-Zombie': 5,
              'PandaCub-CottonCandyPink': 5,
              'PandaCub-CottonCandyBlue': 5,
              'PandaCub-Golden': 5,
              'LionCub-Desert': 5,
              'LionCub-Shade': 5,
              'LionCub-Red': 5,
              'LionCub-Zombie': 5,
              'LionCub-CottonCandyPink': 5,
              'LionCub-CottonCandyBlue': 5,
              'LionCub-Golden': 5,
              'Fox-White': 5,
              'Fox-Desert': 5,
              'Fox-Red': 5,
              'Fox-Shade': 5,
              'Fox-Zombie': 5,
              'Fox-CottonCandyPink': 5,
              'Fox-CottonCandyBlue': 5,
              'Fox-Golden': 5,
              'FlyingPig-White': 5,
              'FlyingPig-Desert': 5,
              'FlyingPig-Red': 5,
              'FlyingPig-Shade': 5,
              'FlyingPig-Zombie': 5,
              'FlyingPig-CottonCandyPink': 5,
              'FlyingPig-CottonCandyBlue': 5,
              'FlyingPig-Golden': 5,
              'BearCub-White': 5,
              'BearCub-Desert': 5,
              'BearCub-Red': 5,
              'BearCub-Shade': 5,
              'BearCub-Zombie': 5,
              'BearCub-CottonCandyPink': 5,
              'BearCub-CottonCandyBlue': 5,
              'BearCub-Golden': 5,
              'Turkey-Base': 5,
              'Orca-Base': 5,
              'Gryphon-RoyalPurple': 5
          },
          'food': {
              'Potatoe': 199,
              'CottonCandyBlue': 197,
              'Chocolate': 180,
              'Meat': 167,
              'CottonCandyPink': 212,
              'Milk': 174,
              'Strawberry': 199,
              'Honey': 201,
              'Fish': 196,
              'RottenMeat': 175,
              'Saddle': 8,
              'Cake_Base': 4,
              'Cake_CottonCandyBlue': 4,
              'Cake_CottonCandyPink': 6,
              'Cake_Desert': 5,
              'Cake_Golden': 4,
              'Cake_Red': 3,
              'Cake_Shade': 8,
              'Cake_Skeleton': 3,
              'Cake_White': 7,
              'Cake_Zombie': 4,
              'Candy_Base': 1,
              'Candy_CottonCandyBlue': 1,
              'Candy_CottonCandyPink': 1,
              'Candy_Desert': 1,
              'Candy_Golden': 1,
              'Candy_Red': 1,
              'Candy_Shade': 1,
              'Candy_Skeleton': 1,
              'Candy_White': 1,
              'Candy_Zombie': 1,
              'Pie_Base': 1,
              'Pie_CottonCandyBlue': 1,
              'Pie_CottonCandyPink': 1,
              'Pie_Desert': 1,
              'Pie_Golden': 1,
              'Pie_Red': 1,
              'Pie_Shade': 1,
              'Pie_Skeleton': 1,
              'Pie_White': 1,
              'Pie_Zombie': 1
          }
      }
  }
}

";

    }
}
