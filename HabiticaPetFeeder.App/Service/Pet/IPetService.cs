using HabiticaPetFeeder.App.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IPetService
    {
        IEnumerable<Pet> GetUserPets(UserResponseDataItems data);

        IEnumerable<Pet> FilterForBasicPets(IEnumerable<Pet> pets);

        IEnumerable<Pet> FilterForFeedablePets(IEnumerable<Pet> pets);
    }
}