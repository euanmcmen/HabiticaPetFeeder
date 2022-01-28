using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Model;

public class UserPetFoodFeeds
{
    public string UserName { get; set; }

    public List<PetFoodFeed> PetFoodFeeds { get; set; }
}
