using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

            //Create the preferred pet type/foods matrix.

            /*
             * Animal.Type:{ [Food.FullName], [Food.FullName] }
             * 
             */

            logger.LogInformation("Finished.");
        }
    }
}
