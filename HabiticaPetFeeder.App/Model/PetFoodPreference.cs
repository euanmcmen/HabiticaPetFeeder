using System.Collections.Generic;

namespace HabiticaPetFeeder.App
{
    public record PetFoodPreference(Pet Pet, List<Food> PreferredFoods);
}
