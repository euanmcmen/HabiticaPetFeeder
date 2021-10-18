using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using HabiticaPetFeeder.Logic.UserResponseParser;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Service
{
    public class PetService : IPetService
    {
        private readonly ILogger<PetService> logger;
        private readonly IUserResponseElementParser userResponseElementParser;

        public PetService(ILoggerFactory loggerFactory, IUserResponseElementParser userResponseElementParser)
        {
            logger = loggerFactory.CreateLogger<PetService>();
            this.userResponseElementParser = userResponseElementParser;
        }

        public IEnumerable<Pet> GetUserPets(UserResponseDataItems data)
        {
            return userResponseElementParser.ExtractElement<Pet>(data.pets)
                .Where(x => x.FedPoints.Value > 0 && x.FedPoints.Value < 50)
                .ToHashSet();
        }

        public IEnumerable<Pet> FilterForBasicPets(IEnumerable<Pet> pets)
        {
            return pets
                .Where(x => x.IsBasicPet)
                .ToHashSet();
        }

        public IEnumerable<Pet> FilterForFeedablePets(IEnumerable<Pet> pets)
        {
            return pets
                .Where(x => x.FedPoints.Value < 50)
                .ToHashSet();
        }
    }
}
