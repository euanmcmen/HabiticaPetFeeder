using HabiticaPetFeeder.App.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.App
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
            return userResponseElementParser
                .ExtractElement<Pet>(data.pets)
                .Where(CanBeFed)
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

        private bool CanBeFed(Pet pet) => pet.FedPoints.Value > 0 && pet.FedPoints.Value < 50;
    }
}
