using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public class PetService : IPetService
    {
        public enum PetFilter
        {
            All = 0,
            Basic = 1
        }

        private static readonly HashSet<string> BasicPetNames = new()
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


        private readonly ILogger<PetService> logger;
        private readonly IUserResponseElementParser userResponseElementParser;

        public PetService(ILoggerFactory loggerFactory, IUserResponseElementParser userResponseElementParser)
        {
            logger = loggerFactory.CreateLogger<PetService>();
            this.userResponseElementParser = userResponseElementParser;
        }

        public List<Pet> GetUserPets(UserResponseDataItems data, PetFilter petFilter)
        {
            var userPets = userResponseElementParser.ExtractElement<Pet>(data.pets);

            var result = new List<Pet>();

            foreach (var pet in userPets)
            {
                //No Unhatched pets.
                if (pet.FedPoints < 0)
                    continue;

                //Apply filter.
                if (petFilter == PetFilter.Basic)
                {
                    if (!BasicPetNames.Contains(pet.Name))
                    {
                        continue;
                    }
                }

                result.Add(pet);
            }

            return result;
        }
    }
}
