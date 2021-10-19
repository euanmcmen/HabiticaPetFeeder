using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Service
{
    public class PetService : IPetService
    {
        private readonly ILogger<PetService> logger;

        public PetService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<PetService>();
        }

        //public IEnumerable<Pet> GetUserPets(UserResponseDataItems data)
        //{
        //    throw new NotImplementedException();
        //    //return userResponseElementParser.ExtractElement<Pet>(data.pets)
        //    //    .Where(x => x.FedPoints.Value > 0 && x.FedPoints.Value < 50)
        //    //    .ToHashSet();
        //}

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
