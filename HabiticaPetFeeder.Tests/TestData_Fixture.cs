using HabiticaPetFeeder.Logic.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Tests
{
    public class TestData_Fixture
    {
        public IEnumerable<Pet> Pets { get; private set; }

        public IEnumerable<Food> Foods { get; private set; }

        public IEnumerable<PetFoodPreferences> PetFoodPreferences { get; private set; }

        public TestData_Fixture()
        {
            //Should be fed 6 milks.
            var lionWhite = new Pet("LionCub-White", "White", new IncreasingQuantity(20), true);

            //Should be fed 4 meats and 4 cakes.  No meats & one cake remaining.
            var wolfBase = new Pet("Wolf-Base", "Base", new IncreasingQuantity(10), true);

            //Should be fed combination of fish & potatoes.
            var tigerRoyal = new Pet("TigerCub-RoyalPurple", "RoyalPurple", new IncreasingQuantity(5), false);

            Pets = new List<Pet>()
            {
                { lionWhite },
                { wolfBase },
                { tigerRoyal }
            };

            var milkWhite = new Food("Milk", "White", new DecreasingQuantity(100));
            var meatBase = new Food("Meat", "Base", new DecreasingQuantity(4));
            var potatoeDesert = new Food("Potatoe", "Desert", new DecreasingQuantity(100));
            var fishSkeleton = new Food("Fish", "Skeleton", new DecreasingQuantity(100));
            var cakeWhite = new Food("Cake_White", "White", new DecreasingQuantity(10));
            var cakeBase = new Food("Cake_Base", "Base", new DecreasingQuantity(5));
            var cakeDesert = new Food("Cake_Desert", "Desert", new DecreasingQuantity(10));
            var pieWhite = new Food("Pie_White", "White", new DecreasingQuantity(5));
            var pieDesert = new Food("Pie_Desert", "Desert", new DecreasingQuantity(5));
            var candyWhite = new Food("Candy_White", "White", new DecreasingQuantity(1));

            Foods = new List<Food>()
            {
                { milkWhite },
                { meatBase },
                { potatoeDesert },
                { fishSkeleton },
                { cakeWhite },
                { cakeBase },
                { cakeDesert },
                { pieWhite },
                { pieDesert },
                { candyWhite },
            };

            var petFoodPreferences = new List<PetFoodPreferences>();

            var lionWhitePreferences = new PetFoodPreferences();
            lionWhitePreferences.AddPetPreferredFood(lionWhite, milkWhite);
            lionWhitePreferences.AddPetPreferredFood(lionWhite, pieWhite);
            lionWhitePreferences.AddPetPreferredFood(lionWhite, candyWhite);
            petFoodPreferences.Add(lionWhitePreferences);

            var wolfBasePreferences = new PetFoodPreferences();
            wolfBasePreferences.AddPetPreferredFood(wolfBase, meatBase);
            wolfBasePreferences.AddPetPreferredFood(wolfBase, cakeBase);
            petFoodPreferences.Add(wolfBasePreferences);

            PetFoodPreferences = petFoodPreferences;
        }
    }
}
