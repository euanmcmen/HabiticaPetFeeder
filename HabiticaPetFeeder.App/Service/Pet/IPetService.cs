using HabiticaPetFeeder.App.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IPetService
    {
        List<Pet> GetUserPets(UserResponseDataItems data);

        List<Pet> FilterPets(List<Pet> pets, PetFilter petFilter);
    }
}