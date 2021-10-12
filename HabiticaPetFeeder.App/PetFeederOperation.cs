using Microsoft.Extensions.Logging;
using System;
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
            //I guess this operation will focus on the initial basic pet & preferred food feeds.

            logger.LogInformation("Starting...");

            var userResult = await habiticaApiClient.GetUserAsync();

            //Build a list of basic pets.
            var basicUserPets = GetFilteredUserPets(userResult.data.items);

            //Build a list of non-saddle foods.
            var userFoodsNoSaddle = GetFilteredUserFoods(userResult.data.items);

            //Build a list of each pet and their preferred foods.
            var petFoodPreferencesSet = GetPetFoodPreferences(basicUserPets, userFoodsNoSaddle);

            //Build a list of Basic Pet Food Feeds
            foreach (var petFoodPreference in petFoodPreferencesSet)
            {
                //Calculate how many portions of the pet's preferred food are required to reach 50.
                //Each preferred food feed is worth 5 points.
                var requiredNumberOfFeeds = (int)(10 - MathF.Floor(petFoodPreference.Key.FedPoints / 5));
                var allocatedFeeds = 0;

                //This will contain the full name of each food to be fed to this pet.
                var foodFullNames = new List<string>();

                ////No need to keep feeding this pet.
                //if (allocatedFeeds >= requiredNumberOfFeeds)

                foreach (var preferredFood in petFoodPreference.Value)
                {
                    while (preferredFood.Quantity > 0 && allocatedFeeds < requiredNumberOfFeeds)
                    {
                        //Move onto the next preferred food after exhausting this one.
                        if (preferredFood.Quantity == 0)
                            break;

                        //Stop allocating feeds to this pet.
                        if (allocatedFeeds >= requiredNumberOfFeeds)
                            break;

                        foodFullNames.Add(preferredFood.FullName);

                        preferredFood.Quantity--;

                        allocatedFeeds++;

                        //if (preferredFood.Quantity >= requiredNumberOfFeeds)
                        //{

                        ////Add the preferred food's full name (Quantity) number of times.
                        ////Because there is enough of this food to satisfy the pet, we can exit here.
                        //for (int i = 0; i < preferredFood.Quantity; i++)
                        //{
                        //    foodFullNames.Add(preferredFood.FullName);

                        //    preferredFood.Quantity--;

                        //    allocatedFeeds++;

                        //    //}
                        //}
                    }
                }

                logger.LogInformation($"Feed for {petFoodPreference.Key.FullName} (Fed Points: {petFoodPreference.Key.FedPoints} | Required: {requiredNumberOfFeeds}) -- " +
                    $"{string.Join(", ", foodFullNames)}");
            }

            logger.LogInformation("Finished.");
        }

        private Dictionary<Pet, List<Food>> GetPetFoodPreferences(List<Pet> pets, List<Food> foods)
        {
            //Create the preferred pet foods collection.
            var petFoodPreferencesResult = new Dictionary<Pet, List<Food>>();

            foreach (var pet in pets)
            {
                //This pet is an egg.
                if (pet.FedPoints == -1)
                    continue;

                foreach (var food in foods)
                {
                    //Don't use saddles yet.  Those instantly feed a pet.
                    if (food.FullName == "Saddle")
                        continue;

                    if (food.Type != pet.Type)
                        continue;

                    if (petFoodPreferencesResult.ContainsKey(pet))
                    {
                        petFoodPreferencesResult[pet].Add(food);
                    }
                    else
                    {
                        petFoodPreferencesResult.Add(pet, new List<Food>() { food });
                    }

                    //NOTES
                    //If the pet is a Magic Potion pet, it will have no "favourites" because pets hatched with Magic Potions prefer everything.
                    //I'm leaving those for now.
                }
            }

            foreach (var petFoodPreference in petFoodPreferencesResult)
            {
                //Sort each pet's food by descending quantity.
                petFoodPreference.Value.Sort((foodX, foodY) => foodY.Quantity.CompareTo(foodX.Quantity));

                logger.LogInformation($"Pet {petFoodPreference.Key.FullName} really likes {string.Join(" & ", petFoodPreference.Value.Select(x => x.FullName))}");
            }

            /*
             * { LionCub-White: [ {"Milk": 174 }, {"Cake_White": 7}, {Candy_White": 1,}, { "Pie_White": 1}] }
             * 
             */


            return petFoodPreferencesResult;
        }

        private List<Pet> GetFilteredUserPets(UserResponseDataItems userResponseDataItems)
        {
            var allUserpets = userResponseElementParser.ExtractElement<Pet>(userResponseDataItems.pets);

            logger.LogInformation($"All User Pets: {allUserpets.Count} pets.");

            var petForFilters = new List<Func<List<Pet>, List<Pet>>>()
            {
                FilterForBasicPets
            };

            var filteredPets = new List<Pet>(allUserpets);

            foreach (var filterFunction in petForFilters)
            {
                filteredPets = filterFunction(filteredPets);
            }

            logger.LogInformation($"Filtered User Pets: {filteredPets.Count} pets.");

            return filteredPets;
        }

        private List<Food> GetFilteredUserFoods(UserResponseDataItems userResponseDataItems)
        {
            var allUserFoods = userResponseElementParser.ExtractElement<Food>(userResponseDataItems.food);

            logger.LogInformation($"All User Foods: {allUserFoods.Count} foods.");

            var foodOutFilters = new List<Func<List<Food>, List<Food>>>()
            {
                FilterOutSaddle
            };

            var filteredFoods = new List<Food>(allUserFoods);

            foreach (var filterFunction in foodOutFilters)
            {
                filteredFoods = filterFunction(filteredFoods);
            }

            logger.LogInformation($"Filtered User Foods: {filteredFoods.Count} foods.");

            return filteredFoods;
        }

        private List<Pet> FilterForBasicPets(List<Pet> userPets)
        {
            var basicPets = new List<Pet>();

            var basicPetNames = new List<string>()
            {
                "Wolf",
                "TigerCub",
                "PandaCub",
                "LionCub",
                "Fox",
                "FlyingPig",
                "Dragon",
                "Cactus",
                "BearCub"
            };

            basicPets.AddRange(userPets.Where(pet => basicPetNames.Contains(pet.Name)));

            return basicPets;
        }

        private List<Food> FilterOutSaddle(List<Food> userFoods)
        {
            return userFoods.Where(x => x.FullName != "Saddle").ToList();
        }
    }
}
