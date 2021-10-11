using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public class PetFeederOperation
    {
        private readonly ILogger<PetFeederOperation> logger;
        private readonly IUserResponseElementParser userResponseElementParser;
        private readonly IHabiticaApiClient habiticaApiClient;

        public PetFeederOperation(ILoggerFactory loggerFactory,
            IUserResponseElementParser userResponseElementParser,
            IHabiticaApiClient habiticaApiClient)
        {
            logger = loggerFactory.CreateLogger<PetFeederOperation>();
            this.userResponseElementParser = userResponseElementParser;
            this.habiticaApiClient = habiticaApiClient;
        }

        public async Task RunOperationAsync()
        {
            logger.LogInformation("Starting...");

            var result = await habiticaApiClient.GetUserAsync();

            //Build a list of pets.
            var pets = userResponseElementParser.ExtractElement<Pet>(result.data.items.pets);

            logger.LogInformation($"Extracted {pets.Count} pets.");

            //Build a list of foods.
            var foods = userResponseElementParser.ExtractElement<Food>(result.data.items.food);

            logger.LogInformation($"Extracted {foods.Count} foods.");

            //Create the preferred pet foods collection.
            var petFoodPreferencesSet = new Dictionary<Pet, List<Food>>();

            foreach (var pet in pets)
            {
                //This pet is an egg.
                if (pet.FedPoints == -1)
                    continue;

                foreach (var food in foods)
                {
                    if (food.Type != pet.Type)
                        continue;

                    if (petFoodPreferencesSet.ContainsKey(pet))
                    {
                        petFoodPreferencesSet[pet].Add(food);
                    }
                    else
                    {
                        petFoodPreferencesSet.Add(pet, new List<Food>() { food });
                    }

                    //NOTES
                    //If the pet is a Magic Potion pet, it will have no "favourites" because pets hatched with Magic Potions prefer everything.
                    //I'm leaving those for now.
                }
            }

            foreach (var item in petFoodPreferencesSet)
            {
                logger.LogInformation($"Pet {item.Key.FullName} really likes {string.Join(" & ", item.Value.Select(x => x.FullName))}");
            }

            /*
             * { LionCub-White: [ {"Milk": 174 }, {"Cake_White": 7}, {Candy_White": 1,}, { "Pie_White": 1}] }
             * 
             */

            logger.LogInformation("Finished.");
        }
    }
}
