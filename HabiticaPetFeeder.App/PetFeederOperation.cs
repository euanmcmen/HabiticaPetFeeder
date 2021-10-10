using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public class PetFeederOperation
    {
        private readonly ILogger<TempService> logger;
        private readonly ICommonFoodsReferenceService commonFoodsReferenceService;

        public PetFeederOperation(ILoggerFactory loggerFactory, ICommonFoodsReferenceService commonFoodsReferenceService)
        {
            logger = loggerFactory.CreateLogger<TempService>();
            this.commonFoodsReferenceService = commonFoodsReferenceService;
        }

        public async Task RunOperationAsync()
        {
            logger.LogInformation("Starting...");

            await Task.CompletedTask;

            var result = commonFoodsReferenceService.GetPreferringTypeForFood("Meat");

            //Build a list of pets.

            //Build a list of foods.

            //Create the preferred pet type/foods matrix.

            logger.LogInformation($"Meat: {result}");

            logger.LogInformation("Finished.");
        }
    }
}
