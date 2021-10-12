using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public interface IPetService
    {
        List<Pet> GetUserPets(UserResponseDataItems data, PetService.PetFilter petFilter);
    }
}