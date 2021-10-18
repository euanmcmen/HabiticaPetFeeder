using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Service
{
    public interface IPetService
    {
        IEnumerable<Pet> GetUserPets(UserResponseDataItems data);

        IEnumerable<Pet> FilterForBasicPets(IEnumerable<Pet> pets);

        IEnumerable<Pet> FilterForFeedablePets(IEnumerable<Pet> pets);
    }
}