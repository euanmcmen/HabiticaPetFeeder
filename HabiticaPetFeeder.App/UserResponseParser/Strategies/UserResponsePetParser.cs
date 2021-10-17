using HabiticaPetFeeder.App.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public class UserResponsePetParser : IUserResponseParser<Pet>
    {
        private static readonly HashSet<string> basicPetNames = new()
        {
            "Wolf",
            "TigerCub",
            "PandaCub",
            "LionCub",
            "Fox",
            "FlyingPig",
            "Dragon",
            "Cactus",
            "BearCub"
        };

        private static readonly HashSet<string> basicPetTypes = new()
        {
            "Base",
            "White",
            "Desert",
            "Red",
            "Shade",
            "Skeleton",
            "Zombie",
            "CottonCandyPink",
            "CottonCandyBlue",
            "Golden"
        };

        private readonly ILogger<UserResponsePetParser> logger;

        public UserResponsePetParser(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<UserResponsePetParser>();
        }

        public Pet Parse(string propertyName, string propertyValue)
        {
            var petParts = propertyName.Split("-");

            var isBasicPet = basicPetNames.Contains(petParts[0]) && basicPetTypes.Contains(petParts[1]);

            logger.LogInformation($"Pet {propertyName} {(isBasicPet ? "is a" : "is not a")} basic pet.");

            return new Pet(propertyName, petParts[0], petParts[1], new IncreasingQuantity(int.Parse(propertyValue)), isBasicPet);
        }
    }
}
