using HabiticaPetFeeder.Logic.Model;

namespace HabiticaPetFeeder.Api.Model;

public class FeedUserPetRequest
{
    public UserApiAuthInfo UserApiAuthInfo { get; set; }
    public PetFoodFeed PetFoodFeed { get; set; }
}
