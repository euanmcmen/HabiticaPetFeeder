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

        public List<Pet> GetUserPets(UserResponseDataItems data)
        {
            return userResponseElementParser
                .ExtractElement<Pet>(data.pets)
                .Where(CanBeFed)
                .ToList();
        }

        public List<Pet> FilterPets(List<Pet> pets, PetFilter petFilter)
        {
            var result = new List<Pet>(pets.Count);

            foreach (var pet in pets)
            {
                if (petFilter == PetFilter.Basic)
                {
                    if (!pet.IsBasicPet)
                        continue;
                }

                result.Add(pet);
            }

            return result;
        }

        private bool CanBeFed(Pet pet) => pet.FedPoints.Value > 0 && pet.FedPoints.Value < 50;
    }
}
