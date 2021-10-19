using HabiticaPetFeeder.Logic.Model.ContentResponse;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Client
{
    public class DummyHabiticaApiClient : IHabiticaApiClient
    {
        public async Task<UserResponse> GetUserAsync()
        {
            await Task.CompletedTask;

            var result = JsonConvert.DeserializeObject<UserResponse>(UserResponseTest);

            return result;
        }

        public async Task<ContentResponse> GetContentAsync()
        {
            await Task.CompletedTask;

            var result = JsonConvert.DeserializeObject<ContentResponse>(ContentResponseTest);

            return result;
        }

        private static readonly string UserResponseTest =
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
              'Meat': 10,
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


        private static readonly string ContentResponseTest =
@"

{
    'success': true,
    'data':{
        'pets': {
            'Wolf-Base': true,
            'Wolf-White': true,
            'Wolf-Desert': true,
            'Wolf-Red': true,
            'Wolf-Shade': true,
            'Wolf-Skeleton': true,
            'Wolf-Zombie': true,
            'Wolf-CottonCandyPink': true,
            'Wolf-CottonCandyBlue': true,
            'Wolf-Golden': true,
            'TigerCub-Base': true,
            'TigerCub-White': true,
            'TigerCub-Desert': true,
            'TigerCub-Red': true,
            'TigerCub-Shade': true,
            'TigerCub-Skeleton': true,
            'TigerCub-Zombie': true,
            'TigerCub-CottonCandyPink': true,
            'TigerCub-CottonCandyBlue': true,
            'TigerCub-Golden': true,
            'PandaCub-Base': true,
            'PandaCub-White': true,
            'PandaCub-Desert': true,
            'PandaCub-Red': true,
            'PandaCub-Shade': true,
            'PandaCub-Skeleton': true,
            'PandaCub-Zombie': true,
            'PandaCub-CottonCandyPink': true,
            'PandaCub-CottonCandyBlue': true,
            'PandaCub-Golden': true,
            'LionCub-Base': true,
            'LionCub-White': true,
            'LionCub-Desert': true,
            'LionCub-Red': true,
            'LionCub-Shade': true,
            'LionCub-Skeleton': true,
            'LionCub-Zombie': true,
            'LionCub-CottonCandyPink': true,
            'LionCub-CottonCandyBlue': true,
            'LionCub-Golden': true,
            'Fox-Base': true,
            'Fox-White': true,
            'Fox-Desert': true,
            'Fox-Red': true,
            'Fox-Shade': true,
            'Fox-Skeleton': true,
            'Fox-Zombie': true,
            'Fox-CottonCandyPink': true,
            'Fox-CottonCandyBlue': true,
            'Fox-Golden': true,
            'FlyingPig-Base': true,
            'FlyingPig-White': true,
            'FlyingPig-Desert': true,
            'FlyingPig-Red': true,
            'FlyingPig-Shade': true,
            'FlyingPig-Skeleton': true,
            'FlyingPig-Zombie': true,
            'FlyingPig-CottonCandyPink': true,
            'FlyingPig-CottonCandyBlue': true,
            'FlyingPig-Golden': true,
            'Dragon-Base': true,
            'Dragon-White': true,
            'Dragon-Desert': true,
            'Dragon-Red': true,
            'Dragon-Shade': true,
            'Dragon-Skeleton': true,
            'Dragon-Zombie': true,
            'Dragon-CottonCandyPink': true,
            'Dragon-CottonCandyBlue': true,
            'Dragon-Golden': true,
            'Cactus-Base': true,
            'Cactus-White': true,
            'Cactus-Desert': true,
            'Cactus-Red': true,
            'Cactus-Shade': true,
            'Cactus-Skeleton': true,
            'Cactus-Zombie': true,
            'Cactus-CottonCandyPink': true,
            'Cactus-CottonCandyBlue': true,
            'Cactus-Golden': true,
            'BearCub-Base': true,
            'BearCub-White': true,
            'BearCub-Desert': true,
            'BearCub-Red': true,
            'BearCub-Shade': true,
            'BearCub-Skeleton': true,
            'BearCub-Zombie': true,
            'BearCub-CottonCandyPink': true,
            'BearCub-CottonCandyBlue': true,
            'BearCub-Golden': true
        },
        'premiumPets': {
            'Wolf-RoyalPurple': true,
            'Wolf-Cupid': true,
            'Wolf-Shimmer': true,
            'Wolf-Fairy': true,
            'Wolf-Floral': true,
            'Wolf-Aquatic': true,
            'Wolf-Ember': true,
            'Wolf-Thunderstorm': true,
            'Wolf-Spooky': true,
            'Wolf-Ghost': true,
            'Wolf-Holly': true,
            'Wolf-Peppermint': true,
            'Wolf-StarryNight': true,
            'Wolf-Rainbow': true,
            'Wolf-Glass': true,
            'Wolf-Glow': true,
            'Wolf-Frost': true,
            'Wolf-IcySnow': true,
            'Wolf-RoseQuartz': true,
            'Wolf-Celestial': true,
            'Wolf-Sunshine': true,
            'Wolf-Bronze': true,
            'Wolf-Watery': true,
            'Wolf-Silver': true,
            'Wolf-Shadow': true,
            'Wolf-Amber': true,
            'Wolf-Aurora': true,
            'Wolf-Ruby': true,
            'Wolf-BirchBark': true,
            'Wolf-Fluorite': true,
            'Wolf-SandSculpture': true,
            'Wolf-Windup': true,
            'Wolf-Turquoise': true,
            'Wolf-Vampire': true,
            'Wolf-AutumnLeaf': true,
            'Wolf-BlackPearl': true,
            'Wolf-StainedGlass': true,
            'Wolf-PolkaDot': true,
            'Wolf-MossyStone': true,
            'Wolf-Sunset': true,
            'Wolf-Moonglow': true,
            'Wolf-SolarSystem': true,
            'TigerCub-RoyalPurple': true,
            'TigerCub-Cupid': true,
            'TigerCub-Shimmer': true,
            'TigerCub-Fairy': true,
            'TigerCub-Floral': true,
            'TigerCub-Aquatic': true,
            'TigerCub-Ember': true,
            'TigerCub-Thunderstorm': true,
            'TigerCub-Spooky': true,
            'TigerCub-Ghost': true,
            'TigerCub-Holly': true,
            'TigerCub-Peppermint': true,
            'TigerCub-StarryNight': true,
            'TigerCub-Rainbow': true,
            'TigerCub-Glass': true,
            'TigerCub-Glow': true,
            'TigerCub-Frost': true,
            'TigerCub-IcySnow': true,
            'TigerCub-RoseQuartz': true,
            'TigerCub-Celestial': true,
            'TigerCub-Sunshine': true,
            'TigerCub-Bronze': true,
            'TigerCub-Watery': true,
            'TigerCub-Silver': true,
            'TigerCub-Shadow': true,
            'TigerCub-Amber': true,
            'TigerCub-Aurora': true,
            'TigerCub-Ruby': true,
            'TigerCub-BirchBark': true,
            'TigerCub-Fluorite': true,
            'TigerCub-SandSculpture': true,
            'TigerCub-Windup': true,
            'TigerCub-Turquoise': true,
            'TigerCub-Vampire': true,
            'TigerCub-AutumnLeaf': true,
            'TigerCub-BlackPearl': true,
            'TigerCub-StainedGlass': true,
            'TigerCub-PolkaDot': true,
            'TigerCub-MossyStone': true,
            'TigerCub-Sunset': true,
            'TigerCub-Moonglow': true,
            'TigerCub-SolarSystem': true,
            'PandaCub-RoyalPurple': true,
            'PandaCub-Cupid': true,
            'PandaCub-Shimmer': true,
            'PandaCub-Fairy': true,
            'PandaCub-Floral': true,
            'PandaCub-Aquatic': true,
            'PandaCub-Ember': true,
            'PandaCub-Thunderstorm': true,
            'PandaCub-Spooky': true,
            'PandaCub-Ghost': true,
            'PandaCub-Holly': true,
            'PandaCub-Peppermint': true,
            'PandaCub-StarryNight': true,
            'PandaCub-Rainbow': true,
            'PandaCub-Glass': true,
            'PandaCub-Glow': true,
            'PandaCub-Frost': true,
            'PandaCub-IcySnow': true,
            'PandaCub-RoseQuartz': true,
            'PandaCub-Celestial': true,
            'PandaCub-Sunshine': true,
            'PandaCub-Bronze': true,
            'PandaCub-Watery': true,
            'PandaCub-Silver': true,
            'PandaCub-Shadow': true,
            'PandaCub-Amber': true,
            'PandaCub-Aurora': true,
            'PandaCub-Ruby': true,
            'PandaCub-BirchBark': true,
            'PandaCub-Fluorite': true,
            'PandaCub-SandSculpture': true,
            'PandaCub-Windup': true,
            'PandaCub-Turquoise': true,
            'PandaCub-Vampire': true,
            'PandaCub-AutumnLeaf': true,
            'PandaCub-BlackPearl': true,
            'PandaCub-StainedGlass': true,
            'PandaCub-PolkaDot': true,
            'PandaCub-MossyStone': true,
            'PandaCub-Sunset': true,
            'PandaCub-Moonglow': true,
            'PandaCub-SolarSystem': true,
            'LionCub-RoyalPurple': true,
            'LionCub-Cupid': true,
            'LionCub-Shimmer': true,
            'LionCub-Fairy': true,
            'LionCub-Floral': true,
            'LionCub-Aquatic': true,
            'LionCub-Ember': true,
            'LionCub-Thunderstorm': true,
            'LionCub-Spooky': true,
            'LionCub-Ghost': true,
            'LionCub-Holly': true,
            'LionCub-Peppermint': true,
            'LionCub-StarryNight': true,
            'LionCub-Rainbow': true,
            'LionCub-Glass': true,
            'LionCub-Glow': true,
            'LionCub-Frost': true,
            'LionCub-IcySnow': true,
            'LionCub-RoseQuartz': true,
            'LionCub-Celestial': true,
            'LionCub-Sunshine': true,
            'LionCub-Bronze': true,
            'LionCub-Watery': true,
            'LionCub-Silver': true,
            'LionCub-Shadow': true,
            'LionCub-Amber': true,
            'LionCub-Aurora': true,
            'LionCub-Ruby': true,
            'LionCub-BirchBark': true,
            'LionCub-Fluorite': true,
            'LionCub-SandSculpture': true,
            'LionCub-Windup': true,
            'LionCub-Turquoise': true,
            'LionCub-Vampire': true,
            'LionCub-AutumnLeaf': true,
            'LionCub-BlackPearl': true,
            'LionCub-StainedGlass': true,
            'LionCub-PolkaDot': true,
            'LionCub-MossyStone': true,
            'LionCub-Sunset': true,
            'LionCub-Moonglow': true,
            'LionCub-SolarSystem': true,
            'Fox-RoyalPurple': true,
            'Fox-Cupid': true,
            'Fox-Shimmer': true,
            'Fox-Fairy': true,
            'Fox-Floral': true,
            'Fox-Aquatic': true,
            'Fox-Ember': true,
            'Fox-Thunderstorm': true,
            'Fox-Spooky': true,
            'Fox-Ghost': true,
            'Fox-Holly': true,
            'Fox-Peppermint': true,
            'Fox-StarryNight': true,
            'Fox-Rainbow': true,
            'Fox-Glass': true,
            'Fox-Glow': true,
            'Fox-Frost': true,
            'Fox-IcySnow': true,
            'Fox-RoseQuartz': true,
            'Fox-Celestial': true,
            'Fox-Sunshine': true,
            'Fox-Bronze': true,
            'Fox-Watery': true,
            'Fox-Silver': true,
            'Fox-Shadow': true,
            'Fox-Amber': true,
            'Fox-Aurora': true,
            'Fox-Ruby': true,
            'Fox-BirchBark': true,
            'Fox-Fluorite': true,
            'Fox-SandSculpture': true,
            'Fox-Windup': true,
            'Fox-Turquoise': true,
            'Fox-Vampire': true,
            'Fox-AutumnLeaf': true,
            'Fox-BlackPearl': true,
            'Fox-StainedGlass': true,
            'Fox-PolkaDot': true,
            'Fox-MossyStone': true,
            'Fox-Sunset': true,
            'Fox-Moonglow': true,
            'Fox-SolarSystem': true,
            'FlyingPig-RoyalPurple': true,
            'FlyingPig-Cupid': true,
            'FlyingPig-Shimmer': true,
            'FlyingPig-Fairy': true,
            'FlyingPig-Floral': true,
            'FlyingPig-Aquatic': true,
            'FlyingPig-Ember': true,
            'FlyingPig-Thunderstorm': true,
            'FlyingPig-Spooky': true,
            'FlyingPig-Ghost': true,
            'FlyingPig-Holly': true,
            'FlyingPig-Peppermint': true,
            'FlyingPig-StarryNight': true,
            'FlyingPig-Rainbow': true,
            'FlyingPig-Glass': true,
            'FlyingPig-Glow': true,
            'FlyingPig-Frost': true,
            'FlyingPig-IcySnow': true,
            'FlyingPig-RoseQuartz': true,
            'FlyingPig-Celestial': true,
            'FlyingPig-Sunshine': true,
            'FlyingPig-Bronze': true,
            'FlyingPig-Watery': true,
            'FlyingPig-Silver': true,
            'FlyingPig-Shadow': true,
            'FlyingPig-Amber': true,
            'FlyingPig-Aurora': true,
            'FlyingPig-Ruby': true,
            'FlyingPig-BirchBark': true,
            'FlyingPig-Fluorite': true,
            'FlyingPig-SandSculpture': true,
            'FlyingPig-Windup': true,
            'FlyingPig-Turquoise': true,
            'FlyingPig-Vampire': true,
            'FlyingPig-AutumnLeaf': true,
            'FlyingPig-BlackPearl': true,
            'FlyingPig-StainedGlass': true,
            'FlyingPig-PolkaDot': true,
            'FlyingPig-MossyStone': true,
            'FlyingPig-Sunset': true,
            'FlyingPig-Moonglow': true,
            'FlyingPig-SolarSystem': true,
            'Dragon-RoyalPurple': true,
            'Dragon-Cupid': true,
            'Dragon-Shimmer': true,
            'Dragon-Fairy': true,
            'Dragon-Floral': true,
            'Dragon-Aquatic': true,
            'Dragon-Ember': true,
            'Dragon-Thunderstorm': true,
            'Dragon-Spooky': true,
            'Dragon-Ghost': true,
            'Dragon-Holly': true,
            'Dragon-Peppermint': true,
            'Dragon-StarryNight': true,
            'Dragon-Rainbow': true,
            'Dragon-Glass': true,
            'Dragon-Glow': true,
            'Dragon-Frost': true,
            'Dragon-IcySnow': true,
            'Dragon-RoseQuartz': true,
            'Dragon-Celestial': true,
            'Dragon-Sunshine': true,
            'Dragon-Bronze': true,
            'Dragon-Watery': true,
            'Dragon-Silver': true,
            'Dragon-Shadow': true,
            'Dragon-Amber': true,
            'Dragon-Aurora': true,
            'Dragon-Ruby': true,
            'Dragon-BirchBark': true,
            'Dragon-Fluorite': true,
            'Dragon-SandSculpture': true,
            'Dragon-Windup': true,
            'Dragon-Turquoise': true,
            'Dragon-Vampire': true,
            'Dragon-AutumnLeaf': true,
            'Dragon-BlackPearl': true,
            'Dragon-StainedGlass': true,
            'Dragon-PolkaDot': true,
            'Dragon-MossyStone': true,
            'Dragon-Sunset': true,
            'Dragon-Moonglow': true,
            'Dragon-SolarSystem': true,
            'Cactus-RoyalPurple': true,
            'Cactus-Cupid': true,
            'Cactus-Shimmer': true,
            'Cactus-Fairy': true,
            'Cactus-Floral': true,
            'Cactus-Aquatic': true,
            'Cactus-Ember': true,
            'Cactus-Thunderstorm': true,
            'Cactus-Spooky': true,
            'Cactus-Ghost': true,
            'Cactus-Holly': true,
            'Cactus-Peppermint': true,
            'Cactus-StarryNight': true,
            'Cactus-Rainbow': true,
            'Cactus-Glass': true,
            'Cactus-Glow': true,
            'Cactus-Frost': true,
            'Cactus-IcySnow': true,
            'Cactus-RoseQuartz': true,
            'Cactus-Celestial': true,
            'Cactus-Sunshine': true,
            'Cactus-Bronze': true,
            'Cactus-Watery': true,
            'Cactus-Silver': true,
            'Cactus-Shadow': true,
            'Cactus-Amber': true,
            'Cactus-Aurora': true,
            'Cactus-Ruby': true,
            'Cactus-BirchBark': true,
            'Cactus-Fluorite': true,
            'Cactus-SandSculpture': true,
            'Cactus-Windup': true,
            'Cactus-Turquoise': true,
            'Cactus-Vampire': true,
            'Cactus-AutumnLeaf': true,
            'Cactus-BlackPearl': true,
            'Cactus-StainedGlass': true,
            'Cactus-PolkaDot': true,
            'Cactus-MossyStone': true,
            'Cactus-Sunset': true,
            'Cactus-Moonglow': true,
            'Cactus-SolarSystem': true,
            'BearCub-RoyalPurple': true,
            'BearCub-Cupid': true,
            'BearCub-Shimmer': true,
            'BearCub-Fairy': true,
            'BearCub-Floral': true,
            'BearCub-Aquatic': true,
            'BearCub-Ember': true,
            'BearCub-Thunderstorm': true,
            'BearCub-Spooky': true,
            'BearCub-Ghost': true,
            'BearCub-Holly': true,
            'BearCub-Peppermint': true,
            'BearCub-StarryNight': true,
            'BearCub-Rainbow': true,
            'BearCub-Glass': true,
            'BearCub-Glow': true,
            'BearCub-Frost': true,
            'BearCub-IcySnow': true,
            'BearCub-RoseQuartz': true,
            'BearCub-Celestial': true,
            'BearCub-Sunshine': true,
            'BearCub-Bronze': true,
            'BearCub-Watery': true,
            'BearCub-Silver': true,
            'BearCub-Shadow': true,
            'BearCub-Amber': true,
            'BearCub-Aurora': true,
            'BearCub-Ruby': true,
            'BearCub-BirchBark': true,
            'BearCub-Fluorite': true,
            'BearCub-SandSculpture': true,
            'BearCub-Windup': true,
            'BearCub-Turquoise': true,
            'BearCub-Vampire': true,
            'BearCub-AutumnLeaf': true,
            'BearCub-BlackPearl': true,
            'BearCub-StainedGlass': true,
            'BearCub-PolkaDot': true,
            'BearCub-MossyStone': true,
            'BearCub-Sunset': true,
            'BearCub-Moonglow': true,
            'BearCub-SolarSystem': true
        },
        'questPets': {
            'Gryphon-Base': true,
            'Gryphon-White': true,
            'Gryphon-Desert': true,
            'Gryphon-Red': true,
            'Gryphon-Shade': true,
            'Gryphon-Skeleton': true,
            'Gryphon-Zombie': true,
            'Gryphon-CottonCandyPink': true,
            'Gryphon-CottonCandyBlue': true,
            'Gryphon-Golden': true,
            'Hedgehog-Base': true,
            'Hedgehog-White': true,
            'Hedgehog-Desert': true,
            'Hedgehog-Red': true,
            'Hedgehog-Shade': true,
            'Hedgehog-Skeleton': true,
            'Hedgehog-Zombie': true,
            'Hedgehog-CottonCandyPink': true,
            'Hedgehog-CottonCandyBlue': true,
            'Hedgehog-Golden': true,
            'Deer-Base': true,
            'Deer-White': true,
            'Deer-Desert': true,
            'Deer-Red': true,
            'Deer-Shade': true,
            'Deer-Skeleton': true,
            'Deer-Zombie': true,
            'Deer-CottonCandyPink': true,
            'Deer-CottonCandyBlue': true,
            'Deer-Golden': true,
            'Egg-Base': true,
            'Egg-White': true,
            'Egg-Desert': true,
            'Egg-Red': true,
            'Egg-Shade': true,
            'Egg-Skeleton': true,
            'Egg-Zombie': true,
            'Egg-CottonCandyPink': true,
            'Egg-CottonCandyBlue': true,
            'Egg-Golden': true,
            'Rat-Base': true,
            'Rat-White': true,
            'Rat-Desert': true,
            'Rat-Red': true,
            'Rat-Shade': true,
            'Rat-Skeleton': true,
            'Rat-Zombie': true,
            'Rat-CottonCandyPink': true,
            'Rat-CottonCandyBlue': true,
            'Rat-Golden': true,
            'Octopus-Base': true,
            'Octopus-White': true,
            'Octopus-Desert': true,
            'Octopus-Red': true,
            'Octopus-Shade': true,
            'Octopus-Skeleton': true,
            'Octopus-Zombie': true,
            'Octopus-CottonCandyPink': true,
            'Octopus-CottonCandyBlue': true,
            'Octopus-Golden': true,
            'Seahorse-Base': true,
            'Seahorse-White': true,
            'Seahorse-Desert': true,
            'Seahorse-Red': true,
            'Seahorse-Shade': true,
            'Seahorse-Skeleton': true,
            'Seahorse-Zombie': true,
            'Seahorse-CottonCandyPink': true,
            'Seahorse-CottonCandyBlue': true,
            'Seahorse-Golden': true,
            'Parrot-Base': true,
            'Parrot-White': true,
            'Parrot-Desert': true,
            'Parrot-Red': true,
            'Parrot-Shade': true,
            'Parrot-Skeleton': true,
            'Parrot-Zombie': true,
            'Parrot-CottonCandyPink': true,
            'Parrot-CottonCandyBlue': true,
            'Parrot-Golden': true,
            'Rooster-Base': true,
            'Rooster-White': true,
            'Rooster-Desert': true,
            'Rooster-Red': true,
            'Rooster-Shade': true,
            'Rooster-Skeleton': true,
            'Rooster-Zombie': true,
            'Rooster-CottonCandyPink': true,
            'Rooster-CottonCandyBlue': true,
            'Rooster-Golden': true,
            'Spider-Base': true,
            'Spider-White': true,
            'Spider-Desert': true,
            'Spider-Red': true,
            'Spider-Shade': true,
            'Spider-Skeleton': true,
            'Spider-Zombie': true,
            'Spider-CottonCandyPink': true,
            'Spider-CottonCandyBlue': true,
            'Spider-Golden': true,
            'Owl-Base': true,
            'Owl-White': true,
            'Owl-Desert': true,
            'Owl-Red': true,
            'Owl-Shade': true,
            'Owl-Skeleton': true,
            'Owl-Zombie': true,
            'Owl-CottonCandyPink': true,
            'Owl-CottonCandyBlue': true,
            'Owl-Golden': true,
            'Penguin-Base': true,
            'Penguin-White': true,
            'Penguin-Desert': true,
            'Penguin-Red': true,
            'Penguin-Shade': true,
            'Penguin-Skeleton': true,
            'Penguin-Zombie': true,
            'Penguin-CottonCandyPink': true,
            'Penguin-CottonCandyBlue': true,
            'Penguin-Golden': true,
            'TRex-Base': true,
            'TRex-White': true,
            'TRex-Desert': true,
            'TRex-Red': true,
            'TRex-Shade': true,
            'TRex-Skeleton': true,
            'TRex-Zombie': true,
            'TRex-CottonCandyPink': true,
            'TRex-CottonCandyBlue': true,
            'TRex-Golden': true,
            'Rock-Base': true,
            'Rock-White': true,
            'Rock-Desert': true,
            'Rock-Red': true,
            'Rock-Shade': true,
            'Rock-Skeleton': true,
            'Rock-Zombie': true,
            'Rock-CottonCandyPink': true,
            'Rock-CottonCandyBlue': true,
            'Rock-Golden': true,
            'Bunny-Base': true,
            'Bunny-White': true,
            'Bunny-Desert': true,
            'Bunny-Red': true,
            'Bunny-Shade': true,
            'Bunny-Skeleton': true,
            'Bunny-Zombie': true,
            'Bunny-CottonCandyPink': true,
            'Bunny-CottonCandyBlue': true,
            'Bunny-Golden': true,
            'Slime-Base': true,
            'Slime-White': true,
            'Slime-Desert': true,
            'Slime-Red': true,
            'Slime-Shade': true,
            'Slime-Skeleton': true,
            'Slime-Zombie': true,
            'Slime-CottonCandyPink': true,
            'Slime-CottonCandyBlue': true,
            'Slime-Golden': true,
            'Sheep-Base': true,
            'Sheep-White': true,
            'Sheep-Desert': true,
            'Sheep-Red': true,
            'Sheep-Shade': true,
            'Sheep-Skeleton': true,
            'Sheep-Zombie': true,
            'Sheep-CottonCandyPink': true,
            'Sheep-CottonCandyBlue': true,
            'Sheep-Golden': true,
            'Cuttlefish-Base': true,
            'Cuttlefish-White': true,
            'Cuttlefish-Desert': true,
            'Cuttlefish-Red': true,
            'Cuttlefish-Shade': true,
            'Cuttlefish-Skeleton': true,
            'Cuttlefish-Zombie': true,
            'Cuttlefish-CottonCandyPink': true,
            'Cuttlefish-CottonCandyBlue': true,
            'Cuttlefish-Golden': true,
            'Whale-Base': true,
            'Whale-White': true,
            'Whale-Desert': true,
            'Whale-Red': true,
            'Whale-Shade': true,
            'Whale-Skeleton': true,
            'Whale-Zombie': true,
            'Whale-CottonCandyPink': true,
            'Whale-CottonCandyBlue': true,
            'Whale-Golden': true,
            'Cheetah-Base': true,
            'Cheetah-White': true,
            'Cheetah-Desert': true,
            'Cheetah-Red': true,
            'Cheetah-Shade': true,
            'Cheetah-Skeleton': true,
            'Cheetah-Zombie': true,
            'Cheetah-CottonCandyPink': true,
            'Cheetah-CottonCandyBlue': true,
            'Cheetah-Golden': true,
            'Horse-Base': true,
            'Horse-White': true,
            'Horse-Desert': true,
            'Horse-Red': true,
            'Horse-Shade': true,
            'Horse-Skeleton': true,
            'Horse-Zombie': true,
            'Horse-CottonCandyPink': true,
            'Horse-CottonCandyBlue': true,
            'Horse-Golden': true,
            'Frog-Base': true,
            'Frog-White': true,
            'Frog-Desert': true,
            'Frog-Red': true,
            'Frog-Shade': true,
            'Frog-Skeleton': true,
            'Frog-Zombie': true,
            'Frog-CottonCandyPink': true,
            'Frog-CottonCandyBlue': true,
            'Frog-Golden': true,
            'Snake-Base': true,
            'Snake-White': true,
            'Snake-Desert': true,
            'Snake-Red': true,
            'Snake-Shade': true,
            'Snake-Skeleton': true,
            'Snake-Zombie': true,
            'Snake-CottonCandyPink': true,
            'Snake-CottonCandyBlue': true,
            'Snake-Golden': true,
            'Unicorn-Base': true,
            'Unicorn-White': true,
            'Unicorn-Desert': true,
            'Unicorn-Red': true,
            'Unicorn-Shade': true,
            'Unicorn-Skeleton': true,
            'Unicorn-Zombie': true,
            'Unicorn-CottonCandyPink': true,
            'Unicorn-CottonCandyBlue': true,
            'Unicorn-Golden': true,
            'Sabretooth-Base': true,
            'Sabretooth-White': true,
            'Sabretooth-Desert': true,
            'Sabretooth-Red': true,
            'Sabretooth-Shade': true,
            'Sabretooth-Skeleton': true,
            'Sabretooth-Zombie': true,
            'Sabretooth-CottonCandyPink': true,
            'Sabretooth-CottonCandyBlue': true,
            'Sabretooth-Golden': true,
            'Monkey-Base': true,
            'Monkey-White': true,
            'Monkey-Desert': true,
            'Monkey-Red': true,
            'Monkey-Shade': true,
            'Monkey-Skeleton': true,
            'Monkey-Zombie': true,
            'Monkey-CottonCandyPink': true,
            'Monkey-CottonCandyBlue': true,
            'Monkey-Golden': true,
            'Snail-Base': true,
            'Snail-White': true,
            'Snail-Desert': true,
            'Snail-Red': true,
            'Snail-Shade': true,
            'Snail-Skeleton': true,
            'Snail-Zombie': true,
            'Snail-CottonCandyPink': true,
            'Snail-CottonCandyBlue': true,
            'Snail-Golden': true,
            'Falcon-Base': true,
            'Falcon-White': true,
            'Falcon-Desert': true,
            'Falcon-Red': true,
            'Falcon-Shade': true,
            'Falcon-Skeleton': true,
            'Falcon-Zombie': true,
            'Falcon-CottonCandyPink': true,
            'Falcon-CottonCandyBlue': true,
            'Falcon-Golden': true,
            'Treeling-Base': true,
            'Treeling-White': true,
            'Treeling-Desert': true,
            'Treeling-Red': true,
            'Treeling-Shade': true,
            'Treeling-Skeleton': true,
            'Treeling-Zombie': true,
            'Treeling-CottonCandyPink': true,
            'Treeling-CottonCandyBlue': true,
            'Treeling-Golden': true,
            'Axolotl-Base': true,
            'Axolotl-White': true,
            'Axolotl-Desert': true,
            'Axolotl-Red': true,
            'Axolotl-Shade': true,
            'Axolotl-Skeleton': true,
            'Axolotl-Zombie': true,
            'Axolotl-CottonCandyPink': true,
            'Axolotl-CottonCandyBlue': true,
            'Axolotl-Golden': true,
            'Turtle-Base': true,
            'Turtle-White': true,
            'Turtle-Desert': true,
            'Turtle-Red': true,
            'Turtle-Shade': true,
            'Turtle-Skeleton': true,
            'Turtle-Zombie': true,
            'Turtle-CottonCandyPink': true,
            'Turtle-CottonCandyBlue': true,
            'Turtle-Golden': true,
            'Armadillo-Base': true,
            'Armadillo-White': true,
            'Armadillo-Desert': true,
            'Armadillo-Red': true,
            'Armadillo-Shade': true,
            'Armadillo-Skeleton': true,
            'Armadillo-Zombie': true,
            'Armadillo-CottonCandyPink': true,
            'Armadillo-CottonCandyBlue': true,
            'Armadillo-Golden': true,
            'Cow-Base': true,
            'Cow-White': true,
            'Cow-Desert': true,
            'Cow-Red': true,
            'Cow-Shade': true,
            'Cow-Skeleton': true,
            'Cow-Zombie': true,
            'Cow-CottonCandyPink': true,
            'Cow-CottonCandyBlue': true,
            'Cow-Golden': true,
            'Beetle-Base': true,
            'Beetle-White': true,
            'Beetle-Desert': true,
            'Beetle-Red': true,
            'Beetle-Shade': true,
            'Beetle-Skeleton': true,
            'Beetle-Zombie': true,
            'Beetle-CottonCandyPink': true,
            'Beetle-CottonCandyBlue': true,
            'Beetle-Golden': true,
            'Ferret-Base': true,
            'Ferret-White': true,
            'Ferret-Desert': true,
            'Ferret-Red': true,
            'Ferret-Shade': true,
            'Ferret-Skeleton': true,
            'Ferret-Zombie': true,
            'Ferret-CottonCandyPink': true,
            'Ferret-CottonCandyBlue': true,
            'Ferret-Golden': true,
            'Sloth-Base': true,
            'Sloth-White': true,
            'Sloth-Desert': true,
            'Sloth-Red': true,
            'Sloth-Shade': true,
            'Sloth-Skeleton': true,
            'Sloth-Zombie': true,
            'Sloth-CottonCandyPink': true,
            'Sloth-CottonCandyBlue': true,
            'Sloth-Golden': true,
            'Triceratops-Base': true,
            'Triceratops-White': true,
            'Triceratops-Desert': true,
            'Triceratops-Red': true,
            'Triceratops-Shade': true,
            'Triceratops-Skeleton': true,
            'Triceratops-Zombie': true,
            'Triceratops-CottonCandyPink': true,
            'Triceratops-CottonCandyBlue': true,
            'Triceratops-Golden': true,
            'GuineaPig-Base': true,
            'GuineaPig-White': true,
            'GuineaPig-Desert': true,
            'GuineaPig-Red': true,
            'GuineaPig-Shade': true,
            'GuineaPig-Skeleton': true,
            'GuineaPig-Zombie': true,
            'GuineaPig-CottonCandyPink': true,
            'GuineaPig-CottonCandyBlue': true,
            'GuineaPig-Golden': true,
            'Peacock-Base': true,
            'Peacock-White': true,
            'Peacock-Desert': true,
            'Peacock-Red': true,
            'Peacock-Shade': true,
            'Peacock-Skeleton': true,
            'Peacock-Zombie': true,
            'Peacock-CottonCandyPink': true,
            'Peacock-CottonCandyBlue': true,
            'Peacock-Golden': true,
            'Butterfly-Base': true,
            'Butterfly-White': true,
            'Butterfly-Desert': true,
            'Butterfly-Red': true,
            'Butterfly-Shade': true,
            'Butterfly-Skeleton': true,
            'Butterfly-Zombie': true,
            'Butterfly-CottonCandyPink': true,
            'Butterfly-CottonCandyBlue': true,
            'Butterfly-Golden': true,
            'Nudibranch-Base': true,
            'Nudibranch-White': true,
            'Nudibranch-Desert': true,
            'Nudibranch-Red': true,
            'Nudibranch-Shade': true,
            'Nudibranch-Skeleton': true,
            'Nudibranch-Zombie': true,
            'Nudibranch-CottonCandyPink': true,
            'Nudibranch-CottonCandyBlue': true,
            'Nudibranch-Golden': true,
            'Hippo-Base': true,
            'Hippo-White': true,
            'Hippo-Desert': true,
            'Hippo-Red': true,
            'Hippo-Shade': true,
            'Hippo-Skeleton': true,
            'Hippo-Zombie': true,
            'Hippo-CottonCandyPink': true,
            'Hippo-CottonCandyBlue': true,
            'Hippo-Golden': true,
            'Yarn-Base': true,
            'Yarn-White': true,
            'Yarn-Desert': true,
            'Yarn-Red': true,
            'Yarn-Shade': true,
            'Yarn-Skeleton': true,
            'Yarn-Zombie': true,
            'Yarn-CottonCandyPink': true,
            'Yarn-CottonCandyBlue': true,
            'Yarn-Golden': true,
            'Pterodactyl-Base': true,
            'Pterodactyl-White': true,
            'Pterodactyl-Desert': true,
            'Pterodactyl-Red': true,
            'Pterodactyl-Shade': true,
            'Pterodactyl-Skeleton': true,
            'Pterodactyl-Zombie': true,
            'Pterodactyl-CottonCandyPink': true,
            'Pterodactyl-CottonCandyBlue': true,
            'Pterodactyl-Golden': true,
            'Badger-Base': true,
            'Badger-White': true,
            'Badger-Desert': true,
            'Badger-Red': true,
            'Badger-Shade': true,
            'Badger-Skeleton': true,
            'Badger-Zombie': true,
            'Badger-CottonCandyPink': true,
            'Badger-CottonCandyBlue': true,
            'Badger-Golden': true,
            'Squirrel-Base': true,
            'Squirrel-White': true,
            'Squirrel-Desert': true,
            'Squirrel-Red': true,
            'Squirrel-Shade': true,
            'Squirrel-Skeleton': true,
            'Squirrel-Zombie': true,
            'Squirrel-CottonCandyPink': true,
            'Squirrel-CottonCandyBlue': true,
            'Squirrel-Golden': true,
            'SeaSerpent-Base': true,
            'SeaSerpent-White': true,
            'SeaSerpent-Desert': true,
            'SeaSerpent-Red': true,
            'SeaSerpent-Shade': true,
            'SeaSerpent-Skeleton': true,
            'SeaSerpent-Zombie': true,
            'SeaSerpent-CottonCandyPink': true,
            'SeaSerpent-CottonCandyBlue': true,
            'SeaSerpent-Golden': true,
            'Kangaroo-Base': true,
            'Kangaroo-White': true,
            'Kangaroo-Desert': true,
            'Kangaroo-Red': true,
            'Kangaroo-Shade': true,
            'Kangaroo-Skeleton': true,
            'Kangaroo-Zombie': true,
            'Kangaroo-CottonCandyPink': true,
            'Kangaroo-CottonCandyBlue': true,
            'Kangaroo-Golden': true,
            'Alligator-Base': true,
            'Alligator-White': true,
            'Alligator-Desert': true,
            'Alligator-Red': true,
            'Alligator-Shade': true,
            'Alligator-Skeleton': true,
            'Alligator-Zombie': true,
            'Alligator-CottonCandyPink': true,
            'Alligator-CottonCandyBlue': true,
            'Alligator-Golden': true,
            'Velociraptor-Base': true,
            'Velociraptor-White': true,
            'Velociraptor-Desert': true,
            'Velociraptor-Red': true,
            'Velociraptor-Shade': true,
            'Velociraptor-Skeleton': true,
            'Velociraptor-Zombie': true,
            'Velociraptor-CottonCandyPink': true,
            'Velociraptor-CottonCandyBlue': true,
            'Velociraptor-Golden': true,
            'Dolphin-Base': true,
            'Dolphin-White': true,
            'Dolphin-Desert': true,
            'Dolphin-Red': true,
            'Dolphin-Shade': true,
            'Dolphin-Skeleton': true,
            'Dolphin-Zombie': true,
            'Dolphin-CottonCandyPink': true,
            'Dolphin-CottonCandyBlue': true,
            'Dolphin-Golden': true,
            'Robot-Base': true,
            'Robot-White': true,
            'Robot-Desert': true,
            'Robot-Red': true,
            'Robot-Shade': true,
            'Robot-Skeleton': true,
            'Robot-Zombie': true,
            'Robot-CottonCandyPink': true,
            'Robot-CottonCandyBlue': true,
            'Robot-Golden': true
        },
        'specialPets': {
            'Wolf-Veteran': 'veteranWolf',
            'Wolf-Cerberus': 'cerberusPup',
            'Dragon-Hydra': 'hydra',
            'Turkey-Base': 'turkey',
            'BearCub-Polar': 'polarBearPup',
            'MantisShrimp-Base': 'mantisShrimp',
            'JackOLantern-Base': 'jackolantern',
            'Mammoth-Base': 'mammoth',
            'Tiger-Veteran': 'veteranTiger',
            'Phoenix-Base': 'phoenix',
            'Turkey-Gilded': 'gildedTurkey',
            'MagicalBee-Base': 'magicalBee',
            'Lion-Veteran': 'veteranLion',
            'Gryphon-RoyalPurple': 'royalPurpleGryphon',
            'JackOLantern-Ghost': 'ghostJackolantern',
            'Jackalope-RoyalPurple': 'royalPurpleJackalope',
            'Orca-Base': 'orca',
            'Bear-Veteran': 'veteranBear',
            'Hippogriff-Hopeful': 'hopefulHippogriffPet',
            'Fox-Veteran': 'veteranFox',
            'JackOLantern-Glow': 'glowJackolantern',
            'Gryphon-Gryphatrice': 'gryphatrice',
            'JackOLantern-RoyalPurple': 'royalPurpleJackolantern'
        },
        'wackyPets': {
            'Wolf-Veggie': true,
            'Wolf-Dessert': true,
            'TigerCub-Veggie': true,
            'TigerCub-Dessert': true,
            'PandaCub-Veggie': true,
            'PandaCub-Dessert': true,
            'LionCub-Veggie': true,
            'LionCub-Dessert': true,
            'Fox-Veggie': true,
            'Fox-Dessert': true,
            'FlyingPig-Veggie': true,
            'FlyingPig-Dessert': true,
            'Dragon-Veggie': true,
            'Dragon-Dessert': true,
            'Cactus-Veggie': true,
            'Cactus-Dessert': true,
            'BearCub-Veggie': true,
            'BearCub-Dessert': true
        },
        'petInfo': {
            'Wolf-Base': {
                'key': 'Wolf-Base',
                'type': 'drop',
                'potion': 'Base',
                'egg': 'Wolf',
                'text': 'Base Wolf'
            },
            'Wolf-White': {
                'key': 'Wolf-White',
                'type': 'drop',
                'potion': 'White',
                'egg': 'Wolf',
                'text': 'White Wolf'
            },
            'Wolf-Desert': {
                'key': 'Wolf-Desert',
                'type': 'drop',
                'potion': 'Desert',
                'egg': 'Wolf',
                'text': 'Desert Wolf'
            },
            'Wolf-Red': {
                'key': 'Wolf-Red',
                'type': 'drop',
                'potion': 'Red',
                'egg': 'Wolf',
                'text': 'Red Wolf'
            },
            'Wolf-Shade': {
                'key': 'Wolf-Shade',
                'type': 'drop',
                'potion': 'Shade',
                'egg': 'Wolf',
                'text': 'Shade Wolf'
            },
            'Wolf-Skeleton': {
                'key': 'Wolf-Skeleton',
                'type': 'drop',
                'potion': 'Skeleton',
                'egg': 'Wolf',
                'text': 'Skeleton Wolf'
            },
            'Wolf-Zombie': {
                'key': 'Wolf-Zombie',
                'type': 'drop',
                'potion': 'Zombie',
                'egg': 'Wolf',
                'text': 'Zombie Wolf'
            },
            'Wolf-CottonCandyPink': {
                'key': 'Wolf-CottonCandyPink',
                'type': 'drop',
                'potion': 'CottonCandyPink',
                'egg': 'Wolf',
                'text': 'Cotton Candy Pink Wolf'
            },
            'Wolf-CottonCandyBlue': {
                'key': 'Wolf-CottonCandyBlue',
                'type': 'drop',
                'potion': 'CottonCandyBlue',
                'egg': 'Wolf',
                'text': 'Cotton Candy Blue Wolf'
            },
            'Wolf-Golden': {
                'key': 'Wolf-Golden',
                'type': 'drop',
                'potion': 'Golden',
                'egg': 'Wolf',
                'text': 'Golden Wolf'
            },
            'TigerCub-Base': {
                'key': 'TigerCub-Base',
                'type': 'drop',
                'potion': 'Base',
                'egg': 'TigerCub',
                'text': 'Base Tiger Cub'
            },
            'TigerCub-White': {
                'key': 'TigerCub-White',
                'type': 'drop',
                'potion': 'White',
                'egg': 'TigerCub',
                'text': 'White Tiger Cub'
            },
            'TigerCub-Desert': {
                'key': 'TigerCub-Desert',
                'type': 'drop',
                'potion': 'Desert',
                'egg': 'TigerCub',
                'text': 'Desert Tiger Cub'
            },
            'TigerCub-Red': {
                'key': 'TigerCub-Red',
                'type': 'drop',
                'potion': 'Red',
                'egg': 'TigerCub',
                'text': 'Red Tiger Cub'
            },
            'TigerCub-Shade': {
                'key': 'TigerCub-Shade',
                'type': 'drop',
                'potion': 'Shade',
                'egg': 'TigerCub',
                'text': 'Shade Tiger Cub'
            },
            'TigerCub-Skeleton': {
                'key': 'TigerCub-Skeleton',
                'type': 'drop',
                'potion': 'Skeleton',
                'egg': 'TigerCub',
                'text': 'Skeleton Tiger Cub'
            },
            'TigerCub-Zombie': {
                'key': 'TigerCub-Zombie',
                'type': 'drop',
                'potion': 'Zombie',
                'egg': 'TigerCub',
                'text': 'Zombie Tiger Cub'
            },
            'TigerCub-CottonCandyPink': {
                'key': 'TigerCub-CottonCandyPink',
                'type': 'drop',
                'potion': 'CottonCandyPink',
                'egg': 'TigerCub',
                'text': 'Cotton Candy Pink Tiger Cub'
            },
            'TigerCub-CottonCandyBlue': {
                'key': 'TigerCub-CottonCandyBlue',
                'type': 'drop',
                'potion': 'CottonCandyBlue',
                'egg': 'TigerCub',
                'text': 'Cotton Candy Blue Tiger Cub'
            },
            'TigerCub-Golden': {
                'key': 'TigerCub-Golden',
                'type': 'drop',
                'potion': 'Golden',
                'egg': 'TigerCub',
                'text': 'Golden Tiger Cub'
            },
            'PandaCub-Base': {
                'key': 'PandaCub-Base',
                'type': 'drop',
                'potion': 'Base',
                'egg': 'PandaCub',
                'text': 'Base Panda Cub'
            },
            'PandaCub-White': {
                'key': 'PandaCub-White',
                'type': 'drop',
                'potion': 'White',
                'egg': 'PandaCub',
                'text': 'White Panda Cub'
            },
            'PandaCub-Desert': {
                'key': 'PandaCub-Desert',
                'type': 'drop',
                'potion': 'Desert',
                'egg': 'PandaCub',
                'text': 'Desert Panda Cub'
            },
            'PandaCub-Red': {
                'key': 'PandaCub-Red',
                'type': 'drop',
                'potion': 'Red',
                'egg': 'PandaCub',
                'text': 'Red Panda Cub'
            },
            'PandaCub-Shade': {
                'key': 'PandaCub-Shade',
                'type': 'drop',
                'potion': 'Shade',
                'egg': 'PandaCub',
                'text': 'Shade Panda Cub'
            },
            'PandaCub-Skeleton': {
                'key': 'PandaCub-Skeleton',
                'type': 'drop',
                'potion': 'Skeleton',
                'egg': 'PandaCub',
                'text': 'Skeleton Panda Cub'
            },
            'PandaCub-Zombie': {
                'key': 'PandaCub-Zombie',
                'type': 'drop',
                'potion': 'Zombie',
                'egg': 'PandaCub',
                'text': 'Zombie Panda Cub'
            },
            'PandaCub-CottonCandyPink': {
                'key': 'PandaCub-CottonCandyPink',
                'type': 'drop',
                'potion': 'CottonCandyPink',
                'egg': 'PandaCub',
                'text': 'Cotton Candy Pink Panda Cub'
            },
            'PandaCub-CottonCandyBlue': {
                'key': 'PandaCub-CottonCandyBlue',
                'type': 'drop',
                'potion': 'CottonCandyBlue',
                'egg': 'PandaCub',
                'text': 'Cotton Candy Blue Panda Cub'
            },
            'PandaCub-Golden': {
                'key': 'PandaCub-Golden',
                'type': 'drop',
                'potion': 'Golden',
                'egg': 'PandaCub',
                'text': 'Golden Panda Cub'
            },
            'LionCub-Base': {
                'key': 'LionCub-Base',
                'type': 'drop',
                'potion': 'Base',
                'egg': 'LionCub',
                'text': 'Base Lion Cub'
            },
            'LionCub-White': {
                'key': 'LionCub-White',
                'type': 'drop',
                'potion': 'White',
                'egg': 'LionCub',
                'text': 'White Lion Cub'
            },
            'LionCub-Desert': {
                'key': 'LionCub-Desert',
                'type': 'drop',
                'potion': 'Desert',
                'egg': 'LionCub',
                'text': 'Desert Lion Cub'
            },
            'LionCub-Red': {
                'key': 'LionCub-Red',
                'type': 'drop',
                'potion': 'Red',
                'egg': 'LionCub',
                'text': 'Red Lion Cub'
            },
            'LionCub-Shade': {
                'key': 'LionCub-Shade',
                'type': 'drop',
                'potion': 'Shade',
                'egg': 'LionCub',
                'text': 'Shade Lion Cub'
            },
            'LionCub-Skeleton': {
                'key': 'LionCub-Skeleton',
                'type': 'drop',
                'potion': 'Skeleton',
                'egg': 'LionCub',
                'text': 'Skeleton Lion Cub'
            },
            'LionCub-Zombie': {
                'key': 'LionCub-Zombie',
                'type': 'drop',
                'potion': 'Zombie',
                'egg': 'LionCub',
                'text': 'Zombie Lion Cub'
            },
            'LionCub-CottonCandyPink': {
                'key': 'LionCub-CottonCandyPink',
                'type': 'drop',
                'potion': 'CottonCandyPink',
                'egg': 'LionCub',
                'text': 'Cotton Candy Pink Lion Cub'
            },
            'LionCub-CottonCandyBlue': {
                'key': 'LionCub-CottonCandyBlue',
                'type': 'drop',
                'potion': 'CottonCandyBlue',
                'egg': 'LionCub',
                'text': 'Cotton Candy Blue Lion Cub'
            },
            'LionCub-Golden': {
                'key': 'LionCub-Golden',
                'type': 'drop',
                'potion': 'Golden',
                'egg': 'LionCub',
                'text': 'Golden Lion Cub'
            },
            'Fox-Base': {
                'key': 'Fox-Base',
                'type': 'drop',
                'potion': 'Base',
                'egg': 'Fox',
                'text': 'Base Fox'
            },
            'Fox-White': {
                'key': 'Fox-White',
                'type': 'drop',
                'potion': 'White',
                'egg': 'Fox',
                'text': 'White Fox'
            },
            'Fox-Desert': {
                'key': 'Fox-Desert',
                'type': 'drop',
                'potion': 'Desert',
                'egg': 'Fox',
                'text': 'Desert Fox'
            },
            'Fox-Red': {
                'key': 'Fox-Red',
                'type': 'drop',
                'potion': 'Red',
                'egg': 'Fox',
                'text': 'Red Fox'
            },
            'Fox-Shade': {
                'key': 'Fox-Shade',
                'type': 'drop',
                'potion': 'Shade',
                'egg': 'Fox',
                'text': 'Shade Fox'
            },
            'Fox-Skeleton': {
                'key': 'Fox-Skeleton',
                'type': 'drop',
                'potion': 'Skeleton',
                'egg': 'Fox',
                'text': 'Skeleton Fox'
            },
            'Fox-Zombie': {
                'key': 'Fox-Zombie',
                'type': 'drop',
                'potion': 'Zombie',
                'egg': 'Fox',
                'text': 'Zombie Fox'
            },
            'Fox-CottonCandyPink': {
                'key': 'Fox-CottonCandyPink',
                'type': 'drop',
                'potion': 'CottonCandyPink',
                'egg': 'Fox',
                'text': 'Cotton Candy Pink Fox'
            },
            'Fox-CottonCandyBlue': {
                'key': 'Fox-CottonCandyBlue',
                'type': 'drop',
                'potion': 'CottonCandyBlue',
                'egg': 'Fox',
                'text': 'Cotton Candy Blue Fox'
            },
            'Fox-Golden': {
                'key': 'Fox-Golden',
                'type': 'drop',
                'potion': 'Golden',
                'egg': 'Fox',
                'text': 'Golden Fox'
            },
            'FlyingPig-Base': {
                'key': 'FlyingPig-Base',
                'type': 'drop',
                'potion': 'Base',
                'egg': 'FlyingPig',
                'text': 'Base Flying Pig'
            },
            'FlyingPig-White': {
                'key': 'FlyingPig-White',
                'type': 'drop',
                'potion': 'White',
                'egg': 'FlyingPig',
                'text': 'White Flying Pig'
            },
            'FlyingPig-Desert': {
                'key': 'FlyingPig-Desert',
                'type': 'drop',
                'potion': 'Desert',
                'egg': 'FlyingPig',
                'text': 'Desert Flying Pig'
            },
            'FlyingPig-Red': {
                'key': 'FlyingPig-Red',
                'type': 'drop',
                'potion': 'Red',
                'egg': 'FlyingPig',
                'text': 'Red Flying Pig'
            },
            'FlyingPig-Shade': {
                'key': 'FlyingPig-Shade',
                'type': 'drop',
                'potion': 'Shade',
                'egg': 'FlyingPig',
                'text': 'Shade Flying Pig'
            },
            'FlyingPig-Skeleton': {
                'key': 'FlyingPig-Skeleton',
                'type': 'drop',
                'potion': 'Skeleton',
                'egg': 'FlyingPig',
                'text': 'Skeleton Flying Pig'
            },
            'FlyingPig-Zombie': {
                'key': 'FlyingPig-Zombie',
                'type': 'drop',
                'potion': 'Zombie',
                'egg': 'FlyingPig',
                'text': 'Zombie Flying Pig'
            },
            'FlyingPig-CottonCandyPink': {
                'key': 'FlyingPig-CottonCandyPink',
                'type': 'drop',
                'potion': 'CottonCandyPink',
                'egg': 'FlyingPig',
                'text': 'Cotton Candy Pink Flying Pig'
            },
            'FlyingPig-CottonCandyBlue': {
                'key': 'FlyingPig-CottonCandyBlue',
                'type': 'drop',
                'potion': 'CottonCandyBlue',
                'egg': 'FlyingPig',
                'text': 'Cotton Candy Blue Flying Pig'
            },
            'FlyingPig-Golden': {
                'key': 'FlyingPig-Golden',
                'type': 'drop',
                'potion': 'Golden',
                'egg': 'FlyingPig',
                'text': 'Golden Flying Pig'
            },
            'Dragon-Base': {
                'key': 'Dragon-Base',
                'type': 'drop',
                'potion': 'Base',
                'egg': 'Dragon',
                'text': 'Base Dragon'
            },
            'Dragon-White': {
                'key': 'Dragon-White',
                'type': 'drop',
                'potion': 'White',
                'egg': 'Dragon',
                'text': 'White Dragon'
            },
            'Dragon-Desert': {
                'key': 'Dragon-Desert',
                'type': 'drop',
                'potion': 'Desert',
                'egg': 'Dragon',
                'text': 'Desert Dragon'
            },
            'Dragon-Red': {
                'key': 'Dragon-Red',
                'type': 'drop',
                'potion': 'Red',
                'egg': 'Dragon',
                'text': 'Red Dragon'
            },
            'Dragon-Shade': {
                'key': 'Dragon-Shade',
                'type': 'drop',
                'potion': 'Shade',
                'egg': 'Dragon',
                'text': 'Shade Dragon'
            },
            'Dragon-Skeleton': {
                'key': 'Dragon-Skeleton',
                'type': 'drop',
                'potion': 'Skeleton',
                'egg': 'Dragon',
                'text': 'Skeleton Dragon'
            },
            'Dragon-Zombie': {
                'key': 'Dragon-Zombie',
                'type': 'drop',
                'potion': 'Zombie',
                'egg': 'Dragon',
                'text': 'Zombie Dragon'
            },
            'Dragon-CottonCandyPink': {
                'key': 'Dragon-CottonCandyPink',
                'type': 'drop',
                'potion': 'CottonCandyPink',
                'egg': 'Dragon',
                'text': 'Cotton Candy Pink Dragon'
            },
            'Dragon-CottonCandyBlue': {
                'key': 'Dragon-CottonCandyBlue',
                'type': 'drop',
                'potion': 'CottonCandyBlue',
                'egg': 'Dragon',
                'text': 'Cotton Candy Blue Dragon'
            },
            'Dragon-Golden': {
                'key': 'Dragon-Golden',
                'type': 'drop',
                'potion': 'Golden',
                'egg': 'Dragon',
                'text': 'Golden Dragon'
            },
            'Cactus-Base': {
                'key': 'Cactus-Base',
                'type': 'drop',
                'potion': 'Base',
                'egg': 'Cactus',
                'text': 'Base Cactus'
            },
            'Cactus-White': {
                'key': 'Cactus-White',
                'type': 'drop',
                'potion': 'White',
                'egg': 'Cactus',
                'text': 'White Cactus'
            },
            'Cactus-Desert': {
                'key': 'Cactus-Desert',
                'type': 'drop',
                'potion': 'Desert',
                'egg': 'Cactus',
                'text': 'Desert Cactus'
            },
            'Cactus-Red': {
                'key': 'Cactus-Red',
                'type': 'drop',
                'potion': 'Red',
                'egg': 'Cactus',
                'text': 'Red Cactus'
            },
            'Cactus-Shade': {
                'key': 'Cactus-Shade',
                'type': 'drop',
                'potion': 'Shade',
                'egg': 'Cactus',
                'text': 'Shade Cactus'
            },
            'Cactus-Skeleton': {
                'key': 'Cactus-Skeleton',
                'type': 'drop',
                'potion': 'Skeleton',
                'egg': 'Cactus',
                'text': 'Skeleton Cactus'
            },
            'Cactus-Zombie': {
                'key': 'Cactus-Zombie',
                'type': 'drop',
                'potion': 'Zombie',
                'egg': 'Cactus',
                'text': 'Zombie Cactus'
            },
            'Cactus-CottonCandyPink': {
                'key': 'Cactus-CottonCandyPink',
                'type': 'drop',
                'potion': 'CottonCandyPink',
                'egg': 'Cactus',
                'text': 'Cotton Candy Pink Cactus'
            },
            'Cactus-CottonCandyBlue': {
                'key': 'Cactus-CottonCandyBlue',
                'type': 'drop',
                'potion': 'CottonCandyBlue',
                'egg': 'Cactus',
                'text': 'Cotton Candy Blue Cactus'
            },
            'Cactus-Golden': {
                'key': 'Cactus-Golden',
                'type': 'drop',
                'potion': 'Golden',
                'egg': 'Cactus',
                'text': 'Golden Cactus'
            },
            'BearCub-Base': {
                'key': 'BearCub-Base',
                'type': 'drop',
                'potion': 'Base',
                'egg': 'BearCub',
                'text': 'Base Bear Cub'
            },
            'BearCub-White': {
                'key': 'BearCub-White',
                'type': 'drop',
                'potion': 'White',
                'egg': 'BearCub',
                'text': 'White Bear Cub'
            },
            'BearCub-Desert': {
                'key': 'BearCub-Desert',
                'type': 'drop',
                'potion': 'Desert',
                'egg': 'BearCub',
                'text': 'Desert Bear Cub'
            },
            'BearCub-Red': {
                'key': 'BearCub-Red',
                'type': 'drop',
                'potion': 'Red',
                'egg': 'BearCub',
                'text': 'Red Bear Cub'
            },
            'BearCub-Shade': {
                'key': 'BearCub-Shade',
                'type': 'drop',
                'potion': 'Shade',
                'egg': 'BearCub',
                'text': 'Shade Bear Cub'
            },
            'BearCub-Skeleton': {
                'key': 'BearCub-Skeleton',
                'type': 'drop',
                'potion': 'Skeleton',
                'egg': 'BearCub',
                'text': 'Skeleton Bear Cub'
            },
            'BearCub-Zombie': {
                'key': 'BearCub-Zombie',
                'type': 'drop',
                'potion': 'Zombie',
                'egg': 'BearCub',
                'text': 'Zombie Bear Cub'
            },
            'BearCub-CottonCandyPink': {
                'key': 'BearCub-CottonCandyPink',
                'type': 'drop',
                'potion': 'CottonCandyPink',
                'egg': 'BearCub',
                'text': 'Cotton Candy Pink Bear Cub'
            },
            'BearCub-CottonCandyBlue': {
                'key': 'BearCub-CottonCandyBlue',
                'type': 'drop',
                'potion': 'CottonCandyBlue',
                'egg': 'BearCub',
                'text': 'Cotton Candy Blue Bear Cub'
            },
            'BearCub-Golden': {
                'key': 'BearCub-Golden',
                'type': 'drop',
                'potion': 'Golden',
                'egg': 'BearCub',
                'text': 'Golden Bear Cub'
            },
            'Wolf-RoyalPurple': {
                'key': 'Wolf-RoyalPurple',
                'type': 'premium',
                'potion': 'RoyalPurple',
                'egg': 'Wolf',
                'text': 'Royal Purple Wolf'
            },
            'Wolf-Cupid': {
                'key': 'Wolf-Cupid',
                'type': 'premium',
                'potion': 'Cupid',
                'egg': 'Wolf',
                'text': 'Cupid Wolf'
            },
            'Wolf-Shimmer': {
                'key': 'Wolf-Shimmer',
                'type': 'premium',
                'potion': 'Shimmer',
                'egg': 'Wolf',
                'text': 'Shimmer Wolf'
            },
            'Wolf-Fairy': {
                'key': 'Wolf-Fairy',
                'type': 'premium',
                'potion': 'Fairy',
                'egg': 'Wolf',
                'text': 'Fairy Wolf'
            },
            'Wolf-Floral': {
                'key': 'Wolf-Floral',
                'type': 'premium',
                'potion': 'Floral',
                'egg': 'Wolf',
                'text': 'Floral Wolf'
            },
            'Wolf-Aquatic': {
                'key': 'Wolf-Aquatic',
                'type': 'premium',
                'potion': 'Aquatic',
                'egg': 'Wolf',
                'text': 'Aquatic Wolf'
            },
            'Wolf-Ember': {
                'key': 'Wolf-Ember',
                'type': 'premium',
                'potion': 'Ember',
                'egg': 'Wolf',
                'text': 'Ember Wolf'
            },
            'Wolf-Thunderstorm': {
                'key': 'Wolf-Thunderstorm',
                'type': 'premium',
                'potion': 'Thunderstorm',
                'egg': 'Wolf',
                'text': 'Thunderstorm Wolf'
            },
            'Wolf-Spooky': {
                'key': 'Wolf-Spooky',
                'type': 'premium',
                'potion': 'Spooky',
                'egg': 'Wolf',
                'text': 'Spooky Wolf'
            },
            'Wolf-Ghost': {
                'key': 'Wolf-Ghost',
                'type': 'premium',
                'potion': 'Ghost',
                'egg': 'Wolf',
                'text': 'Ghost Wolf'
            },
            'Wolf-Holly': {
                'key': 'Wolf-Holly',
                'type': 'premium',
                'potion': 'Holly',
                'egg': 'Wolf',
                'text': 'Holly Wolf'
            },
            'Wolf-Peppermint': {
                'key': 'Wolf-Peppermint',
                'type': 'premium',
                'potion': 'Peppermint',
                'egg': 'Wolf',
                'text': 'Peppermint Wolf'
            },
            'Wolf-StarryNight': {
                'key': 'Wolf-StarryNight',
                'type': 'premium',
                'potion': 'StarryNight',
                'egg': 'Wolf',
                'text': 'Starry Night Wolf'
            },
            'Wolf-Rainbow': {
                'key': 'Wolf-Rainbow',
                'type': 'premium',
                'potion': 'Rainbow',
                'egg': 'Wolf',
                'text': 'Rainbow Wolf'
            },
            'Wolf-Glass': {
                'key': 'Wolf-Glass',
                'type': 'premium',
                'potion': 'Glass',
                'egg': 'Wolf',
                'text': 'Glass Wolf'
            },
            'Wolf-Glow': {
                'key': 'Wolf-Glow',
                'type': 'premium',
                'potion': 'Glow',
                'egg': 'Wolf',
                'text': 'Glow-in-the-Dark Wolf'
            },
            'Wolf-Frost': {
                'key': 'Wolf-Frost',
                'type': 'premium',
                'potion': 'Frost',
                'egg': 'Wolf',
                'text': 'Frost Wolf'
            },
            'Wolf-IcySnow': {
                'key': 'Wolf-IcySnow',
                'type': 'premium',
                'potion': 'IcySnow',
                'egg': 'Wolf',
                'text': 'Icy Snow Wolf'
            },
            'Wolf-RoseQuartz': {
                'key': 'Wolf-RoseQuartz',
                'type': 'premium',
                'potion': 'RoseQuartz',
                'egg': 'Wolf',
                'text': 'Rose Quartz Wolf'
            },
            'Wolf-Celestial': {
                'key': 'Wolf-Celestial',
                'type': 'premium',
                'potion': 'Celestial',
                'egg': 'Wolf',
                'text': 'Celestial Wolf'
            },
            'Wolf-Sunshine': {
                'key': 'Wolf-Sunshine',
                'type': 'premium',
                'potion': 'Sunshine',
                'egg': 'Wolf',
                'text': 'Sunshine Wolf'
            },
            'Wolf-Bronze': {
                'key': 'Wolf-Bronze',
                'type': 'premium',
                'potion': 'Bronze',
                'egg': 'Wolf',
                'text': 'Bronze Wolf'
            },
            'Wolf-Watery': {
                'key': 'Wolf-Watery',
                'type': 'premium',
                'potion': 'Watery',
                'egg': 'Wolf',
                'text': 'Watery Wolf'
            },
            'Wolf-Silver': {
                'key': 'Wolf-Silver',
                'type': 'premium',
                'potion': 'Silver',
                'egg': 'Wolf',
                'text': 'Silver Wolf'
            },
            'Wolf-Shadow': {
                'key': 'Wolf-Shadow',
                'type': 'premium',
                'potion': 'Shadow',
                'egg': 'Wolf',
                'text': 'Shadow Wolf'
            },
            'Wolf-Amber': {
                'key': 'Wolf-Amber',
                'type': 'premium',
                'potion': 'Amber',
                'egg': 'Wolf',
                'text': 'Amber Wolf'
            },
            'Wolf-Aurora': {
                'key': 'Wolf-Aurora',
                'type': 'premium',
                'potion': 'Aurora',
                'egg': 'Wolf',
                'text': 'Aurora Wolf'
            },
            'Wolf-Ruby': {
                'key': 'Wolf-Ruby',
                'type': 'premium',
                'potion': 'Ruby',
                'egg': 'Wolf',
                'text': 'Ruby Wolf'
            },
            'Wolf-BirchBark': {
                'key': 'Wolf-BirchBark',
                'type': 'premium',
                'potion': 'BirchBark',
                'egg': 'Wolf',
                'text': 'Birch Bark Wolf'
            },
            'Wolf-Fluorite': {
                'key': 'Wolf-Fluorite',
                'type': 'premium',
                'potion': 'Fluorite',
                'egg': 'Wolf',
                'text': 'Fluorite Wolf'
            },
            'Wolf-SandSculpture': {
                'key': 'Wolf-SandSculpture',
                'type': 'premium',
                'potion': 'SandSculpture',
                'egg': 'Wolf',
                'text': 'Sand Sculpture Wolf'
            },
            'Wolf-Windup': {
                'key': 'Wolf-Windup',
                'type': 'premium',
                'potion': 'Windup',
                'egg': 'Wolf',
                'text': 'Wind-Up Wolf'
            },
            'Wolf-Turquoise': {
                'key': 'Wolf-Turquoise',
                'type': 'premium',
                'potion': 'Turquoise',
                'egg': 'Wolf',
                'text': 'Turquoise Wolf'
            },
            'Wolf-Vampire': {
                'key': 'Wolf-Vampire',
                'type': 'premium',
                'potion': 'Vampire',
                'egg': 'Wolf',
                'text': 'Vampire Wolf'
            },
            'Wolf-AutumnLeaf': {
                'key': 'Wolf-AutumnLeaf',
                'type': 'premium',
                'potion': 'AutumnLeaf',
                'egg': 'Wolf',
                'text': 'Autumn Leaf Wolf'
            },
            'Wolf-BlackPearl': {
                'key': 'Wolf-BlackPearl',
                'type': 'premium',
                'potion': 'BlackPearl',
                'egg': 'Wolf',
                'text': 'Black Pearl Wolf'
            },
            'Wolf-StainedGlass': {
                'key': 'Wolf-StainedGlass',
                'type': 'premium',
                'potion': 'StainedGlass',
                'egg': 'Wolf',
                'text': 'Stained Glass Wolf'
            },
            'Wolf-PolkaDot': {
                'key': 'Wolf-PolkaDot',
                'type': 'premium',
                'potion': 'PolkaDot',
                'egg': 'Wolf',
                'text': 'Polka Dot Wolf'
            },
            'Wolf-MossyStone': {
                'key': 'Wolf-MossyStone',
                'type': 'premium',
                'potion': 'MossyStone',
                'egg': 'Wolf',
                'text': 'Mossy Stone Wolf'
            },
            'Wolf-Sunset': {
                'key': 'Wolf-Sunset',
                'type': 'premium',
                'potion': 'Sunset',
                'egg': 'Wolf',
                'text': 'Sunset Wolf'
            },
            'Wolf-Moonglow': {
                'key': 'Wolf-Moonglow',
                'type': 'premium',
                'potion': 'Moonglow',
                'egg': 'Wolf',
                'text': 'Moonglow Wolf'
            },
            'Wolf-SolarSystem': {
                'key': 'Wolf-SolarSystem',
                'type': 'premium',
                'potion': 'SolarSystem',
                'egg': 'Wolf',
                'text': 'Solar System Wolf'
            },
            'TigerCub-RoyalPurple': {
                'key': 'TigerCub-RoyalPurple',
                'type': 'premium',
                'potion': 'RoyalPurple',
                'egg': 'TigerCub',
                'text': 'Royal Purple Tiger Cub'
            },
            'TigerCub-Cupid': {
                'key': 'TigerCub-Cupid',
                'type': 'premium',
                'potion': 'Cupid',
                'egg': 'TigerCub',
                'text': 'Cupid Tiger Cub'
            },
            'TigerCub-Shimmer': {
                'key': 'TigerCub-Shimmer',
                'type': 'premium',
                'potion': 'Shimmer',
                'egg': 'TigerCub',
                'text': 'Shimmer Tiger Cub'
            },
            'TigerCub-Fairy': {
                'key': 'TigerCub-Fairy',
                'type': 'premium',
                'potion': 'Fairy',
                'egg': 'TigerCub',
                'text': 'Fairy Tiger Cub'
            },
            'TigerCub-Floral': {
                'key': 'TigerCub-Floral',
                'type': 'premium',
                'potion': 'Floral',
                'egg': 'TigerCub',
                'text': 'Floral Tiger Cub'
            },
            'TigerCub-Aquatic': {
                'key': 'TigerCub-Aquatic',
                'type': 'premium',
                'potion': 'Aquatic',
                'egg': 'TigerCub',
                'text': 'Aquatic Tiger Cub'
            },
            'TigerCub-Ember': {
                'key': 'TigerCub-Ember',
                'type': 'premium',
                'potion': 'Ember',
                'egg': 'TigerCub',
                'text': 'Ember Tiger Cub'
            },
            'TigerCub-Thunderstorm': {
                'key': 'TigerCub-Thunderstorm',
                'type': 'premium',
                'potion': 'Thunderstorm',
                'egg': 'TigerCub',
                'text': 'Thunderstorm Tiger Cub'
            },
            'TigerCub-Spooky': {
                'key': 'TigerCub-Spooky',
                'type': 'premium',
                'potion': 'Spooky',
                'egg': 'TigerCub',
                'text': 'Spooky Tiger Cub'
            },
            'TigerCub-Ghost': {
                'key': 'TigerCub-Ghost',
                'type': 'premium',
                'potion': 'Ghost',
                'egg': 'TigerCub',
                'text': 'Ghost Tiger Cub'
            },
            'TigerCub-Holly': {
                'key': 'TigerCub-Holly',
                'type': 'premium',
                'potion': 'Holly',
                'egg': 'TigerCub',
                'text': 'Holly Tiger Cub'
            },
            'TigerCub-Peppermint': {
                'key': 'TigerCub-Peppermint',
                'type': 'premium',
                'potion': 'Peppermint',
                'egg': 'TigerCub',
                'text': 'Peppermint Tiger Cub'
            },
            'TigerCub-StarryNight': {
                'key': 'TigerCub-StarryNight',
                'type': 'premium',
                'potion': 'StarryNight',
                'egg': 'TigerCub',
                'text': 'Starry Night Tiger Cub'
            },
            'TigerCub-Rainbow': {
                'key': 'TigerCub-Rainbow',
                'type': 'premium',
                'potion': 'Rainbow',
                'egg': 'TigerCub',
                'text': 'Rainbow Tiger Cub'
            },
            'TigerCub-Glass': {
                'key': 'TigerCub-Glass',
                'type': 'premium',
                'potion': 'Glass',
                'egg': 'TigerCub',
                'text': 'Glass Tiger Cub'
            },
            'TigerCub-Glow': {
                'key': 'TigerCub-Glow',
                'type': 'premium',
                'potion': 'Glow',
                'egg': 'TigerCub',
                'text': 'Glow-in-the-Dark Tiger Cub'
            },
            'TigerCub-Frost': {
                'key': 'TigerCub-Frost',
                'type': 'premium',
                'potion': 'Frost',
                'egg': 'TigerCub',
                'text': 'Frost Tiger Cub'
            },
            'TigerCub-IcySnow': {
                'key': 'TigerCub-IcySnow',
                'type': 'premium',
                'potion': 'IcySnow',
                'egg': 'TigerCub',
                'text': 'Icy Snow Tiger Cub'
            },
            'TigerCub-RoseQuartz': {
                'key': 'TigerCub-RoseQuartz',
                'type': 'premium',
                'potion': 'RoseQuartz',
                'egg': 'TigerCub',
                'text': 'Rose Quartz Tiger Cub'
            },
            'TigerCub-Celestial': {
                'key': 'TigerCub-Celestial',
                'type': 'premium',
                'potion': 'Celestial',
                'egg': 'TigerCub',
                'text': 'Celestial Tiger Cub'
            },
            'TigerCub-Sunshine': {
                'key': 'TigerCub-Sunshine',
                'type': 'premium',
                'potion': 'Sunshine',
                'egg': 'TigerCub',
                'text': 'Sunshine Tiger Cub'
            },
            'TigerCub-Bronze': {
                'key': 'TigerCub-Bronze',
                'type': 'premium',
                'potion': 'Bronze',
                'egg': 'TigerCub',
                'text': 'Bronze Tiger Cub'
            },
            'TigerCub-Watery': {
                'key': 'TigerCub-Watery',
                'type': 'premium',
                'potion': 'Watery',
                'egg': 'TigerCub',
                'text': 'Watery Tiger Cub'
            },
            'TigerCub-Silver': {
                'key': 'TigerCub-Silver',
                'type': 'premium',
                'potion': 'Silver',
                'egg': 'TigerCub',
                'text': 'Silver Tiger Cub'
            },
            'TigerCub-Shadow': {
                'key': 'TigerCub-Shadow',
                'type': 'premium',
                'potion': 'Shadow',
                'egg': 'TigerCub',
                'text': 'Shadow Tiger Cub'
            },
            'TigerCub-Amber': {
                'key': 'TigerCub-Amber',
                'type': 'premium',
                'potion': 'Amber',
                'egg': 'TigerCub',
                'text': 'Amber Tiger Cub'
            },
            'TigerCub-Aurora': {
                'key': 'TigerCub-Aurora',
                'type': 'premium',
                'potion': 'Aurora',
                'egg': 'TigerCub',
                'text': 'Aurora Tiger Cub'
            },
            'TigerCub-Ruby': {
                'key': 'TigerCub-Ruby',
                'type': 'premium',
                'potion': 'Ruby',
                'egg': 'TigerCub',
                'text': 'Ruby Tiger Cub'
            },
            'TigerCub-BirchBark': {
                'key': 'TigerCub-BirchBark',
                'type': 'premium',
                'potion': 'BirchBark',
                'egg': 'TigerCub',
                'text': 'Birch Bark Tiger Cub'
            },
            'TigerCub-Fluorite': {
                'key': 'TigerCub-Fluorite',
                'type': 'premium',
                'potion': 'Fluorite',
                'egg': 'TigerCub',
                'text': 'Fluorite Tiger Cub'
            },
            'TigerCub-SandSculpture': {
                'key': 'TigerCub-SandSculpture',
                'type': 'premium',
                'potion': 'SandSculpture',
                'egg': 'TigerCub',
                'text': 'Sand Sculpture Tiger Cub'
            },
            'TigerCub-Windup': {
                'key': 'TigerCub-Windup',
                'type': 'premium',
                'potion': 'Windup',
                'egg': 'TigerCub',
                'text': 'Wind-Up Tiger Cub'
            },
            'TigerCub-Turquoise': {
                'key': 'TigerCub-Turquoise',
                'type': 'premium',
                'potion': 'Turquoise',
                'egg': 'TigerCub',
                'text': 'Turquoise Tiger Cub'
            },
            'TigerCub-Vampire': {
                'key': 'TigerCub-Vampire',
                'type': 'premium',
                'potion': 'Vampire',
                'egg': 'TigerCub',
                'text': 'Vampire Tiger Cub'
            },
            'TigerCub-AutumnLeaf': {
                'key': 'TigerCub-AutumnLeaf',
                'type': 'premium',
                'potion': 'AutumnLeaf',
                'egg': 'TigerCub',
                'text': 'Autumn Leaf Tiger Cub'
            },
            'TigerCub-BlackPearl': {
                'key': 'TigerCub-BlackPearl',
                'type': 'premium',
                'potion': 'BlackPearl',
                'egg': 'TigerCub',
                'text': 'Black Pearl Tiger Cub'
            },
            'TigerCub-StainedGlass': {
                'key': 'TigerCub-StainedGlass',
                'type': 'premium',
                'potion': 'StainedGlass',
                'egg': 'TigerCub',
                'text': 'Stained Glass Tiger Cub'
            },
            'TigerCub-PolkaDot': {
                'key': 'TigerCub-PolkaDot',
                'type': 'premium',
                'potion': 'PolkaDot',
                'egg': 'TigerCub',
                'text': 'Polka Dot Tiger Cub'
            },
            'TigerCub-MossyStone': {
                'key': 'TigerCub-MossyStone',
                'type': 'premium',
                'potion': 'MossyStone',
                'egg': 'TigerCub',
                'text': 'Mossy Stone Tiger Cub'
            },
            'TigerCub-Sunset': {
                'key': 'TigerCub-Sunset',
                'type': 'premium',
                'potion': 'Sunset',
                'egg': 'TigerCub',
                'text': 'Sunset Tiger Cub'
            },
            'TigerCub-Moonglow': {
                'key': 'TigerCub-Moonglow',
                'type': 'premium',
                'potion': 'Moonglow',
                'egg': 'TigerCub',
                'text': 'Moonglow Tiger Cub'
            },
            'TigerCub-SolarSystem': {
                'key': 'TigerCub-SolarSystem',
                'type': 'premium',
                'potion': 'SolarSystem',
                'egg': 'TigerCub',
                'text': 'Solar System Tiger Cub'
            },
            'PandaCub-RoyalPurple': {
                'key': 'PandaCub-RoyalPurple',
                'type': 'premium',
                'potion': 'RoyalPurple',
                'egg': 'PandaCub',
                'text': 'Royal Purple Panda Cub'
            },
            'PandaCub-Cupid': {
                'key': 'PandaCub-Cupid',
                'type': 'premium',
                'potion': 'Cupid',
                'egg': 'PandaCub',
                'text': 'Cupid Panda Cub'
            },
            'PandaCub-Shimmer': {
                'key': 'PandaCub-Shimmer',
                'type': 'premium',
                'potion': 'Shimmer',
                'egg': 'PandaCub',
                'text': 'Shimmer Panda Cub'
            },
            'PandaCub-Fairy': {
                'key': 'PandaCub-Fairy',
                'type': 'premium',
                'potion': 'Fairy',
                'egg': 'PandaCub',
                'text': 'Fairy Panda Cub'
            },
            'PandaCub-Floral': {
                'key': 'PandaCub-Floral',
                'type': 'premium',
                'potion': 'Floral',
                'egg': 'PandaCub',
                'text': 'Floral Panda Cub'
            },
            'PandaCub-Aquatic': {
                'key': 'PandaCub-Aquatic',
                'type': 'premium',
                'potion': 'Aquatic',
                'egg': 'PandaCub',
                'text': 'Aquatic Panda Cub'
            },
            'PandaCub-Ember': {
                'key': 'PandaCub-Ember',
                'type': 'premium',
                'potion': 'Ember',
                'egg': 'PandaCub',
                'text': 'Ember Panda Cub'
            },
            'PandaCub-Thunderstorm': {
                'key': 'PandaCub-Thunderstorm',
                'type': 'premium',
                'potion': 'Thunderstorm',
                'egg': 'PandaCub',
                'text': 'Thunderstorm Panda Cub'
            },
            'PandaCub-Spooky': {
                'key': 'PandaCub-Spooky',
                'type': 'premium',
                'potion': 'Spooky',
                'egg': 'PandaCub',
                'text': 'Spooky Panda Cub'
            },
            'PandaCub-Ghost': {
                'key': 'PandaCub-Ghost',
                'type': 'premium',
                'potion': 'Ghost',
                'egg': 'PandaCub',
                'text': 'Ghost Panda Cub'
            },
            'PandaCub-Holly': {
                'key': 'PandaCub-Holly',
                'type': 'premium',
                'potion': 'Holly',
                'egg': 'PandaCub',
                'text': 'Holly Panda Cub'
            },
            'PandaCub-Peppermint': {
                'key': 'PandaCub-Peppermint',
                'type': 'premium',
                'potion': 'Peppermint',
                'egg': 'PandaCub',
                'text': 'Peppermint Panda Cub'
            },
            'PandaCub-StarryNight': {
                'key': 'PandaCub-StarryNight',
                'type': 'premium',
                'potion': 'StarryNight',
                'egg': 'PandaCub',
                'text': 'Starry Night Panda Cub'
            },
            'PandaCub-Rainbow': {
                'key': 'PandaCub-Rainbow',
                'type': 'premium',
                'potion': 'Rainbow',
                'egg': 'PandaCub',
                'text': 'Rainbow Panda Cub'
            },
            'PandaCub-Glass': {
                'key': 'PandaCub-Glass',
                'type': 'premium',
                'potion': 'Glass',
                'egg': 'PandaCub',
                'text': 'Glass Panda Cub'
            },
            'PandaCub-Glow': {
                'key': 'PandaCub-Glow',
                'type': 'premium',
                'potion': 'Glow',
                'egg': 'PandaCub',
                'text': 'Glow-in-the-Dark Panda Cub'
            },
            'PandaCub-Frost': {
                'key': 'PandaCub-Frost',
                'type': 'premium',
                'potion': 'Frost',
                'egg': 'PandaCub',
                'text': 'Frost Panda Cub'
            },
            'PandaCub-IcySnow': {
                'key': 'PandaCub-IcySnow',
                'type': 'premium',
                'potion': 'IcySnow',
                'egg': 'PandaCub',
                'text': 'Icy Snow Panda Cub'
            },
            'PandaCub-RoseQuartz': {
                'key': 'PandaCub-RoseQuartz',
                'type': 'premium',
                'potion': 'RoseQuartz',
                'egg': 'PandaCub',
                'text': 'Rose Quartz Panda Cub'
            },
            'PandaCub-Celestial': {
                'key': 'PandaCub-Celestial',
                'type': 'premium',
                'potion': 'Celestial',
                'egg': 'PandaCub',
                'text': 'Celestial Panda Cub'
            },
            'PandaCub-Sunshine': {
                'key': 'PandaCub-Sunshine',
                'type': 'premium',
                'potion': 'Sunshine',
                'egg': 'PandaCub',
                'text': 'Sunshine Panda Cub'
            },
            'PandaCub-Bronze': {
                'key': 'PandaCub-Bronze',
                'type': 'premium',
                'potion': 'Bronze',
                'egg': 'PandaCub',
                'text': 'Bronze Panda Cub'
            },
            'PandaCub-Watery': {
                'key': 'PandaCub-Watery',
                'type': 'premium',
                'potion': 'Watery',
                'egg': 'PandaCub',
                'text': 'Watery Panda Cub'
            },
            'PandaCub-Silver': {
                'key': 'PandaCub-Silver',
                'type': 'premium',
                'potion': 'Silver',
                'egg': 'PandaCub',
                'text': 'Silver Panda Cub'
            },
            'PandaCub-Shadow': {
                'key': 'PandaCub-Shadow',
                'type': 'premium',
                'potion': 'Shadow',
                'egg': 'PandaCub',
                'text': 'Shadow Panda Cub'
            },
            'PandaCub-Amber': {
                'key': 'PandaCub-Amber',
                'type': 'premium',
                'potion': 'Amber',
                'egg': 'PandaCub',
                'text': 'Amber Panda Cub'
            },
            'PandaCub-Aurora': {
                'key': 'PandaCub-Aurora',
                'type': 'premium',
                'potion': 'Aurora',
                'egg': 'PandaCub',
                'text': 'Aurora Panda Cub'
            },
            'PandaCub-Ruby': {
                'key': 'PandaCub-Ruby',
                'type': 'premium',
                'potion': 'Ruby',
                'egg': 'PandaCub',
                'text': 'Ruby Panda Cub'
            },
            'PandaCub-BirchBark': {
                'key': 'PandaCub-BirchBark',
                'type': 'premium',
                'potion': 'BirchBark',
                'egg': 'PandaCub',
                'text': 'Birch Bark Panda Cub'
            },
            'PandaCub-Fluorite': {
                'key': 'PandaCub-Fluorite',
                'type': 'premium',
                'potion': 'Fluorite',
                'egg': 'PandaCub',
                'text': 'Fluorite Panda Cub'
            },
            'PandaCub-SandSculpture': {
                'key': 'PandaCub-SandSculpture',
                'type': 'premium',
                'potion': 'SandSculpture',
                'egg': 'PandaCub',
                'text': 'Sand Sculpture Panda Cub'
            },
            'PandaCub-Windup': {
                'key': 'PandaCub-Windup',
                'type': 'premium',
                'potion': 'Windup',
                'egg': 'PandaCub',
                'text': 'Wind-Up Panda Cub'
            },
            'PandaCub-Turquoise': {
                'key': 'PandaCub-Turquoise',
                'type': 'premium',
                'potion': 'Turquoise',
                'egg': 'PandaCub',
                'text': 'Turquoise Panda Cub'
            },
            'PandaCub-Vampire': {
                'key': 'PandaCub-Vampire',
                'type': 'premium',
                'potion': 'Vampire',
                'egg': 'PandaCub',
                'text': 'Vampire Panda Cub'
            },
            'PandaCub-AutumnLeaf': {
                'key': 'PandaCub-AutumnLeaf',
                'type': 'premium',
                'potion': 'AutumnLeaf',
                'egg': 'PandaCub',
                'text': 'Autumn Leaf Panda Cub'
            },
            'PandaCub-BlackPearl': {
                'key': 'PandaCub-BlackPearl',
                'type': 'premium',
                'potion': 'BlackPearl',
                'egg': 'PandaCub',
                'text': 'Black Pearl Panda Cub'
            },
            'PandaCub-StainedGlass': {
                'key': 'PandaCub-StainedGlass',
                'type': 'premium',
                'potion': 'StainedGlass',
                'egg': 'PandaCub',
                'text': 'Stained Glass Panda Cub'
            },
            'PandaCub-PolkaDot': {
                'key': 'PandaCub-PolkaDot',
                'type': 'premium',
                'potion': 'PolkaDot',
                'egg': 'PandaCub',
                'text': 'Polka Dot Panda Cub'
            },
            'PandaCub-MossyStone': {
                'key': 'PandaCub-MossyStone',
                'type': 'premium',
                'potion': 'MossyStone',
                'egg': 'PandaCub',
                'text': 'Mossy Stone Panda Cub'
            },
            'PandaCub-Sunset': {
                'key': 'PandaCub-Sunset',
                'type': 'premium',
                'potion': 'Sunset',
                'egg': 'PandaCub',
                'text': 'Sunset Panda Cub'
            },
            'PandaCub-Moonglow': {
                'key': 'PandaCub-Moonglow',
                'type': 'premium',
                'potion': 'Moonglow',
                'egg': 'PandaCub',
                'text': 'Moonglow Panda Cub'
            },
            'PandaCub-SolarSystem': {
                'key': 'PandaCub-SolarSystem',
                'type': 'premium',
                'potion': 'SolarSystem',
                'egg': 'PandaCub',
                'text': 'Solar System Panda Cub'
            },
            'LionCub-RoyalPurple': {
                'key': 'LionCub-RoyalPurple',
                'type': 'premium',
                'potion': 'RoyalPurple',
                'egg': 'LionCub',
                'text': 'Royal Purple Lion Cub'
            },
            'LionCub-Cupid': {
                'key': 'LionCub-Cupid',
                'type': 'premium',
                'potion': 'Cupid',
                'egg': 'LionCub',
                'text': 'Cupid Lion Cub'
            },
            'LionCub-Shimmer': {
                'key': 'LionCub-Shimmer',
                'type': 'premium',
                'potion': 'Shimmer',
                'egg': 'LionCub',
                'text': 'Shimmer Lion Cub'
            },
            'LionCub-Fairy': {
                'key': 'LionCub-Fairy',
                'type': 'premium',
                'potion': 'Fairy',
                'egg': 'LionCub',
                'text': 'Fairy Lion Cub'
            },
            'LionCub-Floral': {
                'key': 'LionCub-Floral',
                'type': 'premium',
                'potion': 'Floral',
                'egg': 'LionCub',
                'text': 'Floral Lion Cub'
            },
            'LionCub-Aquatic': {
                'key': 'LionCub-Aquatic',
                'type': 'premium',
                'potion': 'Aquatic',
                'egg': 'LionCub',
                'text': 'Aquatic Lion Cub'
            },
            'LionCub-Ember': {
                'key': 'LionCub-Ember',
                'type': 'premium',
                'potion': 'Ember',
                'egg': 'LionCub',
                'text': 'Ember Lion Cub'
            },
            'LionCub-Thunderstorm': {
                'key': 'LionCub-Thunderstorm',
                'type': 'premium',
                'potion': 'Thunderstorm',
                'egg': 'LionCub',
                'text': 'Thunderstorm Lion Cub'
            },
            'LionCub-Spooky': {
                'key': 'LionCub-Spooky',
                'type': 'premium',
                'potion': 'Spooky',
                'egg': 'LionCub',
                'text': 'Spooky Lion Cub'
            },
            'LionCub-Ghost': {
                'key': 'LionCub-Ghost',
                'type': 'premium',
                'potion': 'Ghost',
                'egg': 'LionCub',
                'text': 'Ghost Lion Cub'
            },
            'LionCub-Holly': {
                'key': 'LionCub-Holly',
                'type': 'premium',
                'potion': 'Holly',
                'egg': 'LionCub',
                'text': 'Holly Lion Cub'
            },
            'LionCub-Peppermint': {
                'key': 'LionCub-Peppermint',
                'type': 'premium',
                'potion': 'Peppermint',
                'egg': 'LionCub',
                'text': 'Peppermint Lion Cub'
            },
            'LionCub-StarryNight': {
                'key': 'LionCub-StarryNight',
                'type': 'premium',
                'potion': 'StarryNight',
                'egg': 'LionCub',
                'text': 'Starry Night Lion Cub'
            },
            'LionCub-Rainbow': {
                'key': 'LionCub-Rainbow',
                'type': 'premium',
                'potion': 'Rainbow',
                'egg': 'LionCub',
                'text': 'Rainbow Lion Cub'
            },
            'LionCub-Glass': {
                'key': 'LionCub-Glass',
                'type': 'premium',
                'potion': 'Glass',
                'egg': 'LionCub',
                'text': 'Glass Lion Cub'
            },
            'LionCub-Glow': {
                'key': 'LionCub-Glow',
                'type': 'premium',
                'potion': 'Glow',
                'egg': 'LionCub',
                'text': 'Glow-in-the-Dark Lion Cub'
            },
            'LionCub-Frost': {
                'key': 'LionCub-Frost',
                'type': 'premium',
                'potion': 'Frost',
                'egg': 'LionCub',
                'text': 'Frost Lion Cub'
            },
            'LionCub-IcySnow': {
                'key': 'LionCub-IcySnow',
                'type': 'premium',
                'potion': 'IcySnow',
                'egg': 'LionCub',
                'text': 'Icy Snow Lion Cub'
            },
            'LionCub-RoseQuartz': {
                'key': 'LionCub-RoseQuartz',
                'type': 'premium',
                'potion': 'RoseQuartz',
                'egg': 'LionCub',
                'text': 'Rose Quartz Lion Cub'
            },
            'LionCub-Celestial': {
                'key': 'LionCub-Celestial',
                'type': 'premium',
                'potion': 'Celestial',
                'egg': 'LionCub',
                'text': 'Celestial Lion Cub'
            },
            'LionCub-Sunshine': {
                'key': 'LionCub-Sunshine',
                'type': 'premium',
                'potion': 'Sunshine',
                'egg': 'LionCub',
                'text': 'Sunshine Lion Cub'
            },
            'LionCub-Bronze': {
                'key': 'LionCub-Bronze',
                'type': 'premium',
                'potion': 'Bronze',
                'egg': 'LionCub',
                'text': 'Bronze Lion Cub'
            },
            'LionCub-Watery': {
                'key': 'LionCub-Watery',
                'type': 'premium',
                'potion': 'Watery',
                'egg': 'LionCub',
                'text': 'Watery Lion Cub'
            },
            'LionCub-Silver': {
                'key': 'LionCub-Silver',
                'type': 'premium',
                'potion': 'Silver',
                'egg': 'LionCub',
                'text': 'Silver Lion Cub'
            },
            'LionCub-Shadow': {
                'key': 'LionCub-Shadow',
                'type': 'premium',
                'potion': 'Shadow',
                'egg': 'LionCub',
                'text': 'Shadow Lion Cub'
            },
            'LionCub-Amber': {
                'key': 'LionCub-Amber',
                'type': 'premium',
                'potion': 'Amber',
                'egg': 'LionCub',
                'text': 'Amber Lion Cub'
            },
            'LionCub-Aurora': {
                'key': 'LionCub-Aurora',
                'type': 'premium',
                'potion': 'Aurora',
                'egg': 'LionCub',
                'text': 'Aurora Lion Cub'
            },
            'LionCub-Ruby': {
                'key': 'LionCub-Ruby',
                'type': 'premium',
                'potion': 'Ruby',
                'egg': 'LionCub',
                'text': 'Ruby Lion Cub'
            },
            'LionCub-BirchBark': {
                'key': 'LionCub-BirchBark',
                'type': 'premium',
                'potion': 'BirchBark',
                'egg': 'LionCub',
                'text': 'Birch Bark Lion Cub'
            },
            'LionCub-Fluorite': {
                'key': 'LionCub-Fluorite',
                'type': 'premium',
                'potion': 'Fluorite',
                'egg': 'LionCub',
                'text': 'Fluorite Lion Cub'
            },
            'LionCub-SandSculpture': {
                'key': 'LionCub-SandSculpture',
                'type': 'premium',
                'potion': 'SandSculpture',
                'egg': 'LionCub',
                'text': 'Sand Sculpture Lion Cub'
            },
            'LionCub-Windup': {
                'key': 'LionCub-Windup',
                'type': 'premium',
                'potion': 'Windup',
                'egg': 'LionCub',
                'text': 'Wind-Up Lion Cub'
            },
            'LionCub-Turquoise': {
                'key': 'LionCub-Turquoise',
                'type': 'premium',
                'potion': 'Turquoise',
                'egg': 'LionCub',
                'text': 'Turquoise Lion Cub'
            },
            'LionCub-Vampire': {
                'key': 'LionCub-Vampire',
                'type': 'premium',
                'potion': 'Vampire',
                'egg': 'LionCub',
                'text': 'Vampire Lion Cub'
            },
            'LionCub-AutumnLeaf': {
                'key': 'LionCub-AutumnLeaf',
                'type': 'premium',
                'potion': 'AutumnLeaf',
                'egg': 'LionCub',
                'text': 'Autumn Leaf Lion Cub'
            },
            'LionCub-BlackPearl': {
                'key': 'LionCub-BlackPearl',
                'type': 'premium',
                'potion': 'BlackPearl',
                'egg': 'LionCub',
                'text': 'Black Pearl Lion Cub'
            },
            'LionCub-StainedGlass': {
                'key': 'LionCub-StainedGlass',
                'type': 'premium',
                'potion': 'StainedGlass',
                'egg': 'LionCub',
                'text': 'Stained Glass Lion Cub'
            },
            'LionCub-PolkaDot': {
                'key': 'LionCub-PolkaDot',
                'type': 'premium',
                'potion': 'PolkaDot',
                'egg': 'LionCub',
                'text': 'Polka Dot Lion Cub'
            },
            'LionCub-MossyStone': {
                'key': 'LionCub-MossyStone',
                'type': 'premium',
                'potion': 'MossyStone',
                'egg': 'LionCub',
                'text': 'Mossy Stone Lion Cub'
            },
            'LionCub-Sunset': {
                'key': 'LionCub-Sunset',
                'type': 'premium',
                'potion': 'Sunset',
                'egg': 'LionCub',
                'text': 'Sunset Lion Cub'
            },
            'LionCub-Moonglow': {
                'key': 'LionCub-Moonglow',
                'type': 'premium',
                'potion': 'Moonglow',
                'egg': 'LionCub',
                'text': 'Moonglow Lion Cub'
            },
            'LionCub-SolarSystem': {
                'key': 'LionCub-SolarSystem',
                'type': 'premium',
                'potion': 'SolarSystem',
                'egg': 'LionCub',
                'text': 'Solar System Lion Cub'
            },
            'Fox-RoyalPurple': {
                'key': 'Fox-RoyalPurple',
                'type': 'premium',
                'potion': 'RoyalPurple',
                'egg': 'Fox',
                'text': 'Royal Purple Fox'
            },
            'Fox-Cupid': {
                'key': 'Fox-Cupid',
                'type': 'premium',
                'potion': 'Cupid',
                'egg': 'Fox',
                'text': 'Cupid Fox'
            },
            'Fox-Shimmer': {
                'key': 'Fox-Shimmer',
                'type': 'premium',
                'potion': 'Shimmer',
                'egg': 'Fox',
                'text': 'Shimmer Fox'
            },
            'Fox-Fairy': {
                'key': 'Fox-Fairy',
                'type': 'premium',
                'potion': 'Fairy',
                'egg': 'Fox',
                'text': 'Fairy Fox'
            },
            'Fox-Floral': {
                'key': 'Fox-Floral',
                'type': 'premium',
                'potion': 'Floral',
                'egg': 'Fox',
                'text': 'Floral Fox'
            },
            'Fox-Aquatic': {
                'key': 'Fox-Aquatic',
                'type': 'premium',
                'potion': 'Aquatic',
                'egg': 'Fox',
                'text': 'Aquatic Fox'
            },
            'Fox-Ember': {
                'key': 'Fox-Ember',
                'type': 'premium',
                'potion': 'Ember',
                'egg': 'Fox',
                'text': 'Ember Fox'
            },
            'Fox-Thunderstorm': {
                'key': 'Fox-Thunderstorm',
                'type': 'premium',
                'potion': 'Thunderstorm',
                'egg': 'Fox',
                'text': 'Thunderstorm Fox'
            },
            'Fox-Spooky': {
                'key': 'Fox-Spooky',
                'type': 'premium',
                'potion': 'Spooky',
                'egg': 'Fox',
                'text': 'Spooky Fox'
            },
            'Fox-Ghost': {
                'key': 'Fox-Ghost',
                'type': 'premium',
                'potion': 'Ghost',
                'egg': 'Fox',
                'text': 'Ghost Fox'
            },
            'Fox-Holly': {
                'key': 'Fox-Holly',
                'type': 'premium',
                'potion': 'Holly',
                'egg': 'Fox',
                'text': 'Holly Fox'
            },
            'Fox-Peppermint': {
                'key': 'Fox-Peppermint',
                'type': 'premium',
                'potion': 'Peppermint',
                'egg': 'Fox',
                'text': 'Peppermint Fox'
            },
            'Fox-StarryNight': {
                'key': 'Fox-StarryNight',
                'type': 'premium',
                'potion': 'StarryNight',
                'egg': 'Fox',
                'text': 'Starry Night Fox'
            },
            'Fox-Rainbow': {
                'key': 'Fox-Rainbow',
                'type': 'premium',
                'potion': 'Rainbow',
                'egg': 'Fox',
                'text': 'Rainbow Fox'
            },
            'Fox-Glass': {
                'key': 'Fox-Glass',
                'type': 'premium',
                'potion': 'Glass',
                'egg': 'Fox',
                'text': 'Glass Fox'
            },
            'Fox-Glow': {
                'key': 'Fox-Glow',
                'type': 'premium',
                'potion': 'Glow',
                'egg': 'Fox',
                'text': 'Glow-in-the-Dark Fox'
            },
            'Fox-Frost': {
                'key': 'Fox-Frost',
                'type': 'premium',
                'potion': 'Frost',
                'egg': 'Fox',
                'text': 'Frost Fox'
            },
            'Fox-IcySnow': {
                'key': 'Fox-IcySnow',
                'type': 'premium',
                'potion': 'IcySnow',
                'egg': 'Fox',
                'text': 'Icy Snow Fox'
            },
            'Fox-RoseQuartz': {
                'key': 'Fox-RoseQuartz',
                'type': 'premium',
                'potion': 'RoseQuartz',
                'egg': 'Fox',
                'text': 'Rose Quartz Fox'
            },
            'Fox-Celestial': {
                'key': 'Fox-Celestial',
                'type': 'premium',
                'potion': 'Celestial',
                'egg': 'Fox',
                'text': 'Celestial Fox'
            },
            'Fox-Sunshine': {
                'key': 'Fox-Sunshine',
                'type': 'premium',
                'potion': 'Sunshine',
                'egg': 'Fox',
                'text': 'Sunshine Fox'
            },
            'Fox-Bronze': {
                'key': 'Fox-Bronze',
                'type': 'premium',
                'potion': 'Bronze',
                'egg': 'Fox',
                'text': 'Bronze Fox'
            },
            'Fox-Watery': {
                'key': 'Fox-Watery',
                'type': 'premium',
                'potion': 'Watery',
                'egg': 'Fox',
                'text': 'Watery Fox'
            },
            'Fox-Silver': {
                'key': 'Fox-Silver',
                'type': 'premium',
                'potion': 'Silver',
                'egg': 'Fox',
                'text': 'Silver Fox'
            },
            'Fox-Shadow': {
                'key': 'Fox-Shadow',
                'type': 'premium',
                'potion': 'Shadow',
                'egg': 'Fox',
                'text': 'Shadow Fox'
            },
            'Fox-Amber': {
                'key': 'Fox-Amber',
                'type': 'premium',
                'potion': 'Amber',
                'egg': 'Fox',
                'text': 'Amber Fox'
            },
            'Fox-Aurora': {
                'key': 'Fox-Aurora',
                'type': 'premium',
                'potion': 'Aurora',
                'egg': 'Fox',
                'text': 'Aurora Fox'
            },
            'Fox-Ruby': {
                'key': 'Fox-Ruby',
                'type': 'premium',
                'potion': 'Ruby',
                'egg': 'Fox',
                'text': 'Ruby Fox'
            },
            'Fox-BirchBark': {
                'key': 'Fox-BirchBark',
                'type': 'premium',
                'potion': 'BirchBark',
                'egg': 'Fox',
                'text': 'Birch Bark Fox'
            },
            'Fox-Fluorite': {
                'key': 'Fox-Fluorite',
                'type': 'premium',
                'potion': 'Fluorite',
                'egg': 'Fox',
                'text': 'Fluorite Fox'
            },
            'Fox-SandSculpture': {
                'key': 'Fox-SandSculpture',
                'type': 'premium',
                'potion': 'SandSculpture',
                'egg': 'Fox',
                'text': 'Sand Sculpture Fox'
            },
            'Fox-Windup': {
                'key': 'Fox-Windup',
                'type': 'premium',
                'potion': 'Windup',
                'egg': 'Fox',
                'text': 'Wind-Up Fox'
            },
            'Fox-Turquoise': {
                'key': 'Fox-Turquoise',
                'type': 'premium',
                'potion': 'Turquoise',
                'egg': 'Fox',
                'text': 'Turquoise Fox'
            },
            'Fox-Vampire': {
                'key': 'Fox-Vampire',
                'type': 'premium',
                'potion': 'Vampire',
                'egg': 'Fox',
                'text': 'Vampire Fox'
            },
            'Fox-AutumnLeaf': {
                'key': 'Fox-AutumnLeaf',
                'type': 'premium',
                'potion': 'AutumnLeaf',
                'egg': 'Fox',
                'text': 'Autumn Leaf Fox'
            },
            'Fox-BlackPearl': {
                'key': 'Fox-BlackPearl',
                'type': 'premium',
                'potion': 'BlackPearl',
                'egg': 'Fox',
                'text': 'Black Pearl Fox'
            },
            'Fox-StainedGlass': {
                'key': 'Fox-StainedGlass',
                'type': 'premium',
                'potion': 'StainedGlass',
                'egg': 'Fox',
                'text': 'Stained Glass Fox'
            },
            'Fox-PolkaDot': {
                'key': 'Fox-PolkaDot',
                'type': 'premium',
                'potion': 'PolkaDot',
                'egg': 'Fox',
                'text': 'Polka Dot Fox'
            },
            'Fox-MossyStone': {
                'key': 'Fox-MossyStone',
                'type': 'premium',
                'potion': 'MossyStone',
                'egg': 'Fox',
                'text': 'Mossy Stone Fox'
            },
            'Fox-Sunset': {
                'key': 'Fox-Sunset',
                'type': 'premium',
                'potion': 'Sunset',
                'egg': 'Fox',
                'text': 'Sunset Fox'
            },
            'Fox-Moonglow': {
                'key': 'Fox-Moonglow',
                'type': 'premium',
                'potion': 'Moonglow',
                'egg': 'Fox',
                'text': 'Moonglow Fox'
            },
            'Fox-SolarSystem': {
                'key': 'Fox-SolarSystem',
                'type': 'premium',
                'potion': 'SolarSystem',
                'egg': 'Fox',
                'text': 'Solar System Fox'
            },
            'FlyingPig-RoyalPurple': {
                'key': 'FlyingPig-RoyalPurple',
                'type': 'premium',
                'potion': 'RoyalPurple',
                'egg': 'FlyingPig',
                'text': 'Royal Purple Flying Pig'
            },
            'FlyingPig-Cupid': {
                'key': 'FlyingPig-Cupid',
                'type': 'premium',
                'potion': 'Cupid',
                'egg': 'FlyingPig',
                'text': 'Cupid Flying Pig'
            },
            'FlyingPig-Shimmer': {
                'key': 'FlyingPig-Shimmer',
                'type': 'premium',
                'potion': 'Shimmer',
                'egg': 'FlyingPig',
                'text': 'Shimmer Flying Pig'
            },
            'FlyingPig-Fairy': {
                'key': 'FlyingPig-Fairy',
                'type': 'premium',
                'potion': 'Fairy',
                'egg': 'FlyingPig',
                'text': 'Fairy Flying Pig'
            },
            'FlyingPig-Floral': {
                'key': 'FlyingPig-Floral',
                'type': 'premium',
                'potion': 'Floral',
                'egg': 'FlyingPig',
                'text': 'Floral Flying Pig'
            },
            'FlyingPig-Aquatic': {
                'key': 'FlyingPig-Aquatic',
                'type': 'premium',
                'potion': 'Aquatic',
                'egg': 'FlyingPig',
                'text': 'Aquatic Flying Pig'
            },
            'FlyingPig-Ember': {
                'key': 'FlyingPig-Ember',
                'type': 'premium',
                'potion': 'Ember',
                'egg': 'FlyingPig',
                'text': 'Ember Flying Pig'
            },
            'FlyingPig-Thunderstorm': {
                'key': 'FlyingPig-Thunderstorm',
                'type': 'premium',
                'potion': 'Thunderstorm',
                'egg': 'FlyingPig',
                'text': 'Thunderstorm Flying Pig'
            },
            'FlyingPig-Spooky': {
                'key': 'FlyingPig-Spooky',
                'type': 'premium',
                'potion': 'Spooky',
                'egg': 'FlyingPig',
                'text': 'Spooky Flying Pig'
            },
            'FlyingPig-Ghost': {
                'key': 'FlyingPig-Ghost',
                'type': 'premium',
                'potion': 'Ghost',
                'egg': 'FlyingPig',
                'text': 'Ghost Flying Pig'
            },
            'FlyingPig-Holly': {
                'key': 'FlyingPig-Holly',
                'type': 'premium',
                'potion': 'Holly',
                'egg': 'FlyingPig',
                'text': 'Holly Flying Pig'
            },
            'FlyingPig-Peppermint': {
                'key': 'FlyingPig-Peppermint',
                'type': 'premium',
                'potion': 'Peppermint',
                'egg': 'FlyingPig',
                'text': 'Peppermint Flying Pig'
            },
            'FlyingPig-StarryNight': {
                'key': 'FlyingPig-StarryNight',
                'type': 'premium',
                'potion': 'StarryNight',
                'egg': 'FlyingPig',
                'text': 'Starry Night Flying Pig'
            },
            'FlyingPig-Rainbow': {
                'key': 'FlyingPig-Rainbow',
                'type': 'premium',
                'potion': 'Rainbow',
                'egg': 'FlyingPig',
                'text': 'Rainbow Flying Pig'
            },
            'FlyingPig-Glass': {
                'key': 'FlyingPig-Glass',
                'type': 'premium',
                'potion': 'Glass',
                'egg': 'FlyingPig',
                'text': 'Glass Flying Pig'
            },
            'FlyingPig-Glow': {
                'key': 'FlyingPig-Glow',
                'type': 'premium',
                'potion': 'Glow',
                'egg': 'FlyingPig',
                'text': 'Glow-in-the-Dark Flying Pig'
            },
            'FlyingPig-Frost': {
                'key': 'FlyingPig-Frost',
                'type': 'premium',
                'potion': 'Frost',
                'egg': 'FlyingPig',
                'text': 'Frost Flying Pig'
            },
            'FlyingPig-IcySnow': {
                'key': 'FlyingPig-IcySnow',
                'type': 'premium',
                'potion': 'IcySnow',
                'egg': 'FlyingPig',
                'text': 'Icy Snow Flying Pig'
            },
            'FlyingPig-RoseQuartz': {
                'key': 'FlyingPig-RoseQuartz',
                'type': 'premium',
                'potion': 'RoseQuartz',
                'egg': 'FlyingPig',
                'text': 'Rose Quartz Flying Pig'
            },
            'FlyingPig-Celestial': {
                'key': 'FlyingPig-Celestial',
                'type': 'premium',
                'potion': 'Celestial',
                'egg': 'FlyingPig',
                'text': 'Celestial Flying Pig'
            },
            'FlyingPig-Sunshine': {
                'key': 'FlyingPig-Sunshine',
                'type': 'premium',
                'potion': 'Sunshine',
                'egg': 'FlyingPig',
                'text': 'Sunshine Flying Pig'
            },
            'FlyingPig-Bronze': {
                'key': 'FlyingPig-Bronze',
                'type': 'premium',
                'potion': 'Bronze',
                'egg': 'FlyingPig',
                'text': 'Bronze Flying Pig'
            },
            'FlyingPig-Watery': {
                'key': 'FlyingPig-Watery',
                'type': 'premium',
                'potion': 'Watery',
                'egg': 'FlyingPig',
                'text': 'Watery Flying Pig'
            },
            'FlyingPig-Silver': {
                'key': 'FlyingPig-Silver',
                'type': 'premium',
                'potion': 'Silver',
                'egg': 'FlyingPig',
                'text': 'Silver Flying Pig'
            },
            'FlyingPig-Shadow': {
                'key': 'FlyingPig-Shadow',
                'type': 'premium',
                'potion': 'Shadow',
                'egg': 'FlyingPig',
                'text': 'Shadow Flying Pig'
            },
            'FlyingPig-Amber': {
                'key': 'FlyingPig-Amber',
                'type': 'premium',
                'potion': 'Amber',
                'egg': 'FlyingPig',
                'text': 'Amber Flying Pig'
            },
            'FlyingPig-Aurora': {
                'key': 'FlyingPig-Aurora',
                'type': 'premium',
                'potion': 'Aurora',
                'egg': 'FlyingPig',
                'text': 'Aurora Flying Pig'
            },
            'FlyingPig-Ruby': {
                'key': 'FlyingPig-Ruby',
                'type': 'premium',
                'potion': 'Ruby',
                'egg': 'FlyingPig',
                'text': 'Ruby Flying Pig'
            },
            'FlyingPig-BirchBark': {
                'key': 'FlyingPig-BirchBark',
                'type': 'premium',
                'potion': 'BirchBark',
                'egg': 'FlyingPig',
                'text': 'Birch Bark Flying Pig'
            },
            'FlyingPig-Fluorite': {
                'key': 'FlyingPig-Fluorite',
                'type': 'premium',
                'potion': 'Fluorite',
                'egg': 'FlyingPig',
                'text': 'Fluorite Flying Pig'
            },
            'FlyingPig-SandSculpture': {
                'key': 'FlyingPig-SandSculpture',
                'type': 'premium',
                'potion': 'SandSculpture',
                'egg': 'FlyingPig',
                'text': 'Sand Sculpture Flying Pig'
            },
            'FlyingPig-Windup': {
                'key': 'FlyingPig-Windup',
                'type': 'premium',
                'potion': 'Windup',
                'egg': 'FlyingPig',
                'text': 'Wind-Up Flying Pig'
            },
            'FlyingPig-Turquoise': {
                'key': 'FlyingPig-Turquoise',
                'type': 'premium',
                'potion': 'Turquoise',
                'egg': 'FlyingPig',
                'text': 'Turquoise Flying Pig'
            },
            'FlyingPig-Vampire': {
                'key': 'FlyingPig-Vampire',
                'type': 'premium',
                'potion': 'Vampire',
                'egg': 'FlyingPig',
                'text': 'Vampire Flying Pig'
            },
            'FlyingPig-AutumnLeaf': {
                'key': 'FlyingPig-AutumnLeaf',
                'type': 'premium',
                'potion': 'AutumnLeaf',
                'egg': 'FlyingPig',
                'text': 'Autumn Leaf Flying Pig'
            },
            'FlyingPig-BlackPearl': {
                'key': 'FlyingPig-BlackPearl',
                'type': 'premium',
                'potion': 'BlackPearl',
                'egg': 'FlyingPig',
                'text': 'Black Pearl Flying Pig'
            },
            'FlyingPig-StainedGlass': {
                'key': 'FlyingPig-StainedGlass',
                'type': 'premium',
                'potion': 'StainedGlass',
                'egg': 'FlyingPig',
                'text': 'Stained Glass Flying Pig'
            },
            'FlyingPig-PolkaDot': {
                'key': 'FlyingPig-PolkaDot',
                'type': 'premium',
                'potion': 'PolkaDot',
                'egg': 'FlyingPig',
                'text': 'Polka Dot Flying Pig'
            },
            'FlyingPig-MossyStone': {
                'key': 'FlyingPig-MossyStone',
                'type': 'premium',
                'potion': 'MossyStone',
                'egg': 'FlyingPig',
                'text': 'Mossy Stone Flying Pig'
            },
            'FlyingPig-Sunset': {
                'key': 'FlyingPig-Sunset',
                'type': 'premium',
                'potion': 'Sunset',
                'egg': 'FlyingPig',
                'text': 'Sunset Flying Pig'
            },
            'FlyingPig-Moonglow': {
                'key': 'FlyingPig-Moonglow',
                'type': 'premium',
                'potion': 'Moonglow',
                'egg': 'FlyingPig',
                'text': 'Moonglow Flying Pig'
            },
            'FlyingPig-SolarSystem': {
                'key': 'FlyingPig-SolarSystem',
                'type': 'premium',
                'potion': 'SolarSystem',
                'egg': 'FlyingPig',
                'text': 'Solar System Flying Pig'
            },
            'Dragon-RoyalPurple': {
                'key': 'Dragon-RoyalPurple',
                'type': 'premium',
                'potion': 'RoyalPurple',
                'egg': 'Dragon',
                'text': 'Royal Purple Dragon'
            },
            'Dragon-Cupid': {
                'key': 'Dragon-Cupid',
                'type': 'premium',
                'potion': 'Cupid',
                'egg': 'Dragon',
                'text': 'Cupid Dragon'
            },
            'Dragon-Shimmer': {
                'key': 'Dragon-Shimmer',
                'type': 'premium',
                'potion': 'Shimmer',
                'egg': 'Dragon',
                'text': 'Shimmer Dragon'
            },
            'Dragon-Fairy': {
                'key': 'Dragon-Fairy',
                'type': 'premium',
                'potion': 'Fairy',
                'egg': 'Dragon',
                'text': 'Fairy Dragon'
            },
            'Dragon-Floral': {
                'key': 'Dragon-Floral',
                'type': 'premium',
                'potion': 'Floral',
                'egg': 'Dragon',
                'text': 'Floral Dragon'
            },
            'Dragon-Aquatic': {
                'key': 'Dragon-Aquatic',
                'type': 'premium',
                'potion': 'Aquatic',
                'egg': 'Dragon',
                'text': 'Aquatic Dragon'
            },
            'Dragon-Ember': {
                'key': 'Dragon-Ember',
                'type': 'premium',
                'potion': 'Ember',
                'egg': 'Dragon',
                'text': 'Ember Dragon'
            },
            'Dragon-Thunderstorm': {
                'key': 'Dragon-Thunderstorm',
                'type': 'premium',
                'potion': 'Thunderstorm',
                'egg': 'Dragon',
                'text': 'Thunderstorm Dragon'
            },
            'Dragon-Spooky': {
                'key': 'Dragon-Spooky',
                'type': 'premium',
                'potion': 'Spooky',
                'egg': 'Dragon',
                'text': 'Spooky Dragon'
            },
            'Dragon-Ghost': {
                'key': 'Dragon-Ghost',
                'type': 'premium',
                'potion': 'Ghost',
                'egg': 'Dragon',
                'text': 'Ghost Dragon'
            },
            'Dragon-Holly': {
                'key': 'Dragon-Holly',
                'type': 'premium',
                'potion': 'Holly',
                'egg': 'Dragon',
                'text': 'Holly Dragon'
            },
            'Dragon-Peppermint': {
                'key': 'Dragon-Peppermint',
                'type': 'premium',
                'potion': 'Peppermint',
                'egg': 'Dragon',
                'text': 'Peppermint Dragon'
            },
            'Dragon-StarryNight': {
                'key': 'Dragon-StarryNight',
                'type': 'premium',
                'potion': 'StarryNight',
                'egg': 'Dragon',
                'text': 'Starry Night Dragon'
            },
            'Dragon-Rainbow': {
                'key': 'Dragon-Rainbow',
                'type': 'premium',
                'potion': 'Rainbow',
                'egg': 'Dragon',
                'text': 'Rainbow Dragon'
            },
            'Dragon-Glass': {
                'key': 'Dragon-Glass',
                'type': 'premium',
                'potion': 'Glass',
                'egg': 'Dragon',
                'text': 'Glass Dragon'
            },
            'Dragon-Glow': {
                'key': 'Dragon-Glow',
                'type': 'premium',
                'potion': 'Glow',
                'egg': 'Dragon',
                'text': 'Glow-in-the-Dark Dragon'
            },
            'Dragon-Frost': {
                'key': 'Dragon-Frost',
                'type': 'premium',
                'potion': 'Frost',
                'egg': 'Dragon',
                'text': 'Frost Dragon'
            },
            'Dragon-IcySnow': {
                'key': 'Dragon-IcySnow',
                'type': 'premium',
                'potion': 'IcySnow',
                'egg': 'Dragon',
                'text': 'Icy Snow Dragon'
            },
            'Dragon-RoseQuartz': {
                'key': 'Dragon-RoseQuartz',
                'type': 'premium',
                'potion': 'RoseQuartz',
                'egg': 'Dragon',
                'text': 'Rose Quartz Dragon'
            },
            'Dragon-Celestial': {
                'key': 'Dragon-Celestial',
                'type': 'premium',
                'potion': 'Celestial',
                'egg': 'Dragon',
                'text': 'Celestial Dragon'
            },
            'Dragon-Sunshine': {
                'key': 'Dragon-Sunshine',
                'type': 'premium',
                'potion': 'Sunshine',
                'egg': 'Dragon',
                'text': 'Sunshine Dragon'
            },
            'Dragon-Bronze': {
                'key': 'Dragon-Bronze',
                'type': 'premium',
                'potion': 'Bronze',
                'egg': 'Dragon',
                'text': 'Bronze Dragon'
            },
            'Dragon-Watery': {
                'key': 'Dragon-Watery',
                'type': 'premium',
                'potion': 'Watery',
                'egg': 'Dragon',
                'text': 'Watery Dragon'
            },
            'Dragon-Silver': {
                'key': 'Dragon-Silver',
                'type': 'premium',
                'potion': 'Silver',
                'egg': 'Dragon',
                'text': 'Silver Dragon'
            },
            'Dragon-Shadow': {
                'key': 'Dragon-Shadow',
                'type': 'premium',
                'potion': 'Shadow',
                'egg': 'Dragon',
                'text': 'Shadow Dragon'
            },
            'Dragon-Amber': {
                'key': 'Dragon-Amber',
                'type': 'premium',
                'potion': 'Amber',
                'egg': 'Dragon',
                'text': 'Amber Dragon'
            },
            'Dragon-Aurora': {
                'key': 'Dragon-Aurora',
                'type': 'premium',
                'potion': 'Aurora',
                'egg': 'Dragon',
                'text': 'Aurora Dragon'
            },
            'Dragon-Ruby': {
                'key': 'Dragon-Ruby',
                'type': 'premium',
                'potion': 'Ruby',
                'egg': 'Dragon',
                'text': 'Ruby Dragon'
            },
            'Dragon-BirchBark': {
                'key': 'Dragon-BirchBark',
                'type': 'premium',
                'potion': 'BirchBark',
                'egg': 'Dragon',
                'text': 'Birch Bark Dragon'
            },
            'Dragon-Fluorite': {
                'key': 'Dragon-Fluorite',
                'type': 'premium',
                'potion': 'Fluorite',
                'egg': 'Dragon',
                'text': 'Fluorite Dragon'
            },
            'Dragon-SandSculpture': {
                'key': 'Dragon-SandSculpture',
                'type': 'premium',
                'potion': 'SandSculpture',
                'egg': 'Dragon',
                'text': 'Sand Sculpture Dragon'
            },
            'Dragon-Windup': {
                'key': 'Dragon-Windup',
                'type': 'premium',
                'potion': 'Windup',
                'egg': 'Dragon',
                'text': 'Wind-Up Dragon'
            },
            'Dragon-Turquoise': {
                'key': 'Dragon-Turquoise',
                'type': 'premium',
                'potion': 'Turquoise',
                'egg': 'Dragon',
                'text': 'Turquoise Dragon'
            },
            'Dragon-Vampire': {
                'key': 'Dragon-Vampire',
                'type': 'premium',
                'potion': 'Vampire',
                'egg': 'Dragon',
                'text': 'Vampire Dragon'
            },
            'Dragon-AutumnLeaf': {
                'key': 'Dragon-AutumnLeaf',
                'type': 'premium',
                'potion': 'AutumnLeaf',
                'egg': 'Dragon',
                'text': 'Autumn Leaf Dragon'
            },
            'Dragon-BlackPearl': {
                'key': 'Dragon-BlackPearl',
                'type': 'premium',
                'potion': 'BlackPearl',
                'egg': 'Dragon',
                'text': 'Black Pearl Dragon'
            },
            'Dragon-StainedGlass': {
                'key': 'Dragon-StainedGlass',
                'type': 'premium',
                'potion': 'StainedGlass',
                'egg': 'Dragon',
                'text': 'Stained Glass Dragon'
            },
            'Dragon-PolkaDot': {
                'key': 'Dragon-PolkaDot',
                'type': 'premium',
                'potion': 'PolkaDot',
                'egg': 'Dragon',
                'text': 'Polka Dot Dragon'
            },
            'Dragon-MossyStone': {
                'key': 'Dragon-MossyStone',
                'type': 'premium',
                'potion': 'MossyStone',
                'egg': 'Dragon',
                'text': 'Mossy Stone Dragon'
            },
            'Dragon-Sunset': {
                'key': 'Dragon-Sunset',
                'type': 'premium',
                'potion': 'Sunset',
                'egg': 'Dragon',
                'text': 'Sunset Dragon'
            },
            'Dragon-Moonglow': {
                'key': 'Dragon-Moonglow',
                'type': 'premium',
                'potion': 'Moonglow',
                'egg': 'Dragon',
                'text': 'Moonglow Dragon'
            },
            'Dragon-SolarSystem': {
                'key': 'Dragon-SolarSystem',
                'type': 'premium',
                'potion': 'SolarSystem',
                'egg': 'Dragon',
                'text': 'Solar System Dragon'
            },
            'Cactus-RoyalPurple': {
                'key': 'Cactus-RoyalPurple',
                'type': 'premium',
                'potion': 'RoyalPurple',
                'egg': 'Cactus',
                'text': 'Royal Purple Cactus'
            },
            'Cactus-Cupid': {
                'key': 'Cactus-Cupid',
                'type': 'premium',
                'potion': 'Cupid',
                'egg': 'Cactus',
                'text': 'Cupid Cactus'
            },
            'Cactus-Shimmer': {
                'key': 'Cactus-Shimmer',
                'type': 'premium',
                'potion': 'Shimmer',
                'egg': 'Cactus',
                'text': 'Shimmer Cactus'
            },
            'Cactus-Fairy': {
                'key': 'Cactus-Fairy',
                'type': 'premium',
                'potion': 'Fairy',
                'egg': 'Cactus',
                'text': 'Fairy Cactus'
            },
            'Cactus-Floral': {
                'key': 'Cactus-Floral',
                'type': 'premium',
                'potion': 'Floral',
                'egg': 'Cactus',
                'text': 'Floral Cactus'
            },
            'Cactus-Aquatic': {
                'key': 'Cactus-Aquatic',
                'type': 'premium',
                'potion': 'Aquatic',
                'egg': 'Cactus',
                'text': 'Aquatic Cactus'
            },
            'Cactus-Ember': {
                'key': 'Cactus-Ember',
                'type': 'premium',
                'potion': 'Ember',
                'egg': 'Cactus',
                'text': 'Ember Cactus'
            },
            'Cactus-Thunderstorm': {
                'key': 'Cactus-Thunderstorm',
                'type': 'premium',
                'potion': 'Thunderstorm',
                'egg': 'Cactus',
                'text': 'Thunderstorm Cactus'
            },
            'Cactus-Spooky': {
                'key': 'Cactus-Spooky',
                'type': 'premium',
                'potion': 'Spooky',
                'egg': 'Cactus',
                'text': 'Spooky Cactus'
            },
            'Cactus-Ghost': {
                'key': 'Cactus-Ghost',
                'type': 'premium',
                'potion': 'Ghost',
                'egg': 'Cactus',
                'text': 'Ghost Cactus'
            },
            'Cactus-Holly': {
                'key': 'Cactus-Holly',
                'type': 'premium',
                'potion': 'Holly',
                'egg': 'Cactus',
                'text': 'Holly Cactus'
            },
            'Cactus-Peppermint': {
                'key': 'Cactus-Peppermint',
                'type': 'premium',
                'potion': 'Peppermint',
                'egg': 'Cactus',
                'text': 'Peppermint Cactus'
            },
            'Cactus-StarryNight': {
                'key': 'Cactus-StarryNight',
                'type': 'premium',
                'potion': 'StarryNight',
                'egg': 'Cactus',
                'text': 'Starry Night Cactus'
            },
            'Cactus-Rainbow': {
                'key': 'Cactus-Rainbow',
                'type': 'premium',
                'potion': 'Rainbow',
                'egg': 'Cactus',
                'text': 'Rainbow Cactus'
            },
            'Cactus-Glass': {
                'key': 'Cactus-Glass',
                'type': 'premium',
                'potion': 'Glass',
                'egg': 'Cactus',
                'text': 'Glass Cactus'
            },
            'Cactus-Glow': {
                'key': 'Cactus-Glow',
                'type': 'premium',
                'potion': 'Glow',
                'egg': 'Cactus',
                'text': 'Glow-in-the-Dark Cactus'
            },
            'Cactus-Frost': {
                'key': 'Cactus-Frost',
                'type': 'premium',
                'potion': 'Frost',
                'egg': 'Cactus',
                'text': 'Frost Cactus'
            },
            'Cactus-IcySnow': {
                'key': 'Cactus-IcySnow',
                'type': 'premium',
                'potion': 'IcySnow',
                'egg': 'Cactus',
                'text': 'Icy Snow Cactus'
            },
            'Cactus-RoseQuartz': {
                'key': 'Cactus-RoseQuartz',
                'type': 'premium',
                'potion': 'RoseQuartz',
                'egg': 'Cactus',
                'text': 'Rose Quartz Cactus'
            },
            'Cactus-Celestial': {
                'key': 'Cactus-Celestial',
                'type': 'premium',
                'potion': 'Celestial',
                'egg': 'Cactus',
                'text': 'Celestial Cactus'
            },
            'Cactus-Sunshine': {
                'key': 'Cactus-Sunshine',
                'type': 'premium',
                'potion': 'Sunshine',
                'egg': 'Cactus',
                'text': 'Sunshine Cactus'
            },
            'Cactus-Bronze': {
                'key': 'Cactus-Bronze',
                'type': 'premium',
                'potion': 'Bronze',
                'egg': 'Cactus',
                'text': 'Bronze Cactus'
            },
            'Cactus-Watery': {
                'key': 'Cactus-Watery',
                'type': 'premium',
                'potion': 'Watery',
                'egg': 'Cactus',
                'text': 'Watery Cactus'
            },
            'Cactus-Silver': {
                'key': 'Cactus-Silver',
                'type': 'premium',
                'potion': 'Silver',
                'egg': 'Cactus',
                'text': 'Silver Cactus'
            },
            'Cactus-Shadow': {
                'key': 'Cactus-Shadow',
                'type': 'premium',
                'potion': 'Shadow',
                'egg': 'Cactus',
                'text': 'Shadow Cactus'
            },
            'Cactus-Amber': {
                'key': 'Cactus-Amber',
                'type': 'premium',
                'potion': 'Amber',
                'egg': 'Cactus',
                'text': 'Amber Cactus'
            },
            'Cactus-Aurora': {
                'key': 'Cactus-Aurora',
                'type': 'premium',
                'potion': 'Aurora',
                'egg': 'Cactus',
                'text': 'Aurora Cactus'
            },
            'Cactus-Ruby': {
                'key': 'Cactus-Ruby',
                'type': 'premium',
                'potion': 'Ruby',
                'egg': 'Cactus',
                'text': 'Ruby Cactus'
            },
            'Cactus-BirchBark': {
                'key': 'Cactus-BirchBark',
                'type': 'premium',
                'potion': 'BirchBark',
                'egg': 'Cactus',
                'text': 'Birch Bark Cactus'
            },
            'Cactus-Fluorite': {
                'key': 'Cactus-Fluorite',
                'type': 'premium',
                'potion': 'Fluorite',
                'egg': 'Cactus',
                'text': 'Fluorite Cactus'
            },
            'Cactus-SandSculpture': {
                'key': 'Cactus-SandSculpture',
                'type': 'premium',
                'potion': 'SandSculpture',
                'egg': 'Cactus',
                'text': 'Sand Sculpture Cactus'
            },
            'Cactus-Windup': {
                'key': 'Cactus-Windup',
                'type': 'premium',
                'potion': 'Windup',
                'egg': 'Cactus',
                'text': 'Wind-Up Cactus'
            },
            'Cactus-Turquoise': {
                'key': 'Cactus-Turquoise',
                'type': 'premium',
                'potion': 'Turquoise',
                'egg': 'Cactus',
                'text': 'Turquoise Cactus'
            },
            'Cactus-Vampire': {
                'key': 'Cactus-Vampire',
                'type': 'premium',
                'potion': 'Vampire',
                'egg': 'Cactus',
                'text': 'Vampire Cactus'
            },
            'Cactus-AutumnLeaf': {
                'key': 'Cactus-AutumnLeaf',
                'type': 'premium',
                'potion': 'AutumnLeaf',
                'egg': 'Cactus',
                'text': 'Autumn Leaf Cactus'
            },
            'Cactus-BlackPearl': {
                'key': 'Cactus-BlackPearl',
                'type': 'premium',
                'potion': 'BlackPearl',
                'egg': 'Cactus',
                'text': 'Black Pearl Cactus'
            },
            'Cactus-StainedGlass': {
                'key': 'Cactus-StainedGlass',
                'type': 'premium',
                'potion': 'StainedGlass',
                'egg': 'Cactus',
                'text': 'Stained Glass Cactus'
            },
            'Cactus-PolkaDot': {
                'key': 'Cactus-PolkaDot',
                'type': 'premium',
                'potion': 'PolkaDot',
                'egg': 'Cactus',
                'text': 'Polka Dot Cactus'
            },
            'Cactus-MossyStone': {
                'key': 'Cactus-MossyStone',
                'type': 'premium',
                'potion': 'MossyStone',
                'egg': 'Cactus',
                'text': 'Mossy Stone Cactus'
            },
            'Cactus-Sunset': {
                'key': 'Cactus-Sunset',
                'type': 'premium',
                'potion': 'Sunset',
                'egg': 'Cactus',
                'text': 'Sunset Cactus'
            },
            'Cactus-Moonglow': {
                'key': 'Cactus-Moonglow',
                'type': 'premium',
                'potion': 'Moonglow',
                'egg': 'Cactus',
                'text': 'Moonglow Cactus'
            },
            'Cactus-SolarSystem': {
                'key': 'Cactus-SolarSystem',
                'type': 'premium',
                'potion': 'SolarSystem',
                'egg': 'Cactus',
                'text': 'Solar System Cactus'
            },
            'BearCub-RoyalPurple': {
                'key': 'BearCub-RoyalPurple',
                'type': 'premium',
                'potion': 'RoyalPurple',
                'egg': 'BearCub',
                'text': 'Royal Purple Bear Cub'
            },
            'BearCub-Cupid': {
                'key': 'BearCub-Cupid',
                'type': 'premium',
                'potion': 'Cupid',
                'egg': 'BearCub',
                'text': 'Cupid Bear Cub'
            },
            'BearCub-Shimmer': {
                'key': 'BearCub-Shimmer',
                'type': 'premium',
                'potion': 'Shimmer',
                'egg': 'BearCub',
                'text': 'Shimmer Bear Cub'
            },
            'BearCub-Fairy': {
                'key': 'BearCub-Fairy',
                'type': 'premium',
                'potion': 'Fairy',
                'egg': 'BearCub',
                'text': 'Fairy Bear Cub'
            },
            'BearCub-Floral': {
                'key': 'BearCub-Floral',
                'type': 'premium',
                'potion': 'Floral',
                'egg': 'BearCub',
                'text': 'Floral Bear Cub'
            },
            'BearCub-Aquatic': {
                'key': 'BearCub-Aquatic',
                'type': 'premium',
                'potion': 'Aquatic',
                'egg': 'BearCub',
                'text': 'Aquatic Bear Cub'
            },
            'BearCub-Ember': {
                'key': 'BearCub-Ember',
                'type': 'premium',
                'potion': 'Ember',
                'egg': 'BearCub',
                'text': 'Ember Bear Cub'
            },
            'BearCub-Thunderstorm': {
                'key': 'BearCub-Thunderstorm',
                'type': 'premium',
                'potion': 'Thunderstorm',
                'egg': 'BearCub',
                'text': 'Thunderstorm Bear Cub'
            },
            'BearCub-Spooky': {
                'key': 'BearCub-Spooky',
                'type': 'premium',
                'potion': 'Spooky',
                'egg': 'BearCub',
                'text': 'Spooky Bear Cub'
            },
            'BearCub-Ghost': {
                'key': 'BearCub-Ghost',
                'type': 'premium',
                'potion': 'Ghost',
                'egg': 'BearCub',
                'text': 'Ghost Bear Cub'
            },
            'BearCub-Holly': {
                'key': 'BearCub-Holly',
                'type': 'premium',
                'potion': 'Holly',
                'egg': 'BearCub',
                'text': 'Holly Bear Cub'
            },
            'BearCub-Peppermint': {
                'key': 'BearCub-Peppermint',
                'type': 'premium',
                'potion': 'Peppermint',
                'egg': 'BearCub',
                'text': 'Peppermint Bear Cub'
            },
            'BearCub-StarryNight': {
                'key': 'BearCub-StarryNight',
                'type': 'premium',
                'potion': 'StarryNight',
                'egg': 'BearCub',
                'text': 'Starry Night Bear Cub'
            },
            'BearCub-Rainbow': {
                'key': 'BearCub-Rainbow',
                'type': 'premium',
                'potion': 'Rainbow',
                'egg': 'BearCub',
                'text': 'Rainbow Bear Cub'
            },
            'BearCub-Glass': {
                'key': 'BearCub-Glass',
                'type': 'premium',
                'potion': 'Glass',
                'egg': 'BearCub',
                'text': 'Glass Bear Cub'
            },
            'BearCub-Glow': {
                'key': 'BearCub-Glow',
                'type': 'premium',
                'potion': 'Glow',
                'egg': 'BearCub',
                'text': 'Glow-in-the-Dark Bear Cub'
            },
            'BearCub-Frost': {
                'key': 'BearCub-Frost',
                'type': 'premium',
                'potion': 'Frost',
                'egg': 'BearCub',
                'text': 'Frost Bear Cub'
            },
            'BearCub-IcySnow': {
                'key': 'BearCub-IcySnow',
                'type': 'premium',
                'potion': 'IcySnow',
                'egg': 'BearCub',
                'text': 'Icy Snow Bear Cub'
            },
            'BearCub-RoseQuartz': {
                'key': 'BearCub-RoseQuartz',
                'type': 'premium',
                'potion': 'RoseQuartz',
                'egg': 'BearCub',
                'text': 'Rose Quartz Bear Cub'
            },
            'BearCub-Celestial': {
                'key': 'BearCub-Celestial',
                'type': 'premium',
                'potion': 'Celestial',
                'egg': 'BearCub',
                'text': 'Celestial Bear Cub'
            },
            'BearCub-Sunshine': {
                'key': 'BearCub-Sunshine',
                'type': 'premium',
                'potion': 'Sunshine',
                'egg': 'BearCub',
                'text': 'Sunshine Bear Cub'
            },
            'BearCub-Bronze': {
                'key': 'BearCub-Bronze',
                'type': 'premium',
                'potion': 'Bronze',
                'egg': 'BearCub',
                'text': 'Bronze Bear Cub'
            },
            'BearCub-Watery': {
                'key': 'BearCub-Watery',
                'type': 'premium',
                'potion': 'Watery',
                'egg': 'BearCub',
                'text': 'Watery Bear Cub'
            },
            'BearCub-Silver': {
                'key': 'BearCub-Silver',
                'type': 'premium',
                'potion': 'Silver',
                'egg': 'BearCub',
                'text': 'Silver Bear Cub'
            },
            'BearCub-Shadow': {
                'key': 'BearCub-Shadow',
                'type': 'premium',
                'potion': 'Shadow',
                'egg': 'BearCub',
                'text': 'Shadow Bear Cub'
            },
            'BearCub-Amber': {
                'key': 'BearCub-Amber',
                'type': 'premium',
                'potion': 'Amber',
                'egg': 'BearCub',
                'text': 'Amber Bear Cub'
            },
            'BearCub-Aurora': {
                'key': 'BearCub-Aurora',
                'type': 'premium',
                'potion': 'Aurora',
                'egg': 'BearCub',
                'text': 'Aurora Bear Cub'
            },
            'BearCub-Ruby': {
                'key': 'BearCub-Ruby',
                'type': 'premium',
                'potion': 'Ruby',
                'egg': 'BearCub',
                'text': 'Ruby Bear Cub'
            },
            'BearCub-BirchBark': {
                'key': 'BearCub-BirchBark',
                'type': 'premium',
                'potion': 'BirchBark',
                'egg': 'BearCub',
                'text': 'Birch Bark Bear Cub'
            },
            'BearCub-Fluorite': {
                'key': 'BearCub-Fluorite',
                'type': 'premium',
                'potion': 'Fluorite',
                'egg': 'BearCub',
                'text': 'Fluorite Bear Cub'
            },
            'BearCub-SandSculpture': {
                'key': 'BearCub-SandSculpture',
                'type': 'premium',
                'potion': 'SandSculpture',
                'egg': 'BearCub',
                'text': 'Sand Sculpture Bear Cub'
            },
            'BearCub-Windup': {
                'key': 'BearCub-Windup',
                'type': 'premium',
                'potion': 'Windup',
                'egg': 'BearCub',
                'text': 'Wind-Up Bear Cub'
            },
            'BearCub-Turquoise': {
                'key': 'BearCub-Turquoise',
                'type': 'premium',
                'potion': 'Turquoise',
                'egg': 'BearCub',
                'text': 'Turquoise Bear Cub'
            },
            'BearCub-Vampire': {
                'key': 'BearCub-Vampire',
                'type': 'premium',
                'potion': 'Vampire',
                'egg': 'BearCub',
                'text': 'Vampire Bear Cub'
            },
            'BearCub-AutumnLeaf': {
                'key': 'BearCub-AutumnLeaf',
                'type': 'premium',
                'potion': 'AutumnLeaf',
                'egg': 'BearCub',
                'text': 'Autumn Leaf Bear Cub'
            },
            'BearCub-BlackPearl': {
                'key': 'BearCub-BlackPearl',
                'type': 'premium',
                'potion': 'BlackPearl',
                'egg': 'BearCub',
                'text': 'Black Pearl Bear Cub'
            },
            'BearCub-StainedGlass': {
                'key': 'BearCub-StainedGlass',
                'type': 'premium',
                'potion': 'StainedGlass',
                'egg': 'BearCub',
                'text': 'Stained Glass Bear Cub'
            },
            'BearCub-PolkaDot': {
                'key': 'BearCub-PolkaDot',
                'type': 'premium',
                'potion': 'PolkaDot',
                'egg': 'BearCub',
                'text': 'Polka Dot Bear Cub'
            },
            'BearCub-MossyStone': {
                'key': 'BearCub-MossyStone',
                'type': 'premium',
                'potion': 'MossyStone',
                'egg': 'BearCub',
                'text': 'Mossy Stone Bear Cub'
            },
            'BearCub-Sunset': {
                'key': 'BearCub-Sunset',
                'type': 'premium',
                'potion': 'Sunset',
                'egg': 'BearCub',
                'text': 'Sunset Bear Cub'
            },
            'BearCub-Moonglow': {
                'key': 'BearCub-Moonglow',
                'type': 'premium',
                'potion': 'Moonglow',
                'egg': 'BearCub',
                'text': 'Moonglow Bear Cub'
            },
            'BearCub-SolarSystem': {
                'key': 'BearCub-SolarSystem',
                'type': 'premium',
                'potion': 'SolarSystem',
                'egg': 'BearCub',
                'text': 'Solar System Bear Cub'
            },
            'Gryphon-Base': {
                'key': 'Gryphon-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Gryphon',
                'text': 'Base Gryphon'
            },
            'Gryphon-White': {
                'key': 'Gryphon-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Gryphon',
                'text': 'White Gryphon'
            },
            'Gryphon-Desert': {
                'key': 'Gryphon-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Gryphon',
                'text': 'Desert Gryphon'
            },
            'Gryphon-Red': {
                'key': 'Gryphon-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Gryphon',
                'text': 'Red Gryphon'
            },
            'Gryphon-Shade': {
                'key': 'Gryphon-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Gryphon',
                'text': 'Shade Gryphon'
            },
            'Gryphon-Skeleton': {
                'key': 'Gryphon-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Gryphon',
                'text': 'Skeleton Gryphon'
            },
            'Gryphon-Zombie': {
                'key': 'Gryphon-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Gryphon',
                'text': 'Zombie Gryphon'
            },
            'Gryphon-CottonCandyPink': {
                'key': 'Gryphon-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Gryphon',
                'text': 'Cotton Candy Pink Gryphon'
            },
            'Gryphon-CottonCandyBlue': {
                'key': 'Gryphon-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Gryphon',
                'text': 'Cotton Candy Blue Gryphon'
            },
            'Gryphon-Golden': {
                'key': 'Gryphon-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Gryphon',
                'text': 'Golden Gryphon'
            },
            'Hedgehog-Base': {
                'key': 'Hedgehog-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Hedgehog',
                'text': 'Base Hedgehog'
            },
            'Hedgehog-White': {
                'key': 'Hedgehog-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Hedgehog',
                'text': 'White Hedgehog'
            },
            'Hedgehog-Desert': {
                'key': 'Hedgehog-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Hedgehog',
                'text': 'Desert Hedgehog'
            },
            'Hedgehog-Red': {
                'key': 'Hedgehog-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Hedgehog',
                'text': 'Red Hedgehog'
            },
            'Hedgehog-Shade': {
                'key': 'Hedgehog-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Hedgehog',
                'text': 'Shade Hedgehog'
            },
            'Hedgehog-Skeleton': {
                'key': 'Hedgehog-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Hedgehog',
                'text': 'Skeleton Hedgehog'
            },
            'Hedgehog-Zombie': {
                'key': 'Hedgehog-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Hedgehog',
                'text': 'Zombie Hedgehog'
            },
            'Hedgehog-CottonCandyPink': {
                'key': 'Hedgehog-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Hedgehog',
                'text': 'Cotton Candy Pink Hedgehog'
            },
            'Hedgehog-CottonCandyBlue': {
                'key': 'Hedgehog-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Hedgehog',
                'text': 'Cotton Candy Blue Hedgehog'
            },
            'Hedgehog-Golden': {
                'key': 'Hedgehog-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Hedgehog',
                'text': 'Golden Hedgehog'
            },
            'Deer-Base': {
                'key': 'Deer-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Deer',
                'text': 'Base Deer'
            },
            'Deer-White': {
                'key': 'Deer-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Deer',
                'text': 'White Deer'
            },
            'Deer-Desert': {
                'key': 'Deer-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Deer',
                'text': 'Desert Deer'
            },
            'Deer-Red': {
                'key': 'Deer-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Deer',
                'text': 'Red Deer'
            },
            'Deer-Shade': {
                'key': 'Deer-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Deer',
                'text': 'Shade Deer'
            },
            'Deer-Skeleton': {
                'key': 'Deer-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Deer',
                'text': 'Skeleton Deer'
            },
            'Deer-Zombie': {
                'key': 'Deer-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Deer',
                'text': 'Zombie Deer'
            },
            'Deer-CottonCandyPink': {
                'key': 'Deer-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Deer',
                'text': 'Cotton Candy Pink Deer'
            },
            'Deer-CottonCandyBlue': {
                'key': 'Deer-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Deer',
                'text': 'Cotton Candy Blue Deer'
            },
            'Deer-Golden': {
                'key': 'Deer-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Deer',
                'text': 'Golden Deer'
            },
            'Egg-Base': {
                'key': 'Egg-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Egg',
                'text': 'Base Egg'
            },
            'Egg-White': {
                'key': 'Egg-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Egg',
                'text': 'White Egg'
            },
            'Egg-Desert': {
                'key': 'Egg-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Egg',
                'text': 'Desert Egg'
            },
            'Egg-Red': {
                'key': 'Egg-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Egg',
                'text': 'Red Egg'
            },
            'Egg-Shade': {
                'key': 'Egg-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Egg',
                'text': 'Shade Egg'
            },
            'Egg-Skeleton': {
                'key': 'Egg-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Egg',
                'text': 'Skeleton Egg'
            },
            'Egg-Zombie': {
                'key': 'Egg-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Egg',
                'text': 'Zombie Egg'
            },
            'Egg-CottonCandyPink': {
                'key': 'Egg-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Egg',
                'text': 'Cotton Candy Pink Egg'
            },
            'Egg-CottonCandyBlue': {
                'key': 'Egg-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Egg',
                'text': 'Cotton Candy Blue Egg'
            },
            'Egg-Golden': {
                'key': 'Egg-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Egg',
                'text': 'Golden Egg'
            },
            'Rat-Base': {
                'key': 'Rat-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Rat',
                'text': 'Base Rat'
            },
            'Rat-White': {
                'key': 'Rat-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Rat',
                'text': 'White Rat'
            },
            'Rat-Desert': {
                'key': 'Rat-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Rat',
                'text': 'Desert Rat'
            },
            'Rat-Red': {
                'key': 'Rat-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Rat',
                'text': 'Red Rat'
            },
            'Rat-Shade': {
                'key': 'Rat-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Rat',
                'text': 'Shade Rat'
            },
            'Rat-Skeleton': {
                'key': 'Rat-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Rat',
                'text': 'Skeleton Rat'
            },
            'Rat-Zombie': {
                'key': 'Rat-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Rat',
                'text': 'Zombie Rat'
            },
            'Rat-CottonCandyPink': {
                'key': 'Rat-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Rat',
                'text': 'Cotton Candy Pink Rat'
            },
            'Rat-CottonCandyBlue': {
                'key': 'Rat-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Rat',
                'text': 'Cotton Candy Blue Rat'
            },
            'Rat-Golden': {
                'key': 'Rat-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Rat',
                'text': 'Golden Rat'
            },
            'Octopus-Base': {
                'key': 'Octopus-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Octopus',
                'text': 'Base Octopus'
            },
            'Octopus-White': {
                'key': 'Octopus-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Octopus',
                'text': 'White Octopus'
            },
            'Octopus-Desert': {
                'key': 'Octopus-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Octopus',
                'text': 'Desert Octopus'
            },
            'Octopus-Red': {
                'key': 'Octopus-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Octopus',
                'text': 'Red Octopus'
            },
            'Octopus-Shade': {
                'key': 'Octopus-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Octopus',
                'text': 'Shade Octopus'
            },
            'Octopus-Skeleton': {
                'key': 'Octopus-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Octopus',
                'text': 'Skeleton Octopus'
            },
            'Octopus-Zombie': {
                'key': 'Octopus-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Octopus',
                'text': 'Zombie Octopus'
            },
            'Octopus-CottonCandyPink': {
                'key': 'Octopus-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Octopus',
                'text': 'Cotton Candy Pink Octopus'
            },
            'Octopus-CottonCandyBlue': {
                'key': 'Octopus-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Octopus',
                'text': 'Cotton Candy Blue Octopus'
            },
            'Octopus-Golden': {
                'key': 'Octopus-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Octopus',
                'text': 'Golden Octopus'
            },
            'Seahorse-Base': {
                'key': 'Seahorse-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Seahorse',
                'text': 'Base Seahorse'
            },
            'Seahorse-White': {
                'key': 'Seahorse-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Seahorse',
                'text': 'White Seahorse'
            },
            'Seahorse-Desert': {
                'key': 'Seahorse-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Seahorse',
                'text': 'Desert Seahorse'
            },
            'Seahorse-Red': {
                'key': 'Seahorse-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Seahorse',
                'text': 'Red Seahorse'
            },
            'Seahorse-Shade': {
                'key': 'Seahorse-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Seahorse',
                'text': 'Shade Seahorse'
            },
            'Seahorse-Skeleton': {
                'key': 'Seahorse-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Seahorse',
                'text': 'Skeleton Seahorse'
            },
            'Seahorse-Zombie': {
                'key': 'Seahorse-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Seahorse',
                'text': 'Zombie Seahorse'
            },
            'Seahorse-CottonCandyPink': {
                'key': 'Seahorse-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Seahorse',
                'text': 'Cotton Candy Pink Seahorse'
            },
            'Seahorse-CottonCandyBlue': {
                'key': 'Seahorse-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Seahorse',
                'text': 'Cotton Candy Blue Seahorse'
            },
            'Seahorse-Golden': {
                'key': 'Seahorse-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Seahorse',
                'text': 'Golden Seahorse'
            },
            'Parrot-Base': {
                'key': 'Parrot-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Parrot',
                'text': 'Base Parrot'
            },
            'Parrot-White': {
                'key': 'Parrot-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Parrot',
                'text': 'White Parrot'
            },
            'Parrot-Desert': {
                'key': 'Parrot-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Parrot',
                'text': 'Desert Parrot'
            },
            'Parrot-Red': {
                'key': 'Parrot-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Parrot',
                'text': 'Red Parrot'
            },
            'Parrot-Shade': {
                'key': 'Parrot-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Parrot',
                'text': 'Shade Parrot'
            },
            'Parrot-Skeleton': {
                'key': 'Parrot-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Parrot',
                'text': 'Skeleton Parrot'
            },
            'Parrot-Zombie': {
                'key': 'Parrot-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Parrot',
                'text': 'Zombie Parrot'
            },
            'Parrot-CottonCandyPink': {
                'key': 'Parrot-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Parrot',
                'text': 'Cotton Candy Pink Parrot'
            },
            'Parrot-CottonCandyBlue': {
                'key': 'Parrot-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Parrot',
                'text': 'Cotton Candy Blue Parrot'
            },
            'Parrot-Golden': {
                'key': 'Parrot-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Parrot',
                'text': 'Golden Parrot'
            },
            'Rooster-Base': {
                'key': 'Rooster-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Rooster',
                'text': 'Base Rooster'
            },
            'Rooster-White': {
                'key': 'Rooster-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Rooster',
                'text': 'White Rooster'
            },
            'Rooster-Desert': {
                'key': 'Rooster-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Rooster',
                'text': 'Desert Rooster'
            },
            'Rooster-Red': {
                'key': 'Rooster-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Rooster',
                'text': 'Red Rooster'
            },
            'Rooster-Shade': {
                'key': 'Rooster-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Rooster',
                'text': 'Shade Rooster'
            },
            'Rooster-Skeleton': {
                'key': 'Rooster-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Rooster',
                'text': 'Skeleton Rooster'
            },
            'Rooster-Zombie': {
                'key': 'Rooster-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Rooster',
                'text': 'Zombie Rooster'
            },
            'Rooster-CottonCandyPink': {
                'key': 'Rooster-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Rooster',
                'text': 'Cotton Candy Pink Rooster'
            },
            'Rooster-CottonCandyBlue': {
                'key': 'Rooster-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Rooster',
                'text': 'Cotton Candy Blue Rooster'
            },
            'Rooster-Golden': {
                'key': 'Rooster-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Rooster',
                'text': 'Golden Rooster'
            },
            'Spider-Base': {
                'key': 'Spider-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Spider',
                'text': 'Base Spider'
            },
            'Spider-White': {
                'key': 'Spider-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Spider',
                'text': 'White Spider'
            },
            'Spider-Desert': {
                'key': 'Spider-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Spider',
                'text': 'Desert Spider'
            },
            'Spider-Red': {
                'key': 'Spider-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Spider',
                'text': 'Red Spider'
            },
            'Spider-Shade': {
                'key': 'Spider-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Spider',
                'text': 'Shade Spider'
            },
            'Spider-Skeleton': {
                'key': 'Spider-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Spider',
                'text': 'Skeleton Spider'
            },
            'Spider-Zombie': {
                'key': 'Spider-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Spider',
                'text': 'Zombie Spider'
            },
            'Spider-CottonCandyPink': {
                'key': 'Spider-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Spider',
                'text': 'Cotton Candy Pink Spider'
            },
            'Spider-CottonCandyBlue': {
                'key': 'Spider-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Spider',
                'text': 'Cotton Candy Blue Spider'
            },
            'Spider-Golden': {
                'key': 'Spider-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Spider',
                'text': 'Golden Spider'
            },
            'Owl-Base': {
                'key': 'Owl-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Owl',
                'text': 'Base Owl'
            },
            'Owl-White': {
                'key': 'Owl-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Owl',
                'text': 'White Owl'
            },
            'Owl-Desert': {
                'key': 'Owl-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Owl',
                'text': 'Desert Owl'
            },
            'Owl-Red': {
                'key': 'Owl-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Owl',
                'text': 'Red Owl'
            },
            'Owl-Shade': {
                'key': 'Owl-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Owl',
                'text': 'Shade Owl'
            },
            'Owl-Skeleton': {
                'key': 'Owl-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Owl',
                'text': 'Skeleton Owl'
            },
            'Owl-Zombie': {
                'key': 'Owl-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Owl',
                'text': 'Zombie Owl'
            },
            'Owl-CottonCandyPink': {
                'key': 'Owl-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Owl',
                'text': 'Cotton Candy Pink Owl'
            },
            'Owl-CottonCandyBlue': {
                'key': 'Owl-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Owl',
                'text': 'Cotton Candy Blue Owl'
            },
            'Owl-Golden': {
                'key': 'Owl-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Owl',
                'text': 'Golden Owl'
            },
            'Penguin-Base': {
                'key': 'Penguin-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Penguin',
                'text': 'Base Penguin'
            },
            'Penguin-White': {
                'key': 'Penguin-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Penguin',
                'text': 'White Penguin'
            },
            'Penguin-Desert': {
                'key': 'Penguin-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Penguin',
                'text': 'Desert Penguin'
            },
            'Penguin-Red': {
                'key': 'Penguin-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Penguin',
                'text': 'Red Penguin'
            },
            'Penguin-Shade': {
                'key': 'Penguin-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Penguin',
                'text': 'Shade Penguin'
            },
            'Penguin-Skeleton': {
                'key': 'Penguin-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Penguin',
                'text': 'Skeleton Penguin'
            },
            'Penguin-Zombie': {
                'key': 'Penguin-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Penguin',
                'text': 'Zombie Penguin'
            },
            'Penguin-CottonCandyPink': {
                'key': 'Penguin-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Penguin',
                'text': 'Cotton Candy Pink Penguin'
            },
            'Penguin-CottonCandyBlue': {
                'key': 'Penguin-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Penguin',
                'text': 'Cotton Candy Blue Penguin'
            },
            'Penguin-Golden': {
                'key': 'Penguin-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Penguin',
                'text': 'Golden Penguin'
            },
            'TRex-Base': {
                'key': 'TRex-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'TRex',
                'text': 'Base Tyrannosaur'
            },
            'TRex-White': {
                'key': 'TRex-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'TRex',
                'text': 'White Tyrannosaur'
            },
            'TRex-Desert': {
                'key': 'TRex-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'TRex',
                'text': 'Desert Tyrannosaur'
            },
            'TRex-Red': {
                'key': 'TRex-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'TRex',
                'text': 'Red Tyrannosaur'
            },
            'TRex-Shade': {
                'key': 'TRex-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'TRex',
                'text': 'Shade Tyrannosaur'
            },
            'TRex-Skeleton': {
                'key': 'TRex-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'TRex',
                'text': 'Skeleton Tyrannosaur'
            },
            'TRex-Zombie': {
                'key': 'TRex-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'TRex',
                'text': 'Zombie Tyrannosaur'
            },
            'TRex-CottonCandyPink': {
                'key': 'TRex-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'TRex',
                'text': 'Cotton Candy Pink Tyrannosaur'
            },
            'TRex-CottonCandyBlue': {
                'key': 'TRex-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'TRex',
                'text': 'Cotton Candy Blue Tyrannosaur'
            },
            'TRex-Golden': {
                'key': 'TRex-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'TRex',
                'text': 'Golden Tyrannosaur'
            },
            'Rock-Base': {
                'key': 'Rock-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Rock',
                'text': 'Base Rock'
            },
            'Rock-White': {
                'key': 'Rock-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Rock',
                'text': 'White Rock'
            },
            'Rock-Desert': {
                'key': 'Rock-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Rock',
                'text': 'Desert Rock'
            },
            'Rock-Red': {
                'key': 'Rock-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Rock',
                'text': 'Red Rock'
            },
            'Rock-Shade': {
                'key': 'Rock-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Rock',
                'text': 'Shade Rock'
            },
            'Rock-Skeleton': {
                'key': 'Rock-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Rock',
                'text': 'Skeleton Rock'
            },
            'Rock-Zombie': {
                'key': 'Rock-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Rock',
                'text': 'Zombie Rock'
            },
            'Rock-CottonCandyPink': {
                'key': 'Rock-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Rock',
                'text': 'Cotton Candy Pink Rock'
            },
            'Rock-CottonCandyBlue': {
                'key': 'Rock-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Rock',
                'text': 'Cotton Candy Blue Rock'
            },
            'Rock-Golden': {
                'key': 'Rock-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Rock',
                'text': 'Golden Rock'
            },
            'Bunny-Base': {
                'key': 'Bunny-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Bunny',
                'text': 'Base Bunny'
            },
            'Bunny-White': {
                'key': 'Bunny-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Bunny',
                'text': 'White Bunny'
            },
            'Bunny-Desert': {
                'key': 'Bunny-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Bunny',
                'text': 'Desert Bunny'
            },
            'Bunny-Red': {
                'key': 'Bunny-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Bunny',
                'text': 'Red Bunny'
            },
            'Bunny-Shade': {
                'key': 'Bunny-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Bunny',
                'text': 'Shade Bunny'
            },
            'Bunny-Skeleton': {
                'key': 'Bunny-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Bunny',
                'text': 'Skeleton Bunny'
            },
            'Bunny-Zombie': {
                'key': 'Bunny-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Bunny',
                'text': 'Zombie Bunny'
            },
            'Bunny-CottonCandyPink': {
                'key': 'Bunny-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Bunny',
                'text': 'Cotton Candy Pink Bunny'
            },
            'Bunny-CottonCandyBlue': {
                'key': 'Bunny-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Bunny',
                'text': 'Cotton Candy Blue Bunny'
            },
            'Bunny-Golden': {
                'key': 'Bunny-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Bunny',
                'text': 'Golden Bunny'
            },
            'Slime-Base': {
                'key': 'Slime-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Slime',
                'text': 'Base Marshmallow Slime'
            },
            'Slime-White': {
                'key': 'Slime-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Slime',
                'text': 'White Marshmallow Slime'
            },
            'Slime-Desert': {
                'key': 'Slime-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Slime',
                'text': 'Desert Marshmallow Slime'
            },
            'Slime-Red': {
                'key': 'Slime-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Slime',
                'text': 'Red Marshmallow Slime'
            },
            'Slime-Shade': {
                'key': 'Slime-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Slime',
                'text': 'Shade Marshmallow Slime'
            },
            'Slime-Skeleton': {
                'key': 'Slime-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Slime',
                'text': 'Skeleton Marshmallow Slime'
            },
            'Slime-Zombie': {
                'key': 'Slime-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Slime',
                'text': 'Zombie Marshmallow Slime'
            },
            'Slime-CottonCandyPink': {
                'key': 'Slime-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Slime',
                'text': 'Cotton Candy Pink Marshmallow Slime'
            },
            'Slime-CottonCandyBlue': {
                'key': 'Slime-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Slime',
                'text': 'Cotton Candy Blue Marshmallow Slime'
            },
            'Slime-Golden': {
                'key': 'Slime-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Slime',
                'text': 'Golden Marshmallow Slime'
            },
            'Sheep-Base': {
                'key': 'Sheep-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Sheep',
                'text': 'Base Sheep'
            },
            'Sheep-White': {
                'key': 'Sheep-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Sheep',
                'text': 'White Sheep'
            },
            'Sheep-Desert': {
                'key': 'Sheep-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Sheep',
                'text': 'Desert Sheep'
            },
            'Sheep-Red': {
                'key': 'Sheep-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Sheep',
                'text': 'Red Sheep'
            },
            'Sheep-Shade': {
                'key': 'Sheep-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Sheep',
                'text': 'Shade Sheep'
            },
            'Sheep-Skeleton': {
                'key': 'Sheep-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Sheep',
                'text': 'Skeleton Sheep'
            },
            'Sheep-Zombie': {
                'key': 'Sheep-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Sheep',
                'text': 'Zombie Sheep'
            },
            'Sheep-CottonCandyPink': {
                'key': 'Sheep-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Sheep',
                'text': 'Cotton Candy Pink Sheep'
            },
            'Sheep-CottonCandyBlue': {
                'key': 'Sheep-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Sheep',
                'text': 'Cotton Candy Blue Sheep'
            },
            'Sheep-Golden': {
                'key': 'Sheep-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Sheep',
                'text': 'Golden Sheep'
            },
            'Cuttlefish-Base': {
                'key': 'Cuttlefish-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Cuttlefish',
                'text': 'Base Cuttlefish'
            },
            'Cuttlefish-White': {
                'key': 'Cuttlefish-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Cuttlefish',
                'text': 'White Cuttlefish'
            },
            'Cuttlefish-Desert': {
                'key': 'Cuttlefish-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Cuttlefish',
                'text': 'Desert Cuttlefish'
            },
            'Cuttlefish-Red': {
                'key': 'Cuttlefish-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Cuttlefish',
                'text': 'Red Cuttlefish'
            },
            'Cuttlefish-Shade': {
                'key': 'Cuttlefish-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Cuttlefish',
                'text': 'Shade Cuttlefish'
            },
            'Cuttlefish-Skeleton': {
                'key': 'Cuttlefish-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Cuttlefish',
                'text': 'Skeleton Cuttlefish'
            },
            'Cuttlefish-Zombie': {
                'key': 'Cuttlefish-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Cuttlefish',
                'text': 'Zombie Cuttlefish'
            },
            'Cuttlefish-CottonCandyPink': {
                'key': 'Cuttlefish-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Cuttlefish',
                'text': 'Cotton Candy Pink Cuttlefish'
            },
            'Cuttlefish-CottonCandyBlue': {
                'key': 'Cuttlefish-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Cuttlefish',
                'text': 'Cotton Candy Blue Cuttlefish'
            },
            'Cuttlefish-Golden': {
                'key': 'Cuttlefish-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Cuttlefish',
                'text': 'Golden Cuttlefish'
            },
            'Whale-Base': {
                'key': 'Whale-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Whale',
                'text': 'Base Whale'
            },
            'Whale-White': {
                'key': 'Whale-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Whale',
                'text': 'White Whale'
            },
            'Whale-Desert': {
                'key': 'Whale-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Whale',
                'text': 'Desert Whale'
            },
            'Whale-Red': {
                'key': 'Whale-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Whale',
                'text': 'Red Whale'
            },
            'Whale-Shade': {
                'key': 'Whale-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Whale',
                'text': 'Shade Whale'
            },
            'Whale-Skeleton': {
                'key': 'Whale-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Whale',
                'text': 'Skeleton Whale'
            },
            'Whale-Zombie': {
                'key': 'Whale-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Whale',
                'text': 'Zombie Whale'
            },
            'Whale-CottonCandyPink': {
                'key': 'Whale-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Whale',
                'text': 'Cotton Candy Pink Whale'
            },
            'Whale-CottonCandyBlue': {
                'key': 'Whale-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Whale',
                'text': 'Cotton Candy Blue Whale'
            },
            'Whale-Golden': {
                'key': 'Whale-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Whale',
                'text': 'Golden Whale'
            },
            'Cheetah-Base': {
                'key': 'Cheetah-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Cheetah',
                'text': 'Base Cheetah'
            },
            'Cheetah-White': {
                'key': 'Cheetah-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Cheetah',
                'text': 'White Cheetah'
            },
            'Cheetah-Desert': {
                'key': 'Cheetah-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Cheetah',
                'text': 'Desert Cheetah'
            },
            'Cheetah-Red': {
                'key': 'Cheetah-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Cheetah',
                'text': 'Red Cheetah'
            },
            'Cheetah-Shade': {
                'key': 'Cheetah-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Cheetah',
                'text': 'Shade Cheetah'
            },
            'Cheetah-Skeleton': {
                'key': 'Cheetah-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Cheetah',
                'text': 'Skeleton Cheetah'
            },
            'Cheetah-Zombie': {
                'key': 'Cheetah-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Cheetah',
                'text': 'Zombie Cheetah'
            },
            'Cheetah-CottonCandyPink': {
                'key': 'Cheetah-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Cheetah',
                'text': 'Cotton Candy Pink Cheetah'
            },
            'Cheetah-CottonCandyBlue': {
                'key': 'Cheetah-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Cheetah',
                'text': 'Cotton Candy Blue Cheetah'
            },
            'Cheetah-Golden': {
                'key': 'Cheetah-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Cheetah',
                'text': 'Golden Cheetah'
            },
            'Horse-Base': {
                'key': 'Horse-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Horse',
                'text': 'Base Horse'
            },
            'Horse-White': {
                'key': 'Horse-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Horse',
                'text': 'White Horse'
            },
            'Horse-Desert': {
                'key': 'Horse-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Horse',
                'text': 'Desert Horse'
            },
            'Horse-Red': {
                'key': 'Horse-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Horse',
                'text': 'Red Horse'
            },
            'Horse-Shade': {
                'key': 'Horse-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Horse',
                'text': 'Shade Horse'
            },
            'Horse-Skeleton': {
                'key': 'Horse-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Horse',
                'text': 'Skeleton Horse'
            },
            'Horse-Zombie': {
                'key': 'Horse-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Horse',
                'text': 'Zombie Horse'
            },
            'Horse-CottonCandyPink': {
                'key': 'Horse-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Horse',
                'text': 'Cotton Candy Pink Horse'
            },
            'Horse-CottonCandyBlue': {
                'key': 'Horse-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Horse',
                'text': 'Cotton Candy Blue Horse'
            },
            'Horse-Golden': {
                'key': 'Horse-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Horse',
                'text': 'Golden Horse'
            },
            'Frog-Base': {
                'key': 'Frog-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Frog',
                'text': 'Base Frog'
            },
            'Frog-White': {
                'key': 'Frog-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Frog',
                'text': 'White Frog'
            },
            'Frog-Desert': {
                'key': 'Frog-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Frog',
                'text': 'Desert Frog'
            },
            'Frog-Red': {
                'key': 'Frog-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Frog',
                'text': 'Red Frog'
            },
            'Frog-Shade': {
                'key': 'Frog-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Frog',
                'text': 'Shade Frog'
            },
            'Frog-Skeleton': {
                'key': 'Frog-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Frog',
                'text': 'Skeleton Frog'
            },
            'Frog-Zombie': {
                'key': 'Frog-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Frog',
                'text': 'Zombie Frog'
            },
            'Frog-CottonCandyPink': {
                'key': 'Frog-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Frog',
                'text': 'Cotton Candy Pink Frog'
            },
            'Frog-CottonCandyBlue': {
                'key': 'Frog-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Frog',
                'text': 'Cotton Candy Blue Frog'
            },
            'Frog-Golden': {
                'key': 'Frog-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Frog',
                'text': 'Golden Frog'
            },
            'Snake-Base': {
                'key': 'Snake-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Snake',
                'text': 'Base Snake'
            },
            'Snake-White': {
                'key': 'Snake-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Snake',
                'text': 'White Snake'
            },
            'Snake-Desert': {
                'key': 'Snake-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Snake',
                'text': 'Desert Snake'
            },
            'Snake-Red': {
                'key': 'Snake-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Snake',
                'text': 'Red Snake'
            },
            'Snake-Shade': {
                'key': 'Snake-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Snake',
                'text': 'Shade Snake'
            },
            'Snake-Skeleton': {
                'key': 'Snake-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Snake',
                'text': 'Skeleton Snake'
            },
            'Snake-Zombie': {
                'key': 'Snake-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Snake',
                'text': 'Zombie Snake'
            },
            'Snake-CottonCandyPink': {
                'key': 'Snake-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Snake',
                'text': 'Cotton Candy Pink Snake'
            },
            'Snake-CottonCandyBlue': {
                'key': 'Snake-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Snake',
                'text': 'Cotton Candy Blue Snake'
            },
            'Snake-Golden': {
                'key': 'Snake-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Snake',
                'text': 'Golden Snake'
            },
            'Unicorn-Base': {
                'key': 'Unicorn-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Unicorn',
                'text': 'Base Unicorn'
            },
            'Unicorn-White': {
                'key': 'Unicorn-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Unicorn',
                'text': 'White Unicorn'
            },
            'Unicorn-Desert': {
                'key': 'Unicorn-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Unicorn',
                'text': 'Desert Unicorn'
            },
            'Unicorn-Red': {
                'key': 'Unicorn-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Unicorn',
                'text': 'Red Unicorn'
            },
            'Unicorn-Shade': {
                'key': 'Unicorn-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Unicorn',
                'text': 'Shade Unicorn'
            },
            'Unicorn-Skeleton': {
                'key': 'Unicorn-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Unicorn',
                'text': 'Skeleton Unicorn'
            },
            'Unicorn-Zombie': {
                'key': 'Unicorn-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Unicorn',
                'text': 'Zombie Unicorn'
            },
            'Unicorn-CottonCandyPink': {
                'key': 'Unicorn-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Unicorn',
                'text': 'Cotton Candy Pink Unicorn'
            },
            'Unicorn-CottonCandyBlue': {
                'key': 'Unicorn-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Unicorn',
                'text': 'Cotton Candy Blue Unicorn'
            },
            'Unicorn-Golden': {
                'key': 'Unicorn-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Unicorn',
                'text': 'Golden Unicorn'
            },
            'Sabretooth-Base': {
                'key': 'Sabretooth-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Sabretooth',
                'text': 'Base Sabretooth Tiger'
            },
            'Sabretooth-White': {
                'key': 'Sabretooth-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Sabretooth',
                'text': 'White Sabretooth Tiger'
            },
            'Sabretooth-Desert': {
                'key': 'Sabretooth-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Sabretooth',
                'text': 'Desert Sabretooth Tiger'
            },
            'Sabretooth-Red': {
                'key': 'Sabretooth-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Sabretooth',
                'text': 'Red Sabretooth Tiger'
            },
            'Sabretooth-Shade': {
                'key': 'Sabretooth-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Sabretooth',
                'text': 'Shade Sabretooth Tiger'
            },
            'Sabretooth-Skeleton': {
                'key': 'Sabretooth-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Sabretooth',
                'text': 'Skeleton Sabretooth Tiger'
            },
            'Sabretooth-Zombie': {
                'key': 'Sabretooth-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Sabretooth',
                'text': 'Zombie Sabretooth Tiger'
            },
            'Sabretooth-CottonCandyPink': {
                'key': 'Sabretooth-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Sabretooth',
                'text': 'Cotton Candy Pink Sabretooth Tiger'
            },
            'Sabretooth-CottonCandyBlue': {
                'key': 'Sabretooth-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Sabretooth',
                'text': 'Cotton Candy Blue Sabretooth Tiger'
            },
            'Sabretooth-Golden': {
                'key': 'Sabretooth-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Sabretooth',
                'text': 'Golden Sabretooth Tiger'
            },
            'Monkey-Base': {
                'key': 'Monkey-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Monkey',
                'text': 'Base Monkey'
            },
            'Monkey-White': {
                'key': 'Monkey-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Monkey',
                'text': 'White Monkey'
            },
            'Monkey-Desert': {
                'key': 'Monkey-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Monkey',
                'text': 'Desert Monkey'
            },
            'Monkey-Red': {
                'key': 'Monkey-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Monkey',
                'text': 'Red Monkey'
            },
            'Monkey-Shade': {
                'key': 'Monkey-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Monkey',
                'text': 'Shade Monkey'
            },
            'Monkey-Skeleton': {
                'key': 'Monkey-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Monkey',
                'text': 'Skeleton Monkey'
            },
            'Monkey-Zombie': {
                'key': 'Monkey-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Monkey',
                'text': 'Zombie Monkey'
            },
            'Monkey-CottonCandyPink': {
                'key': 'Monkey-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Monkey',
                'text': 'Cotton Candy Pink Monkey'
            },
            'Monkey-CottonCandyBlue': {
                'key': 'Monkey-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Monkey',
                'text': 'Cotton Candy Blue Monkey'
            },
            'Monkey-Golden': {
                'key': 'Monkey-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Monkey',
                'text': 'Golden Monkey'
            },
            'Snail-Base': {
                'key': 'Snail-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Snail',
                'text': 'Base Snail'
            },
            'Snail-White': {
                'key': 'Snail-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Snail',
                'text': 'White Snail'
            },
            'Snail-Desert': {
                'key': 'Snail-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Snail',
                'text': 'Desert Snail'
            },
            'Snail-Red': {
                'key': 'Snail-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Snail',
                'text': 'Red Snail'
            },
            'Snail-Shade': {
                'key': 'Snail-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Snail',
                'text': 'Shade Snail'
            },
            'Snail-Skeleton': {
                'key': 'Snail-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Snail',
                'text': 'Skeleton Snail'
            },
            'Snail-Zombie': {
                'key': 'Snail-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Snail',
                'text': 'Zombie Snail'
            },
            'Snail-CottonCandyPink': {
                'key': 'Snail-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Snail',
                'text': 'Cotton Candy Pink Snail'
            },
            'Snail-CottonCandyBlue': {
                'key': 'Snail-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Snail',
                'text': 'Cotton Candy Blue Snail'
            },
            'Snail-Golden': {
                'key': 'Snail-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Snail',
                'text': 'Golden Snail'
            },
            'Falcon-Base': {
                'key': 'Falcon-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Falcon',
                'text': 'Base Falcon'
            },
            'Falcon-White': {
                'key': 'Falcon-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Falcon',
                'text': 'White Falcon'
            },
            'Falcon-Desert': {
                'key': 'Falcon-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Falcon',
                'text': 'Desert Falcon'
            },
            'Falcon-Red': {
                'key': 'Falcon-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Falcon',
                'text': 'Red Falcon'
            },
            'Falcon-Shade': {
                'key': 'Falcon-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Falcon',
                'text': 'Shade Falcon'
            },
            'Falcon-Skeleton': {
                'key': 'Falcon-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Falcon',
                'text': 'Skeleton Falcon'
            },
            'Falcon-Zombie': {
                'key': 'Falcon-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Falcon',
                'text': 'Zombie Falcon'
            },
            'Falcon-CottonCandyPink': {
                'key': 'Falcon-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Falcon',
                'text': 'Cotton Candy Pink Falcon'
            },
            'Falcon-CottonCandyBlue': {
                'key': 'Falcon-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Falcon',
                'text': 'Cotton Candy Blue Falcon'
            },
            'Falcon-Golden': {
                'key': 'Falcon-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Falcon',
                'text': 'Golden Falcon'
            },
            'Treeling-Base': {
                'key': 'Treeling-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Treeling',
                'text': 'Base Treeling'
            },
            'Treeling-White': {
                'key': 'Treeling-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Treeling',
                'text': 'White Treeling'
            },
            'Treeling-Desert': {
                'key': 'Treeling-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Treeling',
                'text': 'Desert Treeling'
            },
            'Treeling-Red': {
                'key': 'Treeling-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Treeling',
                'text': 'Red Treeling'
            },
            'Treeling-Shade': {
                'key': 'Treeling-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Treeling',
                'text': 'Shade Treeling'
            },
            'Treeling-Skeleton': {
                'key': 'Treeling-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Treeling',
                'text': 'Skeleton Treeling'
            },
            'Treeling-Zombie': {
                'key': 'Treeling-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Treeling',
                'text': 'Zombie Treeling'
            },
            'Treeling-CottonCandyPink': {
                'key': 'Treeling-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Treeling',
                'text': 'Cotton Candy Pink Treeling'
            },
            'Treeling-CottonCandyBlue': {
                'key': 'Treeling-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Treeling',
                'text': 'Cotton Candy Blue Treeling'
            },
            'Treeling-Golden': {
                'key': 'Treeling-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Treeling',
                'text': 'Golden Treeling'
            },
            'Axolotl-Base': {
                'key': 'Axolotl-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Axolotl',
                'text': 'Base Axolotl'
            },
            'Axolotl-White': {
                'key': 'Axolotl-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Axolotl',
                'text': 'White Axolotl'
            },
            'Axolotl-Desert': {
                'key': 'Axolotl-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Axolotl',
                'text': 'Desert Axolotl'
            },
            'Axolotl-Red': {
                'key': 'Axolotl-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Axolotl',
                'text': 'Red Axolotl'
            },
            'Axolotl-Shade': {
                'key': 'Axolotl-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Axolotl',
                'text': 'Shade Axolotl'
            },
            'Axolotl-Skeleton': {
                'key': 'Axolotl-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Axolotl',
                'text': 'Skeleton Axolotl'
            },
            'Axolotl-Zombie': {
                'key': 'Axolotl-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Axolotl',
                'text': 'Zombie Axolotl'
            },
            'Axolotl-CottonCandyPink': {
                'key': 'Axolotl-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Axolotl',
                'text': 'Cotton Candy Pink Axolotl'
            },
            'Axolotl-CottonCandyBlue': {
                'key': 'Axolotl-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Axolotl',
                'text': 'Cotton Candy Blue Axolotl'
            },
            'Axolotl-Golden': {
                'key': 'Axolotl-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Axolotl',
                'text': 'Golden Axolotl'
            },
            'Turtle-Base': {
                'key': 'Turtle-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Turtle',
                'text': 'Base Sea Turtle'
            },
            'Turtle-White': {
                'key': 'Turtle-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Turtle',
                'text': 'White Sea Turtle'
            },
            'Turtle-Desert': {
                'key': 'Turtle-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Turtle',
                'text': 'Desert Sea Turtle'
            },
            'Turtle-Red': {
                'key': 'Turtle-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Turtle',
                'text': 'Red Sea Turtle'
            },
            'Turtle-Shade': {
                'key': 'Turtle-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Turtle',
                'text': 'Shade Sea Turtle'
            },
            'Turtle-Skeleton': {
                'key': 'Turtle-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Turtle',
                'text': 'Skeleton Sea Turtle'
            },
            'Turtle-Zombie': {
                'key': 'Turtle-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Turtle',
                'text': 'Zombie Sea Turtle'
            },
            'Turtle-CottonCandyPink': {
                'key': 'Turtle-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Turtle',
                'text': 'Cotton Candy Pink Sea Turtle'
            },
            'Turtle-CottonCandyBlue': {
                'key': 'Turtle-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Turtle',
                'text': 'Cotton Candy Blue Sea Turtle'
            },
            'Turtle-Golden': {
                'key': 'Turtle-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Turtle',
                'text': 'Golden Sea Turtle'
            },
            'Armadillo-Base': {
                'key': 'Armadillo-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Armadillo',
                'text': 'Base Armadillo'
            },
            'Armadillo-White': {
                'key': 'Armadillo-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Armadillo',
                'text': 'White Armadillo'
            },
            'Armadillo-Desert': {
                'key': 'Armadillo-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Armadillo',
                'text': 'Desert Armadillo'
            },
            'Armadillo-Red': {
                'key': 'Armadillo-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Armadillo',
                'text': 'Red Armadillo'
            },
            'Armadillo-Shade': {
                'key': 'Armadillo-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Armadillo',
                'text': 'Shade Armadillo'
            },
            'Armadillo-Skeleton': {
                'key': 'Armadillo-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Armadillo',
                'text': 'Skeleton Armadillo'
            },
            'Armadillo-Zombie': {
                'key': 'Armadillo-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Armadillo',
                'text': 'Zombie Armadillo'
            },
            'Armadillo-CottonCandyPink': {
                'key': 'Armadillo-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Armadillo',
                'text': 'Cotton Candy Pink Armadillo'
            },
            'Armadillo-CottonCandyBlue': {
                'key': 'Armadillo-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Armadillo',
                'text': 'Cotton Candy Blue Armadillo'
            },
            'Armadillo-Golden': {
                'key': 'Armadillo-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Armadillo',
                'text': 'Golden Armadillo'
            },
            'Cow-Base': {
                'key': 'Cow-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Cow',
                'text': 'Base Cow'
            },
            'Cow-White': {
                'key': 'Cow-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Cow',
                'text': 'White Cow'
            },
            'Cow-Desert': {
                'key': 'Cow-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Cow',
                'text': 'Desert Cow'
            },
            'Cow-Red': {
                'key': 'Cow-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Cow',
                'text': 'Red Cow'
            },
            'Cow-Shade': {
                'key': 'Cow-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Cow',
                'text': 'Shade Cow'
            },
            'Cow-Skeleton': {
                'key': 'Cow-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Cow',
                'text': 'Skeleton Cow'
            },
            'Cow-Zombie': {
                'key': 'Cow-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Cow',
                'text': 'Zombie Cow'
            },
            'Cow-CottonCandyPink': {
                'key': 'Cow-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Cow',
                'text': 'Cotton Candy Pink Cow'
            },
            'Cow-CottonCandyBlue': {
                'key': 'Cow-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Cow',
                'text': 'Cotton Candy Blue Cow'
            },
            'Cow-Golden': {
                'key': 'Cow-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Cow',
                'text': 'Golden Cow'
            },
            'Beetle-Base': {
                'key': 'Beetle-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Beetle',
                'text': 'Base Beetle'
            },
            'Beetle-White': {
                'key': 'Beetle-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Beetle',
                'text': 'White Beetle'
            },
            'Beetle-Desert': {
                'key': 'Beetle-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Beetle',
                'text': 'Desert Beetle'
            },
            'Beetle-Red': {
                'key': 'Beetle-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Beetle',
                'text': 'Red Beetle'
            },
            'Beetle-Shade': {
                'key': 'Beetle-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Beetle',
                'text': 'Shade Beetle'
            },
            'Beetle-Skeleton': {
                'key': 'Beetle-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Beetle',
                'text': 'Skeleton Beetle'
            },
            'Beetle-Zombie': {
                'key': 'Beetle-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Beetle',
                'text': 'Zombie Beetle'
            },
            'Beetle-CottonCandyPink': {
                'key': 'Beetle-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Beetle',
                'text': 'Cotton Candy Pink Beetle'
            },
            'Beetle-CottonCandyBlue': {
                'key': 'Beetle-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Beetle',
                'text': 'Cotton Candy Blue Beetle'
            },
            'Beetle-Golden': {
                'key': 'Beetle-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Beetle',
                'text': 'Golden Beetle'
            },
            'Ferret-Base': {
                'key': 'Ferret-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Ferret',
                'text': 'Base Ferret'
            },
            'Ferret-White': {
                'key': 'Ferret-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Ferret',
                'text': 'White Ferret'
            },
            'Ferret-Desert': {
                'key': 'Ferret-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Ferret',
                'text': 'Desert Ferret'
            },
            'Ferret-Red': {
                'key': 'Ferret-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Ferret',
                'text': 'Red Ferret'
            },
            'Ferret-Shade': {
                'key': 'Ferret-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Ferret',
                'text': 'Shade Ferret'
            },
            'Ferret-Skeleton': {
                'key': 'Ferret-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Ferret',
                'text': 'Skeleton Ferret'
            },
            'Ferret-Zombie': {
                'key': 'Ferret-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Ferret',
                'text': 'Zombie Ferret'
            },
            'Ferret-CottonCandyPink': {
                'key': 'Ferret-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Ferret',
                'text': 'Cotton Candy Pink Ferret'
            },
            'Ferret-CottonCandyBlue': {
                'key': 'Ferret-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Ferret',
                'text': 'Cotton Candy Blue Ferret'
            },
            'Ferret-Golden': {
                'key': 'Ferret-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Ferret',
                'text': 'Golden Ferret'
            },
            'Sloth-Base': {
                'key': 'Sloth-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Sloth',
                'text': 'Base Sloth'
            },
            'Sloth-White': {
                'key': 'Sloth-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Sloth',
                'text': 'White Sloth'
            },
            'Sloth-Desert': {
                'key': 'Sloth-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Sloth',
                'text': 'Desert Sloth'
            },
            'Sloth-Red': {
                'key': 'Sloth-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Sloth',
                'text': 'Red Sloth'
            },
            'Sloth-Shade': {
                'key': 'Sloth-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Sloth',
                'text': 'Shade Sloth'
            },
            'Sloth-Skeleton': {
                'key': 'Sloth-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Sloth',
                'text': 'Skeleton Sloth'
            },
            'Sloth-Zombie': {
                'key': 'Sloth-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Sloth',
                'text': 'Zombie Sloth'
            },
            'Sloth-CottonCandyPink': {
                'key': 'Sloth-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Sloth',
                'text': 'Cotton Candy Pink Sloth'
            },
            'Sloth-CottonCandyBlue': {
                'key': 'Sloth-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Sloth',
                'text': 'Cotton Candy Blue Sloth'
            },
            'Sloth-Golden': {
                'key': 'Sloth-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Sloth',
                'text': 'Golden Sloth'
            },
            'Triceratops-Base': {
                'key': 'Triceratops-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Triceratops',
                'text': 'Base Triceratops'
            },
            'Triceratops-White': {
                'key': 'Triceratops-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Triceratops',
                'text': 'White Triceratops'
            },
            'Triceratops-Desert': {
                'key': 'Triceratops-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Triceratops',
                'text': 'Desert Triceratops'
            },
            'Triceratops-Red': {
                'key': 'Triceratops-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Triceratops',
                'text': 'Red Triceratops'
            },
            'Triceratops-Shade': {
                'key': 'Triceratops-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Triceratops',
                'text': 'Shade Triceratops'
            },
            'Triceratops-Skeleton': {
                'key': 'Triceratops-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Triceratops',
                'text': 'Skeleton Triceratops'
            },
            'Triceratops-Zombie': {
                'key': 'Triceratops-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Triceratops',
                'text': 'Zombie Triceratops'
            },
            'Triceratops-CottonCandyPink': {
                'key': 'Triceratops-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Triceratops',
                'text': 'Cotton Candy Pink Triceratops'
            },
            'Triceratops-CottonCandyBlue': {
                'key': 'Triceratops-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Triceratops',
                'text': 'Cotton Candy Blue Triceratops'
            },
            'Triceratops-Golden': {
                'key': 'Triceratops-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Triceratops',
                'text': 'Golden Triceratops'
            },
            'GuineaPig-Base': {
                'key': 'GuineaPig-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'GuineaPig',
                'text': 'Base Guinea Pig'
            },
            'GuineaPig-White': {
                'key': 'GuineaPig-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'GuineaPig',
                'text': 'White Guinea Pig'
            },
            'GuineaPig-Desert': {
                'key': 'GuineaPig-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'GuineaPig',
                'text': 'Desert Guinea Pig'
            },
            'GuineaPig-Red': {
                'key': 'GuineaPig-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'GuineaPig',
                'text': 'Red Guinea Pig'
            },
            'GuineaPig-Shade': {
                'key': 'GuineaPig-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'GuineaPig',
                'text': 'Shade Guinea Pig'
            },
            'GuineaPig-Skeleton': {
                'key': 'GuineaPig-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'GuineaPig',
                'text': 'Skeleton Guinea Pig'
            },
            'GuineaPig-Zombie': {
                'key': 'GuineaPig-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'GuineaPig',
                'text': 'Zombie Guinea Pig'
            },
            'GuineaPig-CottonCandyPink': {
                'key': 'GuineaPig-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'GuineaPig',
                'text': 'Cotton Candy Pink Guinea Pig'
            },
            'GuineaPig-CottonCandyBlue': {
                'key': 'GuineaPig-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'GuineaPig',
                'text': 'Cotton Candy Blue Guinea Pig'
            },
            'GuineaPig-Golden': {
                'key': 'GuineaPig-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'GuineaPig',
                'text': 'Golden Guinea Pig'
            },
            'Peacock-Base': {
                'key': 'Peacock-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Peacock',
                'text': 'Base Peacock'
            },
            'Peacock-White': {
                'key': 'Peacock-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Peacock',
                'text': 'White Peacock'
            },
            'Peacock-Desert': {
                'key': 'Peacock-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Peacock',
                'text': 'Desert Peacock'
            },
            'Peacock-Red': {
                'key': 'Peacock-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Peacock',
                'text': 'Red Peacock'
            },
            'Peacock-Shade': {
                'key': 'Peacock-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Peacock',
                'text': 'Shade Peacock'
            },
            'Peacock-Skeleton': {
                'key': 'Peacock-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Peacock',
                'text': 'Skeleton Peacock'
            },
            'Peacock-Zombie': {
                'key': 'Peacock-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Peacock',
                'text': 'Zombie Peacock'
            },
            'Peacock-CottonCandyPink': {
                'key': 'Peacock-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Peacock',
                'text': 'Cotton Candy Pink Peacock'
            },
            'Peacock-CottonCandyBlue': {
                'key': 'Peacock-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Peacock',
                'text': 'Cotton Candy Blue Peacock'
            },
            'Peacock-Golden': {
                'key': 'Peacock-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Peacock',
                'text': 'Golden Peacock'
            },
            'Butterfly-Base': {
                'key': 'Butterfly-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Butterfly',
                'text': 'Base Caterpillar'
            },
            'Butterfly-White': {
                'key': 'Butterfly-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Butterfly',
                'text': 'White Caterpillar'
            },
            'Butterfly-Desert': {
                'key': 'Butterfly-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Butterfly',
                'text': 'Desert Caterpillar'
            },
            'Butterfly-Red': {
                'key': 'Butterfly-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Butterfly',
                'text': 'Red Caterpillar'
            },
            'Butterfly-Shade': {
                'key': 'Butterfly-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Butterfly',
                'text': 'Shade Caterpillar'
            },
            'Butterfly-Skeleton': {
                'key': 'Butterfly-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Butterfly',
                'text': 'Skeleton Caterpillar'
            },
            'Butterfly-Zombie': {
                'key': 'Butterfly-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Butterfly',
                'text': 'Zombie Caterpillar'
            },
            'Butterfly-CottonCandyPink': {
                'key': 'Butterfly-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Butterfly',
                'text': 'Cotton Candy Pink Caterpillar'
            },
            'Butterfly-CottonCandyBlue': {
                'key': 'Butterfly-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Butterfly',
                'text': 'Cotton Candy Blue Caterpillar'
            },
            'Butterfly-Golden': {
                'key': 'Butterfly-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Butterfly',
                'text': 'Golden Caterpillar'
            },
            'Nudibranch-Base': {
                'key': 'Nudibranch-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Nudibranch',
                'text': 'Base Nudibranch'
            },
            'Nudibranch-White': {
                'key': 'Nudibranch-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Nudibranch',
                'text': 'White Nudibranch'
            },
            'Nudibranch-Desert': {
                'key': 'Nudibranch-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Nudibranch',
                'text': 'Desert Nudibranch'
            },
            'Nudibranch-Red': {
                'key': 'Nudibranch-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Nudibranch',
                'text': 'Red Nudibranch'
            },
            'Nudibranch-Shade': {
                'key': 'Nudibranch-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Nudibranch',
                'text': 'Shade Nudibranch'
            },
            'Nudibranch-Skeleton': {
                'key': 'Nudibranch-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Nudibranch',
                'text': 'Skeleton Nudibranch'
            },
            'Nudibranch-Zombie': {
                'key': 'Nudibranch-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Nudibranch',
                'text': 'Zombie Nudibranch'
            },
            'Nudibranch-CottonCandyPink': {
                'key': 'Nudibranch-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Nudibranch',
                'text': 'Cotton Candy Pink Nudibranch'
            },
            'Nudibranch-CottonCandyBlue': {
                'key': 'Nudibranch-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Nudibranch',
                'text': 'Cotton Candy Blue Nudibranch'
            },
            'Nudibranch-Golden': {
                'key': 'Nudibranch-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Nudibranch',
                'text': 'Golden Nudibranch'
            },
            'Hippo-Base': {
                'key': 'Hippo-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Hippo',
                'text': 'Base Hippo'
            },
            'Hippo-White': {
                'key': 'Hippo-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Hippo',
                'text': 'White Hippo'
            },
            'Hippo-Desert': {
                'key': 'Hippo-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Hippo',
                'text': 'Desert Hippo'
            },
            'Hippo-Red': {
                'key': 'Hippo-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Hippo',
                'text': 'Red Hippo'
            },
            'Hippo-Shade': {
                'key': 'Hippo-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Hippo',
                'text': 'Shade Hippo'
            },
            'Hippo-Skeleton': {
                'key': 'Hippo-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Hippo',
                'text': 'Skeleton Hippo'
            },
            'Hippo-Zombie': {
                'key': 'Hippo-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Hippo',
                'text': 'Zombie Hippo'
            },
            'Hippo-CottonCandyPink': {
                'key': 'Hippo-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Hippo',
                'text': 'Cotton Candy Pink Hippo'
            },
            'Hippo-CottonCandyBlue': {
                'key': 'Hippo-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Hippo',
                'text': 'Cotton Candy Blue Hippo'
            },
            'Hippo-Golden': {
                'key': 'Hippo-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Hippo',
                'text': 'Golden Hippo'
            },
            'Yarn-Base': {
                'key': 'Yarn-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Yarn',
                'text': 'Base Yarn'
            },
            'Yarn-White': {
                'key': 'Yarn-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Yarn',
                'text': 'White Yarn'
            },
            'Yarn-Desert': {
                'key': 'Yarn-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Yarn',
                'text': 'Desert Yarn'
            },
            'Yarn-Red': {
                'key': 'Yarn-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Yarn',
                'text': 'Red Yarn'
            },
            'Yarn-Shade': {
                'key': 'Yarn-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Yarn',
                'text': 'Shade Yarn'
            },
            'Yarn-Skeleton': {
                'key': 'Yarn-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Yarn',
                'text': 'Skeleton Yarn'
            },
            'Yarn-Zombie': {
                'key': 'Yarn-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Yarn',
                'text': 'Zombie Yarn'
            },
            'Yarn-CottonCandyPink': {
                'key': 'Yarn-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Yarn',
                'text': 'Cotton Candy Pink Yarn'
            },
            'Yarn-CottonCandyBlue': {
                'key': 'Yarn-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Yarn',
                'text': 'Cotton Candy Blue Yarn'
            },
            'Yarn-Golden': {
                'key': 'Yarn-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Yarn',
                'text': 'Golden Yarn'
            },
            'Pterodactyl-Base': {
                'key': 'Pterodactyl-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Pterodactyl',
                'text': 'Base Pterodactyl'
            },
            'Pterodactyl-White': {
                'key': 'Pterodactyl-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Pterodactyl',
                'text': 'White Pterodactyl'
            },
            'Pterodactyl-Desert': {
                'key': 'Pterodactyl-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Pterodactyl',
                'text': 'Desert Pterodactyl'
            },
            'Pterodactyl-Red': {
                'key': 'Pterodactyl-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Pterodactyl',
                'text': 'Red Pterodactyl'
            },
            'Pterodactyl-Shade': {
                'key': 'Pterodactyl-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Pterodactyl',
                'text': 'Shade Pterodactyl'
            },
            'Pterodactyl-Skeleton': {
                'key': 'Pterodactyl-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Pterodactyl',
                'text': 'Skeleton Pterodactyl'
            },
            'Pterodactyl-Zombie': {
                'key': 'Pterodactyl-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Pterodactyl',
                'text': 'Zombie Pterodactyl'
            },
            'Pterodactyl-CottonCandyPink': {
                'key': 'Pterodactyl-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Pterodactyl',
                'text': 'Cotton Candy Pink Pterodactyl'
            },
            'Pterodactyl-CottonCandyBlue': {
                'key': 'Pterodactyl-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Pterodactyl',
                'text': 'Cotton Candy Blue Pterodactyl'
            },
            'Pterodactyl-Golden': {
                'key': 'Pterodactyl-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Pterodactyl',
                'text': 'Golden Pterodactyl'
            },
            'Badger-Base': {
                'key': 'Badger-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Badger',
                'text': 'Base Badger'
            },
            'Badger-White': {
                'key': 'Badger-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Badger',
                'text': 'White Badger'
            },
            'Badger-Desert': {
                'key': 'Badger-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Badger',
                'text': 'Desert Badger'
            },
            'Badger-Red': {
                'key': 'Badger-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Badger',
                'text': 'Red Badger'
            },
            'Badger-Shade': {
                'key': 'Badger-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Badger',
                'text': 'Shade Badger'
            },
            'Badger-Skeleton': {
                'key': 'Badger-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Badger',
                'text': 'Skeleton Badger'
            },
            'Badger-Zombie': {
                'key': 'Badger-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Badger',
                'text': 'Zombie Badger'
            },
            'Badger-CottonCandyPink': {
                'key': 'Badger-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Badger',
                'text': 'Cotton Candy Pink Badger'
            },
            'Badger-CottonCandyBlue': {
                'key': 'Badger-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Badger',
                'text': 'Cotton Candy Blue Badger'
            },
            'Badger-Golden': {
                'key': 'Badger-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Badger',
                'text': 'Golden Badger'
            },
            'Squirrel-Base': {
                'key': 'Squirrel-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Squirrel',
                'text': 'Base Squirrel'
            },
            'Squirrel-White': {
                'key': 'Squirrel-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Squirrel',
                'text': 'White Squirrel'
            },
            'Squirrel-Desert': {
                'key': 'Squirrel-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Squirrel',
                'text': 'Desert Squirrel'
            },
            'Squirrel-Red': {
                'key': 'Squirrel-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Squirrel',
                'text': 'Red Squirrel'
            },
            'Squirrel-Shade': {
                'key': 'Squirrel-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Squirrel',
                'text': 'Shade Squirrel'
            },
            'Squirrel-Skeleton': {
                'key': 'Squirrel-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Squirrel',
                'text': 'Skeleton Squirrel'
            },
            'Squirrel-Zombie': {
                'key': 'Squirrel-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Squirrel',
                'text': 'Zombie Squirrel'
            },
            'Squirrel-CottonCandyPink': {
                'key': 'Squirrel-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Squirrel',
                'text': 'Cotton Candy Pink Squirrel'
            },
            'Squirrel-CottonCandyBlue': {
                'key': 'Squirrel-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Squirrel',
                'text': 'Cotton Candy Blue Squirrel'
            },
            'Squirrel-Golden': {
                'key': 'Squirrel-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Squirrel',
                'text': 'Golden Squirrel'
            },
            'SeaSerpent-Base': {
                'key': 'SeaSerpent-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'SeaSerpent',
                'text': 'Base Sea Serpent'
            },
            'SeaSerpent-White': {
                'key': 'SeaSerpent-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'SeaSerpent',
                'text': 'White Sea Serpent'
            },
            'SeaSerpent-Desert': {
                'key': 'SeaSerpent-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'SeaSerpent',
                'text': 'Desert Sea Serpent'
            },
            'SeaSerpent-Red': {
                'key': 'SeaSerpent-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'SeaSerpent',
                'text': 'Red Sea Serpent'
            },
            'SeaSerpent-Shade': {
                'key': 'SeaSerpent-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'SeaSerpent',
                'text': 'Shade Sea Serpent'
            },
            'SeaSerpent-Skeleton': {
                'key': 'SeaSerpent-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'SeaSerpent',
                'text': 'Skeleton Sea Serpent'
            },
            'SeaSerpent-Zombie': {
                'key': 'SeaSerpent-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'SeaSerpent',
                'text': 'Zombie Sea Serpent'
            },
            'SeaSerpent-CottonCandyPink': {
                'key': 'SeaSerpent-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'SeaSerpent',
                'text': 'Cotton Candy Pink Sea Serpent'
            },
            'SeaSerpent-CottonCandyBlue': {
                'key': 'SeaSerpent-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'SeaSerpent',
                'text': 'Cotton Candy Blue Sea Serpent'
            },
            'SeaSerpent-Golden': {
                'key': 'SeaSerpent-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'SeaSerpent',
                'text': 'Golden Sea Serpent'
            },
            'Kangaroo-Base': {
                'key': 'Kangaroo-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Kangaroo',
                'text': 'Base Kangaroo'
            },
            'Kangaroo-White': {
                'key': 'Kangaroo-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Kangaroo',
                'text': 'White Kangaroo'
            },
            'Kangaroo-Desert': {
                'key': 'Kangaroo-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Kangaroo',
                'text': 'Desert Kangaroo'
            },
            'Kangaroo-Red': {
                'key': 'Kangaroo-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Kangaroo',
                'text': 'Red Kangaroo'
            },
            'Kangaroo-Shade': {
                'key': 'Kangaroo-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Kangaroo',
                'text': 'Shade Kangaroo'
            },
            'Kangaroo-Skeleton': {
                'key': 'Kangaroo-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Kangaroo',
                'text': 'Skeleton Kangaroo'
            },
            'Kangaroo-Zombie': {
                'key': 'Kangaroo-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Kangaroo',
                'text': 'Zombie Kangaroo'
            },
            'Kangaroo-CottonCandyPink': {
                'key': 'Kangaroo-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Kangaroo',
                'text': 'Cotton Candy Pink Kangaroo'
            },
            'Kangaroo-CottonCandyBlue': {
                'key': 'Kangaroo-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Kangaroo',
                'text': 'Cotton Candy Blue Kangaroo'
            },
            'Kangaroo-Golden': {
                'key': 'Kangaroo-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Kangaroo',
                'text': 'Golden Kangaroo'
            },
            'Alligator-Base': {
                'key': 'Alligator-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Alligator',
                'text': 'Base Alligator'
            },
            'Alligator-White': {
                'key': 'Alligator-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Alligator',
                'text': 'White Alligator'
            },
            'Alligator-Desert': {
                'key': 'Alligator-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Alligator',
                'text': 'Desert Alligator'
            },
            'Alligator-Red': {
                'key': 'Alligator-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Alligator',
                'text': 'Red Alligator'
            },
            'Alligator-Shade': {
                'key': 'Alligator-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Alligator',
                'text': 'Shade Alligator'
            },
            'Alligator-Skeleton': {
                'key': 'Alligator-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Alligator',
                'text': 'Skeleton Alligator'
            },
            'Alligator-Zombie': {
                'key': 'Alligator-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Alligator',
                'text': 'Zombie Alligator'
            },
            'Alligator-CottonCandyPink': {
                'key': 'Alligator-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Alligator',
                'text': 'Cotton Candy Pink Alligator'
            },
            'Alligator-CottonCandyBlue': {
                'key': 'Alligator-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Alligator',
                'text': 'Cotton Candy Blue Alligator'
            },
            'Alligator-Golden': {
                'key': 'Alligator-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Alligator',
                'text': 'Golden Alligator'
            },
            'Velociraptor-Base': {
                'key': 'Velociraptor-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Velociraptor',
                'text': 'Base Velociraptor'
            },
            'Velociraptor-White': {
                'key': 'Velociraptor-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Velociraptor',
                'text': 'White Velociraptor'
            },
            'Velociraptor-Desert': {
                'key': 'Velociraptor-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Velociraptor',
                'text': 'Desert Velociraptor'
            },
            'Velociraptor-Red': {
                'key': 'Velociraptor-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Velociraptor',
                'text': 'Red Velociraptor'
            },
            'Velociraptor-Shade': {
                'key': 'Velociraptor-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Velociraptor',
                'text': 'Shade Velociraptor'
            },
            'Velociraptor-Skeleton': {
                'key': 'Velociraptor-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Velociraptor',
                'text': 'Skeleton Velociraptor'
            },
            'Velociraptor-Zombie': {
                'key': 'Velociraptor-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Velociraptor',
                'text': 'Zombie Velociraptor'
            },
            'Velociraptor-CottonCandyPink': {
                'key': 'Velociraptor-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Velociraptor',
                'text': 'Cotton Candy Pink Velociraptor'
            },
            'Velociraptor-CottonCandyBlue': {
                'key': 'Velociraptor-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Velociraptor',
                'text': 'Cotton Candy Blue Velociraptor'
            },
            'Velociraptor-Golden': {
                'key': 'Velociraptor-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Velociraptor',
                'text': 'Golden Velociraptor'
            },
            'Dolphin-Base': {
                'key': 'Dolphin-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Dolphin',
                'text': 'Base Dolphin'
            },
            'Dolphin-White': {
                'key': 'Dolphin-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Dolphin',
                'text': 'White Dolphin'
            },
            'Dolphin-Desert': {
                'key': 'Dolphin-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Dolphin',
                'text': 'Desert Dolphin'
            },
            'Dolphin-Red': {
                'key': 'Dolphin-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Dolphin',
                'text': 'Red Dolphin'
            },
            'Dolphin-Shade': {
                'key': 'Dolphin-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Dolphin',
                'text': 'Shade Dolphin'
            },
            'Dolphin-Skeleton': {
                'key': 'Dolphin-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Dolphin',
                'text': 'Skeleton Dolphin'
            },
            'Dolphin-Zombie': {
                'key': 'Dolphin-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Dolphin',
                'text': 'Zombie Dolphin'
            },
            'Dolphin-CottonCandyPink': {
                'key': 'Dolphin-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Dolphin',
                'text': 'Cotton Candy Pink Dolphin'
            },
            'Dolphin-CottonCandyBlue': {
                'key': 'Dolphin-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Dolphin',
                'text': 'Cotton Candy Blue Dolphin'
            },
            'Dolphin-Golden': {
                'key': 'Dolphin-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Dolphin',
                'text': 'Golden Dolphin'
            },
            'Robot-Base': {
                'key': 'Robot-Base',
                'type': 'quest',
                'potion': 'Base',
                'egg': 'Robot',
                'text': 'Base Robot'
            },
            'Robot-White': {
                'key': 'Robot-White',
                'type': 'quest',
                'potion': 'White',
                'egg': 'Robot',
                'text': 'White Robot'
            },
            'Robot-Desert': {
                'key': 'Robot-Desert',
                'type': 'quest',
                'potion': 'Desert',
                'egg': 'Robot',
                'text': 'Desert Robot'
            },
            'Robot-Red': {
                'key': 'Robot-Red',
                'type': 'quest',
                'potion': 'Red',
                'egg': 'Robot',
                'text': 'Red Robot'
            },
            'Robot-Shade': {
                'key': 'Robot-Shade',
                'type': 'quest',
                'potion': 'Shade',
                'egg': 'Robot',
                'text': 'Shade Robot'
            },
            'Robot-Skeleton': {
                'key': 'Robot-Skeleton',
                'type': 'quest',
                'potion': 'Skeleton',
                'egg': 'Robot',
                'text': 'Skeleton Robot'
            },
            'Robot-Zombie': {
                'key': 'Robot-Zombie',
                'type': 'quest',
                'potion': 'Zombie',
                'egg': 'Robot',
                'text': 'Zombie Robot'
            },
            'Robot-CottonCandyPink': {
                'key': 'Robot-CottonCandyPink',
                'type': 'quest',
                'potion': 'CottonCandyPink',
                'egg': 'Robot',
                'text': 'Cotton Candy Pink Robot'
            },
            'Robot-CottonCandyBlue': {
                'key': 'Robot-CottonCandyBlue',
                'type': 'quest',
                'potion': 'CottonCandyBlue',
                'egg': 'Robot',
                'text': 'Cotton Candy Blue Robot'
            },
            'Robot-Golden': {
                'key': 'Robot-Golden',
                'type': 'quest',
                'potion': 'Golden',
                'egg': 'Robot',
                'text': 'Golden Robot'
            },
            'Wolf-Veggie': {
                'key': 'Wolf-Veggie',
                'type': 'wacky',
                'potion': 'Veggie',
                'egg': 'Wolf',
                'text': 'Garden Wolf'
            },
            'Wolf-Dessert': {
                'key': 'Wolf-Dessert',
                'type': 'wacky',
                'potion': 'Dessert',
                'egg': 'Wolf',
                'text': 'Confection Wolf'
            },
            'TigerCub-Veggie': {
                'key': 'TigerCub-Veggie',
                'type': 'wacky',
                'potion': 'Veggie',
                'egg': 'TigerCub',
                'text': 'Garden Tiger Cub'
            },
            'TigerCub-Dessert': {
                'key': 'TigerCub-Dessert',
                'type': 'wacky',
                'potion': 'Dessert',
                'egg': 'TigerCub',
                'text': 'Confection Tiger Cub'
            },
            'PandaCub-Veggie': {
                'key': 'PandaCub-Veggie',
                'type': 'wacky',
                'potion': 'Veggie',
                'egg': 'PandaCub',
                'text': 'Garden Panda Cub'
            },
            'PandaCub-Dessert': {
                'key': 'PandaCub-Dessert',
                'type': 'wacky',
                'potion': 'Dessert',
                'egg': 'PandaCub',
                'text': 'Confection Panda Cub'
            },
            'LionCub-Veggie': {
                'key': 'LionCub-Veggie',
                'type': 'wacky',
                'potion': 'Veggie',
                'egg': 'LionCub',
                'text': 'Garden Lion Cub'
            },
            'LionCub-Dessert': {
                'key': 'LionCub-Dessert',
                'type': 'wacky',
                'potion': 'Dessert',
                'egg': 'LionCub',
                'text': 'Confection Lion Cub'
            },
            'Fox-Veggie': {
                'key': 'Fox-Veggie',
                'type': 'wacky',
                'potion': 'Veggie',
                'egg': 'Fox',
                'text': 'Garden Fox'
            },
            'Fox-Dessert': {
                'key': 'Fox-Dessert',
                'type': 'wacky',
                'potion': 'Dessert',
                'egg': 'Fox',
                'text': 'Confection Fox'
            },
            'FlyingPig-Veggie': {
                'key': 'FlyingPig-Veggie',
                'type': 'wacky',
                'potion': 'Veggie',
                'egg': 'FlyingPig',
                'text': 'Garden Flying Pig'
            },
            'FlyingPig-Dessert': {
                'key': 'FlyingPig-Dessert',
                'type': 'wacky',
                'potion': 'Dessert',
                'egg': 'FlyingPig',
                'text': 'Confection Flying Pig'
            },
            'Dragon-Veggie': {
                'key': 'Dragon-Veggie',
                'type': 'wacky',
                'potion': 'Veggie',
                'egg': 'Dragon',
                'text': 'Garden Dragon'
            },
            'Dragon-Dessert': {
                'key': 'Dragon-Dessert',
                'type': 'wacky',
                'potion': 'Dessert',
                'egg': 'Dragon',
                'text': 'Confection Dragon'
            },
            'Cactus-Veggie': {
                'key': 'Cactus-Veggie',
                'type': 'wacky',
                'potion': 'Veggie',
                'egg': 'Cactus',
                'text': 'Garden Cactus'
            },
            'Cactus-Dessert': {
                'key': 'Cactus-Dessert',
                'type': 'wacky',
                'potion': 'Dessert',
                'egg': 'Cactus',
                'text': 'Confection Cactus'
            },
            'BearCub-Veggie': {
                'key': 'BearCub-Veggie',
                'type': 'wacky',
                'potion': 'Veggie',
                'egg': 'BearCub',
                'text': 'Garden Bear Cub'
            },
            'BearCub-Dessert': {
                'key': 'BearCub-Dessert',
                'type': 'wacky',
                'potion': 'Dessert',
                'egg': 'BearCub',
                'text': 'Confection Bear Cub'
            },
            'Wolf-Veteran': {
                'key': 'Wolf-Veteran',
                'type': 'special',
                'text': 'Veteran Wolf',
                'canFind': false
            },
            'Wolf-Cerberus': {
                'key': 'Wolf-Cerberus',
                'type': 'special',
                'text': 'Cerberus Pup',
                'canFind': false
            },
            'Dragon-Hydra': {
                'key': 'Dragon-Hydra',
                'type': 'special',
                'text': 'Hydra',
                'canFind': true
            },
            'Turkey-Base': {
                'key': 'Turkey-Base',
                'type': 'special',
                'text': 'Turkey',
                'canFind': false
            },
            'BearCub-Polar': {
                'key': 'BearCub-Polar',
                'type': 'special',
                'text': 'Polar Bear Cub',
                'canFind': true
            },
            'MantisShrimp-Base': {
                'key': 'MantisShrimp-Base',
                'type': 'special',
                'text': 'Mantis Shrimp',
                'canFind': true
            },
            'JackOLantern-Base': {
                'key': 'JackOLantern-Base',
                'type': 'special',
                'text': 'Jack-O-Lantern',
                'canFind': false
            },
            'Mammoth-Base': {
                'key': 'Mammoth-Base',
                'type': 'special',
                'text': 'Woolly Mammoth',
                'canFind': true
            },
            'Tiger-Veteran': {
                'key': 'Tiger-Veteran',
                'type': 'special',
                'text': 'Veteran Tiger',
                'canFind': false
            },
            'Phoenix-Base': {
                'key': 'Phoenix-Base',
                'type': 'special',
                'text': 'Phoenix',
                'canFind': true
            },
            'Turkey-Gilded': {
                'key': 'Turkey-Gilded',
                'type': 'special',
                'text': 'Gilded Turkey',
                'canFind': false
            },
            'MagicalBee-Base': {
                'key': 'MagicalBee-Base',
                'type': 'special',
                'text': 'Magical Bee',
                'canFind': true
            },
            'Lion-Veteran': {
                'key': 'Lion-Veteran',
                'type': 'special',
                'text': 'Veteran Lion',
                'canFind': false
            },
            'Gryphon-RoyalPurple': {
                'key': 'Gryphon-RoyalPurple',
                'type': 'special',
                'text': 'Royal Purple Gryphon',
                'canFind': false
            },
            'JackOLantern-Ghost': {
                'key': 'JackOLantern-Ghost',
                'type': 'special',
                'text': 'Ghost Jack-O-Lantern',
                'canFind': false
            },
            'Jackalope-RoyalPurple': {
                'key': 'Jackalope-RoyalPurple',
                'type': 'special',
                'text': 'Royal Purple Jackalope',
                'canFind': true
            },
            'Orca-Base': {
                'key': 'Orca-Base',
                'type': 'special',
                'text': 'Orca',
                'canFind': false
            },
            'Bear-Veteran': {
                'key': 'Bear-Veteran',
                'type': 'special',
                'text': 'Veteran Bear',
                'canFind': false
            },
            'Hippogriff-Hopeful': {
                'key': 'Hippogriff-Hopeful',
                'type': 'special',
                'text': 'Hopeful Hippogriff',
                'canFind': true
            },
            'Fox-Veteran': {
                'key': 'Fox-Veteran',
                'type': 'special',
                'text': 'Veteran Fox',
                'canFind': false
            },
            'JackOLantern-Glow': {
                'key': 'JackOLantern-Glow',
                'type': 'special',
                'text': 'Glow-in-the-Dark Jack-O-Lantern',
                'canFind': false
            },
            'Gryphon-Gryphatrice': {
                'key': 'Gryphon-Gryphatrice',
                'type': 'special',
                'text': 'Gryphatrice',
                'canFind': false
            },
            'JackOLantern-RoyalPurple': {
                'key': 'JackOLantern-RoyalPurple',
                'type': 'special',
                'text': 'Royal Purple Jack-O-Lantern',
                'canFind': false
            }
        },
        'food': {
                    'Meat': {
                        'text': 'Meat',
                        'textA': 'Meat',
                        'textThe': 'the Meat',
                        'target': 'Base',
                        'canDrop': true,
                        'value': 1,
                        'key': 'Meat',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Milk': {
                        'text': 'Milk',
                        'textA': 'Milk',
                        'textThe': 'the Milk',
                        'target': 'White',
                        'canDrop': true,
                        'value': 1,
                        'key': 'Milk',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Potatoe': {
                        'text': 'Potato',
                        'textA': 'a Potato',
                        'textThe': 'the Potato',
                        'target': 'Desert',
                        'canDrop': true,
                        'value': 1,
                        'key': 'Potatoe',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Strawberry': {
                        'text': 'Strawberry',
                        'textA': 'a Strawberry',
                        'textThe': 'the Strawberry',
                        'target': 'Red',
                        'canDrop': true,
                        'value': 1,
                        'key': 'Strawberry',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Chocolate': {
                        'text': 'Chocolate',
                        'textA': 'Chocolate',
                        'textThe': 'the Chocolate',
                        'target': 'Shade',
                        'canDrop': true,
                        'value': 1,
                        'key': 'Chocolate',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Fish': {
                        'text': 'Fish',
                        'textA': 'a Fish',
                        'textThe': 'the Fish',
                        'target': 'Skeleton',
                        'canDrop': true,
                        'value': 1,
                        'key': 'Fish',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'RottenMeat': {
                        'text': 'Rotten Meat',
                        'textA': 'Rotten Meat',
                        'textThe': 'the Rotten Meat',
                        'target': 'Zombie',
                        'canDrop': true,
                        'value': 1,
                        'key': 'RottenMeat',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'CottonCandyPink': {
                        'text': 'Pink Cotton Candy',
                        'textA': 'Pink Cotton Candy',
                        'textThe': 'the Pink Cotton Candy',
                        'target': 'CottonCandyPink',
                        'canDrop': true,
                        'value': 1,
                        'key': 'CottonCandyPink',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'CottonCandyBlue': {
                        'text': 'Blue Cotton Candy',
                        'textA': 'Blue Cotton Candy',
                        'textThe': 'the Blue Cotton Candy',
                        'target': 'CottonCandyBlue',
                        'canDrop': true,
                        'value': 1,
                        'key': 'CottonCandyBlue',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Honey': {
                        'text': 'Honey',
                        'textA': 'Honey',
                        'textThe': 'the Honey',
                        'target': 'Golden',
                        'canDrop': true,
                        'value': 1,
                        'key': 'Honey',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Saddle': {
                        'sellWarningNote': 'Hey! This is a pretty useful item! Are you familiar with how to use a Saddle with your Pets?',
                        'text': 'Saddle',
                        'value': 5,
                        'notes': 'Instantly raises one of your pets into a mount.',
                        'key': 'Saddle',
                        'canDrop': false
                    },
                    'Cake_Skeleton': {
                        'text': 'Bare Bones Cake',
                        'textA': 'a Bare Bones Cake',
                        'textThe': 'the Bare Bones Cake',
                        'target': 'Skeleton',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Cake_Skeleton',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Cake_Base': {
                        'text': 'Basic Cake',
                        'textA': 'a Basic Cake',
                        'textThe': 'the Basic Cake',
                        'target': 'Base',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Cake_Base',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Cake_CottonCandyBlue': {
                        'text': 'Candy Blue Cake',
                        'textA': 'a Candy Blue Cake',
                        'textThe': 'the Candy Blue Cake',
                        'target': 'CottonCandyBlue',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Cake_CottonCandyBlue',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Cake_CottonCandyPink': {
                        'text': 'Candy Pink Cake',
                        'textA': 'a Candy Pink Cake',
                        'textThe': 'the Candy Pink Cake',
                        'target': 'CottonCandyPink',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Cake_CottonCandyPink',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Cake_Shade': {
                        'text': 'Chocolate Cake',
                        'textA': 'a Chocolate Cake',
                        'textThe': 'the Chocolate Cake',
                        'target': 'Shade',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Cake_Shade',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Cake_White': {
                        'text': 'Cream Cake',
                        'textA': 'a Cream Cake',
                        'textThe': 'the Cream Cake',
                        'target': 'White',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Cake_White',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Cake_Golden': {
                        'text': 'Honey Cake',
                        'textA': 'a Honey Cake',
                        'textThe': 'the Honey Cake',
                        'target': 'Golden',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Cake_Golden',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Cake_Zombie': {
                        'text': 'Rotten Cake',
                        'textA': 'a Rotten Cake',
                        'textThe': 'the Rotten Cake',
                        'target': 'Zombie',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Cake_Zombie',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Cake_Desert': {
                        'text': 'Sand Cake',
                        'textA': 'a Sand Cake',
                        'textThe': 'the Sand Cake',
                        'target': 'Desert',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Cake_Desert',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Cake_Red': {
                        'text': 'Strawberry Cake',
                        'textA': 'a Strawberry Cake',
                        'textThe': 'the Strawberry Cake',
                        'target': 'Red',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Cake_Red',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Candy_Skeleton': {
                        'text': 'Bare Bones Candy',
                        'textA': 'Bare Bones Candy',
                        'textThe': 'the Bare Bones Candy',
                        'target': 'Skeleton',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Candy_Skeleton',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Candy_Base': {
                        'text': 'Basic Candy',
                        'textA': 'Basic Candy',
                        'textThe': 'the Basic Candy',
                        'target': 'Base',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Candy_Base',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Candy_CottonCandyBlue': {
                        'text': 'Sour Blue Candy',
                        'textA': 'Sour Blue Candy',
                        'textThe': 'the Sour Blue Candy',
                        'target': 'CottonCandyBlue',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Candy_CottonCandyBlue',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Candy_CottonCandyPink': {
                        'text': 'Sour Pink Candy',
                        'textA': 'Sour Pink Candy',
                        'textThe': 'the Sour Pink Candy',
                        'target': 'CottonCandyPink',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Candy_CottonCandyPink',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Candy_Shade': {
                        'text': 'Chocolate Candy',
                        'textA': 'Chocolate Candy',
                        'textThe': 'the Chocolate Candy',
                        'target': 'Shade',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Candy_Shade',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Candy_White': {
                        'text': 'Vanilla Candy',
                        'textA': 'Vanilla Candy',
                        'textThe': 'the Vanilla Candy',
                        'target': 'White',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Candy_White',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Candy_Golden': {
                        'text': 'Honey Candy',
                        'textA': 'Honey Candy',
                        'textThe': 'the Honey Candy',
                        'target': 'Golden',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Candy_Golden',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Candy_Zombie': {
                        'text': 'Rotten Candy',
                        'textA': 'Rotten Candy',
                        'textThe': 'the Rotten Candy',
                        'target': 'Zombie',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Candy_Zombie',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Candy_Desert': {
                        'text': 'Sand Candy',
                        'textA': 'Sand Candy',
                        'textThe': 'the Sand Candy',
                        'target': 'Desert',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Candy_Desert',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Candy_Red': {
                        'text': 'Cinnamon Candy',
                        'textA': 'Cinnamon Candy',
                        'textThe': 'the Cinnamon Candy',
                        'target': 'Red',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Candy_Red',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Pie_Skeleton': {
                        'text': 'Bone Marrow Pot Pie',
                        'textA': 'a slice of Bone Marrow Pot Pie',
                        'textThe': 'the Bone Marrow Pot Pie',
                        'target': 'Skeleton',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Pie_Skeleton',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Pie_Base': {
                        'text': 'Basic Apple Pie',
                        'textA': 'a slice of Basic Apple Pie',
                        'textThe': 'the Basic Apple Pie',
                        'target': 'Base',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Pie_Base',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Pie_CottonCandyBlue': {
                        'text': 'Blueberry Pie',
                        'textA': 'a slice of Blueberry Pie',
                        'textThe': 'the Blueberry Pie',
                        'target': 'CottonCandyBlue',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Pie_CottonCandyBlue',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Pie_CottonCandyPink': {
                        'text': 'Pink Rhubarb Pie',
                        'textA': 'a slice of Pink Rhubarb Pie',
                        'textThe': 'the Pink Rhubarb Pie',
                        'target': 'CottonCandyPink',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Pie_CottonCandyPink',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Pie_Shade': {
                        'text': 'Dark Chocolate Pie',
                        'textA': 'a slice of Dark Chocolate Pie',
                        'textThe': 'the Dark Chocolate Pie',
                        'target': 'Shade',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Pie_Shade',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Pie_White': {
                        'text': 'Vanilla Pudding Pie',
                        'textA': 'a slice of Vanilla Pudding Pie',
                        'textThe': 'the Vanilla Pudding Pie',
                        'target': 'White',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Pie_White',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Pie_Golden': {
                        'text': 'Golden Banana Cream Pie',
                        'textA': 'a slice of Golden Banana Cream Pie',
                        'textThe': 'the Golden Banana Cream Pie',
                        'target': 'Golden',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Pie_Golden',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Pie_Zombie': {
                        'text': 'Rotten Pie',
                        'textA': 'a Rotten slice of Pie',
                        'textThe': 'the Rotten Pie',
                        'target': 'Zombie',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Pie_Zombie',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Pie_Desert': {
                        'text': 'Desert Dessert Pie',
                        'textA': 'a slice of Desert Dessert Pie',
                        'textThe': 'the Desert Dessert Pie',
                        'target': 'Desert',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Pie_Desert',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    },
                    'Pie_Red': {
                        'text': 'Red Cherry Pie',
                        'textA': 'a slice of Red Cherry Pie',
                        'textThe': 'the Red Cherry Pie',
                        'target': 'Red',
                        'canDrop': false,
                        'value': 1,
                        'key': 'Pie_Red',
                        'notes': 'Feed this to a pet and it may grow into a sturdy steed.'
                    }
                },
    }
}

";
    

    }
}
